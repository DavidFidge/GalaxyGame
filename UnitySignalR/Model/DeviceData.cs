using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitySignalR.Model
{
    public class DeviceData
    {
        public string DataType { get; set; }

        public int DataValue { get; set; }

        public DateTime DateRead { get; set; }
    }
}