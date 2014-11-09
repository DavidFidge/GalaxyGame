using System;
using System.Collections.Generic;
using System.Linq;
using GalaxyGame.Core.Installers;
using GalaxyGame.Core.TestInfrastructure.Base;
using GalaxyGame.Model.Space;
using GalaxyGame.Service.Installers;
using GalaxyGame.Service.Interfaces;
using NUnit.Framework;

namespace GalaxyGame.Service.Tests
{
    [TestFixture]
    public class GalaxyDataServiceIntegrationTest : BaseIntegrationTest
    {
        private IGalaxyDataService _galaxyDataService;

        [SetUp]
        public override void Setup()
        {
            base.Setup();

            _container.Install(new CoreInstaller());
            _container.Install(new ServiceInstaller());
            _galaxyDataService = _container.Resolve<IGalaxyDataService>();
        }

        [TearDown]
        public override void Teardown()
        {
            _container.Release(_galaxyDataService);
            _galaxyDataService = null;

            base.Teardown();
        }

        [Test]
        public void Test_Create_Galaxy_Successful()
        {
            // Act
            _galaxyDataService.CreateGalaxy();

            // Assert
            var uow = UnitOfWorkFactory.Create();

            var galaxy = uow.Context.DbSet<Galaxy>().First();
            Assert.True(!string.IsNullOrEmpty(galaxy.Name));
            Assert.AreEqual(1, galaxy.GalaxySectors.Count);

            var galaxySector = galaxy.GalaxySectors.First();
            Assert.AreEqual(galaxy, galaxySector.Galaxy);
            Assert.True(!string.IsNullOrEmpty(galaxySector.Name));
            Assert.NotNull(galaxySector.Exploration);

            UnitOfWorkFactory.Release();
        }
    }
}