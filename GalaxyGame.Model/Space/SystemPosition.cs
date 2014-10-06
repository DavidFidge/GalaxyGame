using System;
using System.Collections.Generic;
using GalaxyGame.Model.Unity;

namespace GalaxyGame.Model.Space
{
    public class SystemPosition : Entity
    {
        public SystemPosition()
        {
        }

        // The position of the object
        public virtual Vector3 Translation { get; set; }

        // The position of the object relative to other objects it may be connected to
        public virtual Vector3 TranslationRelative { get; set; }

        // Rotation vector of the object
        public virtual Vector3 Rotation { get; set; }

        // Scale of the object
        public virtual Vector3 Scale { get; set; }

        // X = speed of x-axis rotation and so on for the rest
        public virtual Vector3 AxisRotation { get; set; }
    }
}
