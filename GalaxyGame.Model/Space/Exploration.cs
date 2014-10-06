using System;
using System.Collections.Generic;

namespace GalaxyGame.Model.Space
{
    public class Exploration : Entity
    {
        public Exploration()
        {
        }

        public Guid ExploredById { get; set; }
        public virtual Player ExploredBy { get; set; }

        public virtual DateTime ExploredDateTime { get; set; }
    }
}
