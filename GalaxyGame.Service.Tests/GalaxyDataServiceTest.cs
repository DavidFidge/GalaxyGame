using System;
using System.Collections.Generic;
using System.Linq;
using GalaxyGame.Core.Interfaces;
using GalaxyGame.Core.TestInfrastructure;
using GalaxyGame.Model.Space;
using GalaxyGame.Service.Interfaces;
using GalaxyGame.Service.Services;
using NSubstitute;
using NUnit.Framework;

namespace GalaxyGame.Service.Tests
{
    [TestFixture]
    public class GalaxyDataServiceTest : BaseUnitTest
    {
        private GalaxyDataService _galaxyDataService;
        private IDictionaryDataService _dictionaryDataService;
        private ISystemDataService _systemDataService;
        private IRandomization _randomization;

        [SetUp]
        public override void Setup()
        {
            base.Setup();

            _dictionaryDataService = Substitute.For<IDictionaryDataService>();
            _dictionaryDataService.GetRandomLatinName(Arg.Any<int>()).Returns("Random name");

            _randomization = Substitute.For<IRandomization>();
            _randomization.Rand(Arg.Any<int>(), Arg.Any<int>()).Returns(1);

            _systemDataService = Substitute.For<ISystemDataService>();

            _galaxyDataService = new GalaxyDataService(
                _unitOfWorkFactory,
                _dictionaryDataService,
                _systemDataService,
                _randomization);
        }

        [Test]
        public void Test_Create_Galaxy_Successful()
        {
            // Act
            _galaxyDataService.CreateGalaxy();

            // Assert
            Assert.AreEqual(_context.DbSet<Galaxy>().Count(), 1);

            var galaxy = _context.DbSet<Galaxy>().First();

            Assert.AreEqual("Random name", galaxy.Name);

            Assert.AreEqual(1, galaxy.GalaxySectors.Count);

            var galaxySector = galaxy.GalaxySectors.First();

            Assert.AreEqual(galaxy, galaxySector.Galaxy);
            Assert.AreEqual("Random name", galaxySector.Name);
            Assert.NotNull(galaxySector.Exploration);
        }
    }
}