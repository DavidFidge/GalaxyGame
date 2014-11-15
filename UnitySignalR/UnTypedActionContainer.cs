using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitySignalR
{
    public class UnTypedActionContainer
    {
        public Type ActionType { get; set; }
        public Action<Object> Action { get; set; }
    };
}