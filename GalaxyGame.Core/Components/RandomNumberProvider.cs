using System;
using System.Collections.Generic;
using System.Linq;
using GalaxyGame.Core.Interfaces;

namespace GalaxyGame.Core.Components
{
    public class RandomNumberProvider : IRandomNumberProvider
    {
        private readonly Random _random;

        public RandomNumberProvider()
        {
            _random = new Random();
        }

        public int Rand(int min, int max)
        {
            return _random.Next(min, max + 1);
        }

        public double Rand()
        {
            return _random.NextDouble();
        }

        public long Rand(long min, long max)
        {
            var bytes = new byte[sizeof(long)];
            _random.NextBytes(bytes);
            return BitConverter.ToInt64(bytes, 0);
        }
    }
}