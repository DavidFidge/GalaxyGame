using System;
using System.Collections.Generic;

namespace GalaxyGame.Model.Space
{
    public class Galaxy : Entity
    {
        public Galaxy()
        {
            GalaxySectors = new HashSet<GalaxySector>();
        }
    
        public virtual string Name { get; set; }

        public virtual ICollection<GalaxySector> GalaxySectors { get; set; }
    }
}
