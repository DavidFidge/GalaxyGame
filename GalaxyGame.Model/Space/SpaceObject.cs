using System;

namespace GalaxyGame.Model.Space
{
    public abstract class SpaceObject : IEntity
    {
        public Guid Id { get; set; }
        public Guid SystemId { get; set; }
        public Guid SubSystemId { get; set; }

        public virtual SolarSystem System { get; set; }
        public virtual SubSystem SubSystem { get; set; }
    }
}
