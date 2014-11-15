using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using JsonFx.Json;
using UnityEngine;
using UnitySignalR.Model;
using WebSocketSharp;
using ErrorEventArgs = WebSocketSharp.ErrorEventArgs;
using Random = UnityEngine.Random;

namespace UnitySignalR
{
    public class SignalRClient
    {
        private WebSocket _ws;
        private readonly string _connectionToken;
        private readonly Dictionary<string, UnTypedActionContainer> _actionMap;

        public SignalRClient()
        {
            var reader = new JsonReader();
            _actionMap = new Dictionary<string, UnTypedActionContainer>();
            HttpWebRequest webRequest = (HttpWebRequest) WebRequest.Create("http://localhost/signalr/negotiate?connectionData=%5B%7B%22name%22%3A%22devicedatahub%22%7D%5D&clientProtocol=1.3&_=1408716619953");
            var response = (HttpWebResponse) webRequest.GetResponse();

            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                _connectionToken = Uri.EscapeDataString(reader.Read<NegotiateResponse>(sr.ReadToEnd()).ConnectionToken);
            }
        }

        public void Open()
        {
            if (_ws == null)
            {
                _ws = new WebSocket("ws://localhost/signalr/connect?transport=webSockets&connectionToken=" + _connectionToken + "&connectionData=%5B%7B%22name%22%3A%22devicedatahub%22%7D%5D&tid=" + Random.Range(0, 11));
            }
            else
            {
                _ws = new WebSocket("ws://localhost/signalr/reconnect?transport=webSockets&connectionToken=" + _connectionToken + "&connectionData=%5B%7B%22name%22%3A%22devicedatahub%22%7D%5D&tid=" + Random.Range(0, 11));
            }
            AttachAndConnect();
        }

        private void AttachAndConnect()
        {
            _ws.OnClose += _ws_OnClose;

            _ws.OnError += _ws_OnError;

            _ws.OnMessage += _ws_OnMessage;

            _ws.OnOpen += _ws_OnOpen;

            _ws.Connect();
        }

        private void _ws_OnOpen(object sender, EventArgs e)
        {
            Debug.Log("Opened Connection");
        }

        private void _ws_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Data.Contains("\"H\":\"DeviceDataHub\""))
            {
                var reader = new JsonReader();

                var deviceDataWrapper = reader.Read<MessageWrapper>(e.Data).M[0];
                _actionMap[deviceDataWrapper.M].Action(deviceDataWrapper.A[0]);
            }
        }

        private void _ws_OnError(object sender, ErrorEventArgs e)
        {
            Debug.Log(e.Message);
        }

        private void _ws_OnClose(object sender, CloseEventArgs e)
        {
            Debug.Log(e.Reason + " Code: " + e.Code + " WasClean: " + e.WasClean);
        }

        public void On<T>(string method, Action<T> callback) where T : class
        {
            _actionMap.Add(method, new UnTypedActionContainer
            {
                Action = x => { callback(x as T); },
                ActionType = typeof(T)
            });
        }
    }
}