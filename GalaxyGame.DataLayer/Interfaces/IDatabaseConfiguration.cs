using System;
using System.Collections.Generic;
using System.Linq;

namespace GalaxyGame.DataLayer.Interfaces
{
    public interface IDatabaseConfiguration
    {
        string DatabaseName { get; set; }
    }
}