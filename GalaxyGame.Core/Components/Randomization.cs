using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using GalaxyGame.Core.Interfaces;

namespace GalaxyGame.Core.Components
{
    public class Randomization : IRandomization, IRandomNumberProvider
    {
        private readonly IRandomNumberProvider _randomNumberProvider;

        public Randomization(IRandomNumberProvider randomNumberProvider)
        {
            _randomNumberProvider = randomNumberProvider;
        }

        public int Rand(int min, int max)
        {
            return _randomNumberProvider.Rand(min, max);
        }

        public long Rand(long min, long max)
        {
            return _randomNumberProvider.Rand(min, max);
        }

        public double Rand()
        {
            return _randomNumberProvider.Rand();
        }

        public IEnumerable<int> RandomList(int from, int to)
        {
            var intlist = new List<int>(to - from + 1);

            for (var i = from; i <= to; i++)
            {
                intlist.Add(i);
            }

            while (intlist.Count > 0)
            {
                int index = Rand(0, intlist.Count);
                yield return intlist[index];
                intlist.RemoveAt(index);
            }
        }

        /// <summary>
        ///     this class randomises a set of objects inside a provided list
        /// </summary>
        public void RandomizeList<T>(List<T> list)
        {
            var templist = new List<T>(list.Count);

            templist.AddRange(list);

            var i = 0;

            RandomList(0, templist.Count - 1).ForEach(item =>
            {
                list[i] = templist[item];
                i++;
            });
        }
    }
}