using GalaxyGame.Model.Interfaces;
using System;
using UnityEngine;

namespace GalaxyGame.Model.Space
{
    public abstract class SpaceObject : Entity, IHasPosition
    {
        public SpaceObject()
        {
            Exploration = new Exploration();
            SystemPosition = new SystemPosition();
        }

        public virtual string Name { get; set; }
        public virtual SolarSystem SolarSystem { get; set; }
        public virtual SubSystem ContainingSubSystem { get; set; }
        public virtual SubSystem SubSystem { get; set; }
        public virtual SystemPosition SystemPosition { get; set; }
        public virtual Exploration Exploration { get; set; }
    }
}
