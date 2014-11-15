using System;
using System.Collections.Generic;
using System.Linq;

namespace GalaxyGame.Contract
{
    public class SpaceObject
    {
        public string Name { get; set; }

        public SubSystem ContainingSubSystem { get; set; }
        public SubSystem SubSystem { get; set; }
        public SystemPosition SystemPosition { get; set; }
    }
}