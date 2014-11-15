using System;
using System.Collections.Generic;
using System.Linq;

namespace GalaxyGame.Contract
{
    public class SystemPosition
    {
        // Destination translation of object
        public Vector3 Destination { get; set; }

        // The position of the object.
        public Vector3 Translation { get; set; }

        // The position of the object relative to other objects it may be connected to
        public Vector3 OrbitTranslation { get; set; }

        public bool IsOrbiting { get; set; }

        // Speed in radians per second
        public float Speed { get; set; }

        // Rotation vector of the object
        public Vector3 Rotation { get; set; }

        // Scale of the object
        public Vector3 Scale { get; set; }

        // X = speed of x-axis rotation and so on for the rest
        public Vector3 AxisRotation { get; set; }

        // Start of time for object orbit
        public DateTime OrbitOriginTime { get; set; }
    }
}