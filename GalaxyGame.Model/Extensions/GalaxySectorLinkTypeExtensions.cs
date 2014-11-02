using System;
using System.Collections.Generic;
using System.Linq;
using GalaxyGame.Model.Space;

namespace GalaxyGame.Model.Extensions
{
    public static class GalaxySectorLinkTypeExtensions
    {
        public static GalaxySectorLinkType OppositeDirection(this GalaxySectorLinkType galaxySectorLinkType)
        {
            switch (galaxySectorLinkType)
            {
                case GalaxySectorLinkType.East:
                    return GalaxySectorLinkType.West;
                case GalaxySectorLinkType.West:
                    return GalaxySectorLinkType.East;
                case GalaxySectorLinkType.North:
                    return GalaxySectorLinkType.South;
                case GalaxySectorLinkType.South:
                    return GalaxySectorLinkType.North;
                default:
                    return GalaxySectorLinkType.None;
            }
        }
    }
}