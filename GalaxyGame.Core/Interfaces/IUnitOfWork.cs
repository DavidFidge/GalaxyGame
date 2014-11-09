using System;
using System.Collections.Generic;
using System.Linq;

namespace GalaxyGame.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IContext Context { get; }
        void Commit();
        int CommittedNestLevel { get; set; }
    }
}