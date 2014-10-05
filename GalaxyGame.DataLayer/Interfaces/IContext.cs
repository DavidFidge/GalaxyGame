using System;
using System.Data.Entity;
using GalaxyGame.Model.Space;

namespace GalaxyGame.DataLayer
{
    public interface IContext : IDisposable
    {
        IDbSet<T> DbSet<T>() where T : class, IEntity;
        void Save();
    }
}