using System;
using System.Collections.Generic;
using System.Linq;

namespace GalaxyGame.Core.Interfaces
{
    public interface IUnitOfWorkFactory : IDisposable
    {
        IUnitOfWork Create();
    }
}