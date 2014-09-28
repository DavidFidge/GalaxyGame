using System;
using System.Collections.Generic;

namespace GalaxyGame.Model.Space
{
    public class Galaxy : IEntity
    {
        public Galaxy()
        {
            SolarSystems = new HashSet<SolarSystem>();
        }
    
        public Guid Id { get; set; }

        public virtual string Name { get; set; }

        public virtual ICollection<SolarSystem> SolarSystems { get; set; }
    }
}
