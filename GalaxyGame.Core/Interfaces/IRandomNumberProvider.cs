using System;
using System.Collections.Generic;
using System.Linq;

namespace GalaxyGame.Core.Interfaces
{
    public interface IRandomNumberProvider
    {
        // Returns a number between min (inclusive) and max (exclusive)
        int Rand(int min, int max);

        long Rand(long min, long max);

        // Returns a double between 0.0 and 1.0
        double Rand();
    }
}