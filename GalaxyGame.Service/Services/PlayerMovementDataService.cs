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
    public class PlayerMovementDataService : BaseService, IPlayerMovementDataService
    {
        private IUnitOfWorkFactory _unitOfWorkFactory;

        public PlayerMovementDataService(IUnitOfWorkFactory unitOfWorkFactory)
            : base(unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public bool MoveTo(Guid playerId, Vector3 destination)
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                var player = uow.Context.DbSet<Player>().First(p => p.Id == playerId);

                player.SystemPosition.Destination = destination;

                uow.Commit();
            }

            return true;
        }
    }
}