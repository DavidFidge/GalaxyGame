using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using GalaxyGame.Core.Interfaces;
using GalaxyGame.Model.Interfaces;
using GalaxyGame.Model.Unity;

namespace GalaxyGame.Model.Space
{
    public class SubSystem : Entity, IHasPosition
    {
        public SubSystem()
        {
            SpaceObjects = new HashSet<SpaceObject>();
            SystemPosition = new SystemPosition();
            SystemPosition.Translation = new Vector3();
        }

        public virtual SubSystem ParentSubSystem { get; set; }

        public virtual SystemPosition SystemPosition { get; set; }

        public virtual ICollection<SpaceObject> SpaceObjects { get; set; }

        [NotMapped]
        public ICollection<SpaceObject> AllSpaceObjects
        {
            get
            {
                var spaceObjects = new List<SpaceObject>();
                spaceObjects.AddRange(SpaceObjects);

                foreach (var subSystem in 
                    spaceObjects.Where(so => so.SubSystem != null)
                        .Select(so => so.SubSystem))
                {
                    spaceObjects.AddRange(subSystem.AllSpaceObjects);
                }

                return spaceObjects;
            }
        }
    }
}
