using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitySignalR.Model
{
    public class DeviceDataWrapper
    {
        public string H { get; set; }

        public string M { get; set; }

        public DeviceData[] A { get; set; }
    }
}