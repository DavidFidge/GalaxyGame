using System;
using System.Collections.Generic;
using UnityEngine;

namespace GalaxyGame.Model.Space
{
    public class SystemSector : Entity
    {
        public SystemSector()
        {
            Exploration = new Exploration();
        }

        public virtual int X { get; set; }
        public virtual int Y { get; set; }

        public virtual Exploration Exploration { get; set; }
    }
}
