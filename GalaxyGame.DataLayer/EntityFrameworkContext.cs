using System.Data.Entity;
using GalaxyGame.Model.Space;

namespace GalaxyGame.DataLayer
{
    public class EntityFrameworkContext : IContext
    {
        private BaseContext _context;

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
            if (_context != null)
                _context.Dispose();
        }
    }
}