using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using GalaxyGame.Core.Extensions;
using GalaxyGame.Core.Interfaces;
using GalaxyGame.Core.Service;
using GalaxyGame.Model.Extensions;
using GalaxyGame.Model.Interfaces;
using GalaxyGame.Model.Space;
using GalaxyGame.Model.Unity;
using GalaxyGame.Service.Interfaces;

namespace GalaxyGame.Service.Services
{
    public class SystemDataService : BaseService, ISystemDataService
    {
        private readonly ISystemSettings _systemSettings;
        private readonly IRandomization _randomization;
        private readonly IDictionaryDataService _dictionaryDataService;
        private readonly IDateTimeProvider _dateTimeProvider;

        public SystemDataService(
            IUnitOfWorkFactory unitOfWorkFactory, 
            ISystemSettings systemSettings,
            IRandomization randomization,
            IDictionaryDataService dictionaryDataService,
            IDateTimeProvider dateTimeProvider)
            : base(unitOfWorkFactory)
        {
            _systemSettings = systemSettings;
            _randomization = randomization;
            _dictionaryDataService = dictionaryDataService;
            _dateTimeProvider = dateTimeProvider;
        }

        public void CreateSystemsForGalaxySector(GalaxySector galaxySector)
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                var numberOfSolarSystems = _randomization.Rand(_systemSettings.MinSolarSystemsInGalaxySector, _systemSettings.MaxSolarSystemsInGalaxySector + 1);

                for (int i = 0; i < numberOfSolarSystems; i++)
                {
                    CreateSolarSystem(galaxySector);
                }
            }
        }

        private SolarSystem CreateSolarSystem(GalaxySector galaxySector)
        {
            var solarSystem = new SolarSystem();

            solarSystem.GalaxySector = galaxySector;
            solarSystem.Name = _dictionaryDataService.GetRandomLatinName(1);

            solarSystem.SystemLocation.X = (float)_randomization.Rand();
            solarSystem.SystemLocation.Y = (float)_randomization.Rand();

            CreateSpaceObjects(solarSystem);

            return solarSystem;
        }

        private void CreateSpaceObjects(SolarSystem solarSystem)
        {
            var star = new Star()
            {
                Name = solarSystem.Name,
                SolarSystem = solarSystem,
                SolarSystemId = solarSystem.Id,
            };

            solarSystem.SpaceObjects.Add(star);

            var numPlanets = _randomization.Rand(_systemSettings.MinPlanetsInSystem, _systemSettings.MaxPlanetsInSystem + 1);

            for (int i = 0; i < numPlanets; i++)
            {
                var planet = MakePlanet(solarSystem, solarSystem, string.Format("{0} {1}", solarSystem.Name, i));

                planet.SystemPosition.OrbitOriginTime = _dateTimeProvider.Now;
                planet.SystemPosition.Speed = _randomization.Rand();

                planet.FractalSeed = _randomization.Rand();
            }

        }

        private Planet MakePlanet(SolarSystem solarSystem, IHasSpaceObjects spaceObjectsSource, string name)
        {
            var planet = new Planet()
            {
                Name = name
            };

            while (planet.Colour1 == null || planet.Colour1 == Color.Black)
            {
                planet.Colour1 = new Color()
                {
                    R = (float) _randomization.Rand(),
                    G = (float) _randomization.Rand(),
                    B = (float) _randomization.Rand()
                };
            }

            if (_randomization.Rand(0, 2) == 0)
            {
                planet.Colour2 = new Color()
                {
                    R = (float) _randomization.Rand(),
                    G = (float) _randomization.Rand(),
                    B = (float) _randomization.Rand()
                };
            }

            if (_randomization.Rand(0, 2) == 0)
            {
                var whitishColour = ((float)_randomization.Rand()/2.0f) + 0.5f;
                planet.PolarColour = new Color()
                {
                    R = whitishColour,
                    G = whitishColour,
                    B = whitishColour
                };
            }

            planet.SolarSystem = solarSystem;
            spaceObjectsSource.SpaceObjects.Add(planet);

            return planet;
        }
    }
}