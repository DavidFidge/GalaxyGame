using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace GalaxyGame.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IContext Context { get; }
        void Commit();
        int CommittedNestLevel { get; set; }
    }
}