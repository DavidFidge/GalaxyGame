using System;
using System.Collections.Generic;

namespace GalaxyGame.Model.Space
{
    public class Player : Entity
    {
        public Player()
        {
        }
    
        public virtual string Name { get; set; }

        public SolarSystem CurrentSystem { get; set; }

    }
}
