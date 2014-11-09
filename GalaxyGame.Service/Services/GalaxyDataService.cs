using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using GalaxyGame.Core.Extensions;
using GalaxyGame.Core.Interfaces;
using GalaxyGame.Core.Service;
using GalaxyGame.Model.Extensions;
using GalaxyGame.Model.Space;
using GalaxyGame.Service.Interfaces;

namespace GalaxyGame.Service.Services
{
    public class GalaxyDataService : BaseService, IGalaxyDataService
    {
        private readonly IDictionaryDataService _dictionaryDataService;
        private readonly ISystemDataService _systemDataService;
        private readonly IRandomization _randomization;

        public GalaxyDataService(
            IUnitOfWorkFactory unitOfWorkFactory,
            IDictionaryDataService dictionaryDataService,
            ISystemDataService systemDataService,
            IRandomization randomization)
            : base(unitOfWorkFactory)
        {
            _dictionaryDataService = dictionaryDataService;
            _systemDataService = systemDataService;
            _randomization = randomization;
        }

        public void CreateGalaxy()
        {
            var uow = _unitOfWorkFactory.Create();

            if (!uow.Context.DbSet<Galaxy>().Any())
            {
                var galaxy = new Galaxy
                {
                    Name = _dictionaryDataService.GetRandomLatinName(_randomization.Rand(1, 2))
                };

                AddGalaxySector(galaxy);

                uow.Context.DbSet<Galaxy>().Add(galaxy);
            }

            _unitOfWorkFactory.Release();
        }

        public void AddGalaxySector(Galaxy galaxy)
        {
            var galaxySector = new GalaxySector
            {
                Name = _dictionaryDataService.GetRandomLatinName(_randomization.Rand(1, 2)),
                Galaxy = galaxy,
            };

            _systemDataService.CreateSystemsForGalaxySector(galaxySector);

            LinkNewGalaxyToAnyGalaxySector(galaxySector);

            galaxy.GalaxySectors.Add(galaxySector);
        }

        private void LinkNewGalaxyToAnyGalaxySector(GalaxySector newGalaxySector)
        {
            var linkedSector = newGalaxySector.Galaxy.GalaxySectors.OrderBy(gs => gs.SectorLinks.Count).FirstOrDefault(gs => gs.SectorLinks.Count < 4);

            if (linkedSector != null)
            {
                LinkSectorsBothWays(linkedSector, newGalaxySector, GetLinkTypeForNewGalaxySectorLink(linkedSector));
            }
        }

        public void LinkSectorsBothWays(GalaxySector from, GalaxySector to, GalaxySectorLinkType linkType)
        {
            var sectorLink = new GalaxySectorLink
            {
                LinkType = linkType,
                SectorFrom = from,
                SectorTo = to
            };

            from.SectorLinks.Add(sectorLink);

            var newSectorLink = new GalaxySectorLink
            {
                LinkType = linkType.OppositeDirection(),
                SectorTo = from,
                SectorFrom = to
            };

            to.SectorLinks.Add(newSectorLink);
        }

        public GalaxySectorLinkType GetLinkTypeForNewGalaxySectorLink(GalaxySector galaxySector)
        {
            var sectorLinkTypes = Enum.GetValues(typeof(GalaxySectorLinkType)).OfType<GalaxySectorLinkType>().ToList();

            galaxySector.SectorLinks.ForEach(gs => sectorLinkTypes.Remove(gs.LinkType));

            return sectorLinkTypes.RandomItem();
        }
    }
}