using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UnityFortuneVoronoi.Interfaces
{
    public interface IPriorityQueue : ICloneable, IList
    {
        int Push(object O);
        object Pop();
        object Peek();
        void Update(int i);
    }
}