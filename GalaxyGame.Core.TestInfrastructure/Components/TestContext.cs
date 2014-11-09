using System;
using System.Collections.Generic;
using System.Linq;
using GalaxyGame.Core.TestInfrastructure.Interfaces;
using GalaxyGame.DataLayer.EntityFramework;
using GalaxyGame.DataLayer.Interfaces;

namespace GalaxyGame.Core.TestInfrastructure.Components
{
    public class TestContext : EntityFrameworkContext, ITestContext
    {
        public TestContext(IDatabaseConfiguration databaseConfiguration) : base(databaseConfiguration)
        {
        }

        public void DeleteDatabase()
        {
            _context.Database.Delete();
        }
    }
}