using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxyGame.Core.TestInfrastructure;
using GalaxyGame.Model.Space;
using GalaxyGame.Service.Services;
using NUnit.Framework;

namespace GalaxyGame.Service.Tests
{
    [TestFixture]
    public class GalaxyDataServiceTest : BaseUnitTest
    {
        protected GalaxyDataService _galaxyDataService;

        [SetUp]
        public void Setup()
        {
            _galaxyDataService = new GalaxyDataService(_unitOfWorkFactory);
        }

        [Test]
        public void Test_Create_Galaxy_Successful()
        {
            _galaxyDataService.CreateGalaxy();

            Assert.AreEqual(_context.DbSet<Galaxy>().Count(), 1);

            var galaxy = _context.DbSet<Galaxy>().First();
        }
    }
}
