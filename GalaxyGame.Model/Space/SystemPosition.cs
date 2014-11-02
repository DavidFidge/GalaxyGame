using System;
using System.Collections.Generic;
using System.Linq;
using GalaxyGame.Core.Interfaces;
using GalaxyGame.Model.Unity;

namespace GalaxyGame.Model.Space
{
    public class SystemPosition : Entity
    {
        // Destination translation of object
        public virtual Vector3 Destination { get; set; }

        // The position of the object.  This is a calculated field if object has an OrbitTranslation.
        public virtual Vector3 Translation { get; set; }

        // The position of the object relative to other objects it may be connected to
        public virtual Vector3 OrbitTranslation { get; set; }

        // Speed in radians per second
        public double Speed { get; set; }

        // Rotation vector of the object
        public virtual Vector3 Rotation { get; set; }

        // Scale of the object
        public virtual Vector3 Scale { get; set; }

        // X = speed of x-axis rotation and so on for the rest
        public virtual Vector3 AxisRotation { get; set; }

        // Start of time for object orbit
        public virtual DateTime OrbitOriginTime { get; set; }

        public Vector3 CurrentOrbitPosition(SystemPosition parentPosition, IDateTimeProvider dateTimeProvider)
        {
            if (OrbitTranslation.Value == UnityEngine.Vector3.zero)
            {
                return new Vector3(Translation);
            }

            var cosAngle = ((dateTimeProvider.Now - OrbitOriginTime).TotalSeconds * Speed)/(2 * Math.PI);

            var parentOrbitTranslation = new Vector3();

            if (parentPosition != null)
                parentOrbitTranslation = new Vector3(parentPosition.OrbitTranslation.Value);

            return new Vector3(parentOrbitTranslation.Value + (OrbitTranslation.Value * (float)Math.Cos(cosAngle)));
        }
    }
}