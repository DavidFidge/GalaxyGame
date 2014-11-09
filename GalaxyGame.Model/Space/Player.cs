using System;
using System.Collections.Generic;
using GalaxyGame.Model.Interfaces;
using GalaxyGame.Model.Unity;

namespace GalaxyGame.Model.Space
{
    public class Player : Entity, IHasPosition
    {
        public Player()
        {
            SystemPosition.IsOrbiting = false;
        }
    
        public virtual string Name { get; set; }
        public virtual SolarSystem CurrentSystem { get; set; }
        public virtual SystemPosition SystemPosition { get; set; }
    }
}
