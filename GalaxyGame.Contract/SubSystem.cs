using System;
using System.Collections.Generic;
using System.Linq;

namespace GalaxyGame.Contract
{
    public class SubSystem
    {
        public SubSystem ParentSubSystem { get; set; }

        public SystemPosition SystemPosition { get; set; }

        public List<SpaceObject> SpaceObjects { get; set; }
    }
}