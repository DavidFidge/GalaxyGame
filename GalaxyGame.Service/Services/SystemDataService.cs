using System;
using System.Collections.Generic;
using System.Linq;
using GalaxyGame.Core.Interfaces;
using GalaxyGame.Core.Service;
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
            var uow = _unitOfWorkFactory.Create();

            var numberOfSolarSystems = _randomization.Rand(_systemSettings.MinSolarSystemsInGalaxySector, _systemSettings.MaxSolarSystemsInGalaxySector);

            for (int i = 0; i < numberOfSolarSystems; i++)
            {
                CreateSolarSystem(galaxySector);
            }

            _unitOfWorkFactory.Release();
        }

        private void CreateSolarSystem(GalaxySector galaxySector)
        {
            var solarSystem = new SolarSystem();

            solarSystem.GalaxySector = galaxySector;
            solarSystem.Name = _dictionaryDataService.GetRandomLatinName(_randomization.Rand(1, 2));

            solarSystem.SystemLocation.X = (float) _randomization.Rand();
            solarSystem.SystemLocation.Y = (float) _randomization.Rand();

            solarSystem.SubSystem = new SubSystem();

            CreateSpaceObjects(solarSystem);

            galaxySector.SolarSystems.Add(solarSystem);
        }

        private void CreateSpaceObjects(SolarSystem solarSystem)
        {
            var star = new Star
            {
                Name = solarSystem.Name,
                SolarSystem = solarSystem,
                ContainingSubSystem = solarSystem.SubSystem
            };

            star.ContainingSubSystem.SpaceObjects.Add(star);

            var numPlanets = _randomization.Rand(_systemSettings.MinPlanetsInSystem, _systemSettings.MaxPlanetsInSystem);

            for (int i = 0; i < numPlanets; i++)
            {
                float orbitInterval = (1.0f / numPlanets);
                float orbitInnerBracket = orbitInterval * i;

                MakePlanet(solarSystem, star.ContainingSubSystem, string.Format("{0} {1}", solarSystem.Name, i + 1), orbitInterval, orbitInnerBracket);
            }
        }

        private void MakePlanet(SolarSystem solarSystem, SubSystem subSystem, string name, float orbitExtension, float orbitInnerBracket)
        {
            var planet = new Planet
            {
                Name = name
            };

            while (planet.Colour1 == null || planet.Colour1 == Color.Black)
            {
                planet.Colour1 = new Color
                {
                    R = (float) _randomization.Rand(),
                    G = (float) _randomization.Rand(),
                    B = (float) _randomization.Rand()
                };
            }

            if (_randomization.Rand(1) == 0)
            {
                planet.Colour2 = new Color
                {
                    R = (float) _randomization.Rand(),
                    G = (float) _randomization.Rand(),
                    B = (float) _randomization.Rand()
                };
            }

            if (_randomization.Rand(1) == 0)
            {
                var whitishColour = ((float) _randomization.Rand() / 2.0f) + 0.5f;
                planet.PolarColour = new Color
                {
                    R = whitishColour,
                    G = whitishColour,
                    B = whitishColour
                };
            }

            planet.FractalSeed = _randomization.Rand();

            planet.SystemPosition.OrbitOriginTime = _dateTimeProvider.Now;
            planet.SystemPosition.OrbitTranslation.X = ((float) _randomization.Rand() * orbitExtension) + orbitInnerBracket;
            planet.SystemPosition.OrbitTranslation.Y = ((float) _randomization.Rand() * orbitExtension) + orbitInnerBracket;

            planet.SystemPosition.Scale = new Vector3((float) _randomization.Rand() * 9.5f + 0.5f);
            planet.SystemPosition.Speed = (float) _randomization.Rand();

            planet.SystemPosition.AxisRotation = new Vector3(
                (float) _randomization.Rand(),
                (float) _randomization.Rand(),
                (float) _randomization.Rand());

            planet.SystemPosition.Rotation = new Vector3(
                (float) _randomization.Rand(),
                0,
                0);

            planet.SolarSystem = solarSystem;
            planet.SubSystem = subSystem;
            subSystem.SpaceObjects.Add(planet);
        }
    }
}