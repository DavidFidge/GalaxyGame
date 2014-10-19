using GalaxyGame.Model.Interfaces;
using System;
using UnityEngine;

namespace GalaxyGame.Model.Space
{
    public abstract class SpaceObject : Entity, IHasPosition
    {
        public virtual string Name { get; set; }

        public Guid SystemId { get; set; }
        public virtual SolarSystem SolarSystem { get; set; }

        public Guid SubSystemId { get; set; }
        public virtual SubSystem SubSystem { get; set; }

        public Guid SystemPositionId { get; set; }
        public virtual SystemPosition SystemPosition { get; set; }

        public Guid ExplorationId { get; set; }
        public virtual Exploration Exploration { get; set; }
    }
}
