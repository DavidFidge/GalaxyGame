using System;
using System.Data.Entity;
using GalaxyGame.Core.Interfaces;

namespace GalaxyGame.DataLayer.EntityFramework
{
    public class EntityFrameworkContext : IContext
    {
        private BaseContext _context;

        private DbContextTransaction _dbContextTransaction;
        private bool _hasCommitted = false;

        public IDbSet<T> DbSet<T>() where T : class, IEntity
        {
            var context = _context ?? new BaseContext();
            _context = context;

            return context.Set<T>();
        }

        public void Save()
        {
            if (_context != null)
                _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_dbContextTransaction != null)
            {
                if (!_hasCommitted)
                    _dbContextTransaction.Rollback();

                _dbContextTransaction.Dispose();
            }
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void BeginTransaction()
        {
            if (_context != null)
                _dbContextTransaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (_context != null)
            {
                _dbContextTransaction.Commit();
                _hasCommitted = true;
            }
        }
    }
}