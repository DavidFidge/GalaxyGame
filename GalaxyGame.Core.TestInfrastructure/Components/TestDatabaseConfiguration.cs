using System;
using System.Collections.Generic;
using System.Linq;
using GalaxyGame.DataLayer.Interfaces;

namespace GalaxyGame.Core.TestInfrastructure.Components
{
    public class TestDatabaseConfiguration : IDatabaseConfiguration
    {
        public string DatabaseName { get; set; }

        public TestDatabaseConfiguration()
        {
            DatabaseName = "Test" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }
    }
}