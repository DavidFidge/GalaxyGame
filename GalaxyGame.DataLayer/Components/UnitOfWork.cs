using System;
using GalaxyGame.Model;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace GalaxyGame.DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IContext _context;

        public IContext Context
        {
            get { return _context; }
        }

        public UnitOfWork(IContext context)
        {
            _context = context;
        }

        public void Save()
        {
            Context.Save();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}