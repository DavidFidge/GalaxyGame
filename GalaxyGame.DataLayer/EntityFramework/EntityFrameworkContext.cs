using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GalaxyGame.Core.Interfaces;
using GalaxyGame.DataLayer.Interfaces;

namespace GalaxyGame.DataLayer.EntityFramework
{
    public class EntityFrameworkContext : IContext
    {
        protected BaseContext _context;

        protected DbContextTransaction _dbContextTransaction;
        protected bool _hasCommitted;

        public EntityFrameworkContext(IDatabaseConfiguration databaseConfiguration)
        {
            _context = new BaseContext(databaseConfiguration.DatabaseName);
        }

        public IDbSet<T> DbSet<T>() where T : class, IEntity
        {
            return _context.Set<T>();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_dbContextTransaction != null)
            {
                if (!_hasCommitted)
                    _dbContextTransaction.Rollback();

                _dbContextTransaction.Dispose();
                _dbContextTransaction = null;
            }

            _context.Dispose();
            _context = null;
        }

        public void BeginTransaction()
        {
            _dbContextTransaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _dbContextTransaction.Commit();
            _hasCommitted = true;
        }
    }
}