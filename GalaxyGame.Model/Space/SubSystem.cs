using System;
using System.Collections.Generic;

namespace GalaxyGame.Model.Space
{
    public class SubSystem : IEntity
    {
        public SubSystem()
        {
            SpaceObjects = new HashSet<SpaceObject>();
            ParentSubSystem = new HashSet<SubSystem>();
        }

        public Guid Id { get; set; }
        public Guid? SubSystemId { get; set; }

        public virtual ICollection<SpaceObject> SpaceObjects { get; set; }
        public virtual ICollection<SubSystem> ParentSubSystem { get; set; }
        public virtual SubSystem ChildSubSystems { get; set; }
    }
}
