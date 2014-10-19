using System;
using System.Collections.Generic;
using System.Linq;
using GalaxyGame.Model.Space;

namespace GalaxyGame.Model.Interfaces
{
    public interface IHasPosition
    {
        SystemPosition SystemPosition { get; set; }
    }
}