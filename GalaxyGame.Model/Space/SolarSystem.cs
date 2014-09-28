using System;
using System.Collections.Generic;

namespace GalaxyGame.Model.Space
{
    public class SolarSystem : IEntity
    {
        public SolarSystem()
        {
            SpaceObjects = new HashSet<SpaceObject>();
        }

        public Guid Id { get; set; }
        public Guid GalaxyId { get; set; }

        public virtual Galaxy Galaxy { get; set; }
        public virtual ICollection<SpaceObject> SpaceObjects { get; set; }
    }
}
