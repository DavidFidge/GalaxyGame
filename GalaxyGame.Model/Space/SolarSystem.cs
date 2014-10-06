using System;
using System.Collections.Generic;

namespace GalaxyGame.Model.Space
{
    public class SolarSystem : Entity
    {
        public SolarSystem()
        {
            SpaceObjects = new HashSet<SpaceObject>();
        }

        public virtual string Name { get; set; }

        public Guid GalaxyId { get; set; }
        public virtual GalaxySector GalaxySector { get; set; }

        public virtual ICollection<SpaceObject> SpaceObjects { get; set; }
    }
}
