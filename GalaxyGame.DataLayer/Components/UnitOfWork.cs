using GalaxyGame.Core.Interfaces;

namespace GalaxyGame.DataLayer.Components
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IContext _context;
        public int CommittedNestLevel { get; set; }

        public IContext Context
        {
            get { return _context; }
        }

        public UnitOfWork(IContext context)
        {
            CommittedNestLevel = 1;
            _context = context;

            _context.BeginTransaction();
        }

        public void Commit()
        {
            CommittedNestLevel--;

            if (CommittedNestLevel == 0)
            {
                Context.Save();
                Context.Commit();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}