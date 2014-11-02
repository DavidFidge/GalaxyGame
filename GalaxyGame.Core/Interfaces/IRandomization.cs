using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GalaxyGame.Core.Interfaces
{
    public interface IRandomization : IRandomNumberProvider
    {
        IEnumerable<int> RandomList(int from, int to);
        void RandomizeList<T>(List<T> list);
    }
}