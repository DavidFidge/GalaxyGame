using GalaxyGame.Core.Interfaces;

namespace GalaxyGame.DataLayer.Components
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private IUnitOfWork _unitOfWork;
        private readonly IUnitOfWorkInnerFactory _innerFactory;

        public UnitOfWorkFactory(IUnitOfWorkInnerFactory innerFactory)
        {
            _innerFactory = innerFactory;
        }

        public IUnitOfWork Create()
        {
            if (_unitOfWork == null)
                _unitOfWork = _innerFactory.Create();

            else
                _unitOfWork.CommittedNestLevel++;

            return _unitOfWork;
        }

        public void Dispose()
        {
            _unitOfWork.Commit();

            _innerFactory.Release(_unitOfWork);
        }
    }
}