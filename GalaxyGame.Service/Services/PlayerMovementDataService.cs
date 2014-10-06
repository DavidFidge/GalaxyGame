using System;
using System.Collections.Generic;
using System.Linq;
using GalaxyGame.Core.Interfaces;
using GalaxyGame.Core.Service;
using GalaxyGame.Service.Interfaces;

namespace GalaxyGame.Service.Services
{
    public class PlayerMovementDataService : BaseService, IPlayerMovementDataService
    {
        public PlayerMovementDataService(IUnitOfWorkFactory unitOfWorkFactory)
            : base(unitOfWorkFactory)
        {
        }
    }
}