using System;
using System.Collections.Generic;
using System.Linq;
using GalaxyGame.DataLayer.Interfaces;

namespace GalaxyGame.DataLayer.Components
{
    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        public string DatabaseName { get; set; }

        public DatabaseConfiguration()
        {
            DatabaseName = "GalaxyGame";
        }
    }
}