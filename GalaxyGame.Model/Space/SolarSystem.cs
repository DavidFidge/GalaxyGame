using System;
using System.Collections.Generic;
using GalaxyGame.Model.Interfaces;
using GalaxyGame.Model.Unity;

namespace GalaxyGame.Model.Space
{
    public class SolarSystem : Entity, IHasSpaceObjects
    {
        public SolarSystem()
        {
            SpaceObjects = new HashSet<SpaceObject>();
        }

        public virtual string Name { get; set; }

        public Guid GalaxySectorId { get; set; }
        public virtual GalaxySector GalaxySector { get; set; }

        public virtual ICollection<SpaceObject> SpaceObjects { get; set; }

        // X and Y must be between 0.0 - 1.0
        public virtual Vector3 SystemLocation { get; set; }
    }
}
