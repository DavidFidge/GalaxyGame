using System;
using System.Collections.Generic;
using System.Linq;
using GalaxyGame.Core.Interfaces;

namespace GalaxyGame.Core.Service
{
    public class BaseService : IDisposable
    {
        protected readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public BaseService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Dispose()
        {
            _unitOfWorkFactory.Dispose();
        }
    }
}