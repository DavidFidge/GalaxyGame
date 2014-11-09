using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Release()
        {
            _unitOfWork.Commit();

            if (_unitOfWork.CommittedNestLevel == 0)
            {
                // This will call dispose
                _innerFactory.Release(_unitOfWork);
                _unitOfWork = null;
            }
        }

        public void Dispose()
        {
            if (_unitOfWork != null)
            {
                // This will call dispose
                _innerFactory.Release(_unitOfWork);
                _unitOfWork = null;
            }
        }
    }
}