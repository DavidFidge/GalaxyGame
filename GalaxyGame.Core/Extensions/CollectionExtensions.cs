using System;
using System.Collections.Generic;
using System.Linq;

namespace GalaxyGame.Core.Extensions
{
    public static class CollectionExtensions
    {
        public static T RandomItem<T>(this ICollection<T> list)
        {
            if (list == null)
                throw new ArgumentNullException();
            if (!list.Any())
                throw new ArgumentOutOfRangeException("Must have at least 1 item in list");
            if (list.Count() == 1)
                return list.First();

            var rand = new Random();

            return list.ElementAt(rand.Next(0, list.Count() + 1));
        }
    }
}