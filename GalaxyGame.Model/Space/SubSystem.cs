using System;
using System.Collections.Generic;
using GalaxyGame.Model.Interfaces;
using UnityEngine;

namespace GalaxyGame.Model.Space
{
    public class SubSystem : Entity, IHasPosition
    {
        public SubSystem()
        {
            SpaceObjects = new HashSet<SpaceObject>();
            ChildSubSystems = new HashSet<SubSystem>();
        }

        public virtual ICollection<SpaceObject> SpaceObjects { get; set; }

        public virtual ICollection<SubSystem> ChildSubSystems { get; set; }

        public Guid? ParentSubSystemId { get; set; }
        public virtual SubSystem ParentSubSystem { get; set; }

        public Guid SystemLocationId { get; set; }
        public virtual SystemPosition SystemPosition { get; set; }
    }
}
