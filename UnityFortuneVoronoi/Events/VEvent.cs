using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityFortuneVoronoi
{
    internal abstract class VEvent : IComparable
    {
        public abstract double Y { get; }
        public abstract double X { get; }

        public int CompareTo(object obj)
        {
            if (!(obj is VEvent))
                throw new ArgumentException("obj not VEvent!");
            var i = Y.CompareTo(((VEvent) obj).Y);
            if (i != 0)
                return i;
            return X.CompareTo(((VEvent) obj).X);
        }
    }
}