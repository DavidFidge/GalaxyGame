using System;
using System.Collections.Generic;
using System.Linq;

namespace GalaxyGame.Core.Interfaces
{
    public interface IUnitOfWorkInnerFactory : IDisposable
    {
        IUnitOfWork Create();

        // There's no need to call this explicitly as long as you dispose the factory
        // http://docs.castleproject.org/Windsor.Typed-Factory-Facility-interface-based-factories.ashx?HL=asfactory
        void Release(IUnitOfWork unitOfWork);
    }
}