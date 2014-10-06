using GalaxyGame.Core.Interfaces;

namespace GalaxyGame.DataLayer.Components
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