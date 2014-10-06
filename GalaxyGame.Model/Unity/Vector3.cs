using System;
using System.Collections.Generic;
using GalaxyGame.Model.Space;

namespace GalaxyGame.Model.Unity
{
    public class Vector3
    {
        public UnityEngine.Vector3 Value;

        public float X { get { return Value.x; } set { Value.x = value; } }
        public float Y { get { return Value.y; } set { Value.y = value; } }
        public float Z { get { return Value.z; } set { Value.z = value; } }
    }
}
