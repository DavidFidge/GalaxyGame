using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityFortuneVoronoi.Interfaces
{
    public interface IVisitor<T>
    {
        void Visit(T edge);
    }
}