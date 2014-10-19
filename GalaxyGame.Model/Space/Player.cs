using System;
using System.Collections.Generic;
using GalaxyGame.Model.Interfaces;

namespace GalaxyGame.Model.Space
{
    public class Player : Entity, IHasPosition
    {
        public Player()
        {
        }
    
        public virtual string Name { get; set; }

        public SolarSystem CurrentSystem { get; set; }

        public SystemPosition SystemPosition { get; set; }
    }
}
