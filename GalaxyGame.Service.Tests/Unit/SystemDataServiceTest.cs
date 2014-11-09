using System;
using System.Collections.Generic;
using System.Linq;
using GalaxyGame.Core.Interfaces;
using GalaxyGame.Core.TestInfrastructure.Base;
using GalaxyGame.Model.Space;
using GalaxyGame.Service.Interfaces;
using GalaxyGame.Service.Services;
using NSubstitute;
using NUnit.Framework;

namespace GalaxyGame.Service.Tests.Unit
{
    [TestFixture]
    public class SystemDataServiceTest : BaseUnitTest
    {
        private IDictionaryDataService _dictionaryDataService;
        private ISystemDataService _systemDataService;
        private IRandomization _randomization;
        private ISystemSettings _systemSettings;

        [SetUp]
        public override void Setup()
        {
            base.Setup();

            _dictionaryDataService = Substitute.For<IDictionaryDataService>();
            _dictionaryDataService.GetRandomLatinName(Arg.Any<int>()).Returns("Random name");

            _randomization = Substitute.For<IRandomization>();
            _randomization.Rand(1, 2).Returns(1);

            _systemSettings = Substitute.For<ISystemSettings>();
            _systemSettings.MinSolarSystemsInGalaxySector.Returns(5);
            _systemSettings.MaxSolarSystemsInGalaxySector.Returns(6);
            _randomization.Rand(5, 6).Returns(5);

            _systemSettings.MinPlanetsInSystem.Returns(7);
            _systemSettings.MaxPlanetsInSystem.Returns(8);
            _randomization.Rand(7, 8).Returns(7);

            _randomization.Rand().Returns(0.5f);

            _systemDataService = new SystemDataService(
                _unitOfWorkFactory,
                _systemSettings,
                _randomization,
                _dictionaryDataService,
                _dateTimeProvider);
        }

        [Test]
        public void Test_CreateSystemsForGalaxySector_Successful()
        {
            // Arrange
            var galaxySector = new GalaxySector();

            // Act
            _systemDataService.CreateSystemsForGalaxySector(galaxySector);

            // Assert
            Assert.AreEqual(5, galaxySector.SolarSystems.Count);

            foreach (var solarSystem in galaxySector.SolarSystems)
            {
                Assert.AreEqual(galaxySector, solarSystem.GalaxySector);
                Assert.AreEqual(solarSystem.Name, "Random name");
                Assert.AreEqual(solarSystem.SystemLocation.X, 0.5f);
                Assert.AreEqual(solarSystem.SystemLocation.Y, 0.5f);

                Assert.NotNull(solarSystem.SubSystem);
                Assert.AreEqual(8, solarSystem.SubSystem.SpaceObjects.Count);

                var star = solarSystem.SubSystem.SpaceObjects.OfType<Star>().First();

                Assert.AreEqual("Random name", star.Name);

                var planets = star.ContainingSubSystem.SpaceObjects.OfType<Planet>().ToList();

                Assert.AreEqual(7, planets.Count);

                var i = 0;

                foreach (var planet in planets)
                {
                    Assert.IsNull(planet.ContainingSubSystem);
                    Assert.AreEqual("Random name " + ++i, planet.Name);
                }
            }
        }
    }
}