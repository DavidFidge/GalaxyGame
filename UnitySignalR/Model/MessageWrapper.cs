using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitySignalR.Model
{
    public class MessageWrapper
    {
        public string C { get; set; }

        public DeviceDataWrapper[] M { get; set; }
    }
}