using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace GalaxyGame.DataLayer
{
    public interface IUnitOfWork : IDisposable
    {
        IContext Context { get; }
        void Save();
    }
}