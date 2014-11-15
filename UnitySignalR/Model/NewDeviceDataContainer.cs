using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitySignalR.Model
{
    public class NewDeviceDataContainer
    {
        private readonly Dictionary<string, int> _valueDictionary;
        private readonly Object _lock;

        public NewDeviceDataContainer()
        {
            _valueDictionary = new Dictionary<string, int>();
            _lock = new object();
        }

        public void Add(DeviceData data)
        {
            lock(_lock)
            {
                _valueDictionary[data.DataType] = data.DataValue;
            }
        }

        public IEnumerable<DeviceData> DeviceData
        {
            get
            {
                lock(_lock)
                {
                    foreach (var item in _valueDictionary)
                    {
                        yield return new DeviceData
                        {
                            DataType = item.Key,
                            DataValue = item.Value
                        };
                    }
                    _valueDictionary.Clear();
                }
            }
        }
    }
}