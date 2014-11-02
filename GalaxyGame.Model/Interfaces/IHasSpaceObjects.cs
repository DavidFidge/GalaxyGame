using System;
using System.Collections.Generic;
using System.Linq;
using GalaxyGame.Model.Space;

namespace GalaxyGame.Model.Interfaces
{
    public interface IHasSpaceObjects
    {
        ICollection<SpaceObject> SpaceObjects { get; set; }
    }
}