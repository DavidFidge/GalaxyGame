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
        public GalaxyDataService(IUnitOfWorkFactory unitOfWorkFactory)
            : base(unitOfWorkFactory)
        {
        }

        public void CreateGalaxy()
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                if (!uow.Context.DbSet<Galaxy>().Any())
                {
                    var galaxy = new Galaxy
                    {
                        Name = "Test Galaxy"
                    };

                    var galaxySector = AddGalaxySector(galaxy);

                    uow.Context.DbSet<Galaxy>().Add(galaxy);
                }
            }
        }

        public GalaxySector AddGalaxySector(Galaxy galaxy)
        {
            var galaxySector = new GalaxySector
            {
                Name = "A1",
                Galaxy = galaxy,
            };

            LinkNewGalaxyToAnyGalaxySector(galaxySector);

            galaxy.GalaxySectors.Add(galaxySector);

            return galaxySector;
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

        public void AddGalaxySector(GalaxySector galaxySector)
        {
        }

        public GalaxySectorLinkType GetLinkTypeForNewGalaxySectorLink(GalaxySector galaxySector)
        {
            var sectorLinkTypes = Enum.GetValues(typeof (GalaxySectorLinkType)).OfType<GalaxySectorLinkType>().ToList();

            galaxySector.SectorLinks.ForEach(gs => sectorLinkTypes.Remove(gs.LinkType));

            return sectorLinkTypes.RandomItem();
        }
    }
}