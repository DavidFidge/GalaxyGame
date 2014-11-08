using System;
using System.Collections.Generic;

namespace GalaxyGame.Model.Space
{
    public class GalaxySectorLink : Entity
    {
        public GalaxySectorLink()
        {
        }

        public virtual GalaxySector SectorFrom { get; set; }
        public virtual GalaxySector SectorTo { get; set; }
        public virtual GalaxySectorLinkType LinkType { get; set; }
    }
}
