using System;
using System.Collections.Generic;
using GalaxyGame.Model.Interfaces;
using UnityEngine;

namespace GalaxyGame.Model.Space
{
    public class SubSystem : Entity, IHasPosition, IHasSpaceObjects
    {
        public SubSystem()
        {
            SpaceObjects = new HashSet<SpaceObject>();
            SystemPosition = new SystemPosition();
        }

        public virtual ICollection<SpaceObject> SpaceObjects { get; set; }

        public virtual Guid SystemPositionId { get; set; }
        public virtual SystemPosition SystemPosition { get; set; }
    }
}
