using System;
using System.Collections.Generic;
using System.Linq;

namespace GalaxyGame.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IContext Context { get; }
        void Commit(); 
    }
}