using System;
using System.Collections.Generic;
using System.Linq;
using GalaxyGame.Core.Interfaces;
using GalaxyGame.Model.Unity;

namespace GalaxyGame.Model.Space
{
    public class SystemPosition : Entity
    {
        public SystemPosition()
        {
            Destination = new Vector3();
            Translation = new Vector3();
            OrbitTranslation = new Vector3();
            Rotation = new Vector3();
            Scale = new Vector3(1.0f);
            AxisRotation = new Vector3();
            OrbitOriginTime = DateTime.Now;
            IsOrbiting = true;
        }

        // Destination translation of object
        public virtual Vector3 Destination { get; set; }

        // The position of the object.
        public virtual Vector3 Translation { get; set; }

        // The position of the object relative to other objects it may be connected to
        public virtual Vector3 OrbitTranslation { get; set; }

        public virtual bool IsOrbiting { get; set; }

        // Speed in radians per second
        public virtual float Speed { get; set; }

        // Rotation vector of the object
        public virtual Vector3 Rotation { get; set; }

        // Scale of the object
        public virtual Vector3 Scale { get; set; }

        // X = speed of x-axis rotation and so on for the rest
        public virtual Vector3 AxisRotation { get; set; }

        // Start of time for object orbit
        public virtual DateTime OrbitOriginTime { get; set; }

        //public Vector3 CurrentOrbitPosition(SubSystem subSystem, IDateTimeProvider dateTimeProvider)
        //{
        //    if (subSystem == null || !IsOrbiting)
        //    {
        //        return new Vector3(Translation);
        //    }

        //    var origin = subSystem.SystemPosition.CurrentOrbitPosition(subSystem.ParentSubSystem, dateTimeProvider);

        //    var cosAngle = ((dateTimeProvider.Now - OrbitOriginTime).TotalSeconds * Speed) / (2 * Math.PI);

        //    return new Vector3(origin.Value + (OrbitTranslation.Value * (float)Math.Cos(cosAngle)));
        //}
    }
}