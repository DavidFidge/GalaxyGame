using System;
using GalaxyGame.Model.Unity;

namespace GalaxyGame.Service.Interfaces
{
    public interface IPlayerMovementDataService
    {
        bool MoveTo(Guid playerId, Vector3 destination);
    }
}
