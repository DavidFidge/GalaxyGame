using System;
using System.Collections.Generic;
using System.Linq;
using GalaxyGame.Model.Unity;

namespace GalaxyGame.Model.Space
{
    public class SolarSystem : Entity
    {
        public SolarSystem()
        {
            SubSystem = new SubSystem();
            SystemLocation = new Vector3();
        }

        public virtual string Name { get; set; }
        public virtual GalaxySector GalaxySector { get; set; }
        public virtual SubSystem SubSystem { get; set; }

        // X and Y must be between 0.0 - 1.0
        public virtual Vector3 SystemLocation { get; set; }
    }
}