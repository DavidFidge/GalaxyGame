using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using GalaxyGame.Core.Interfaces;
using NSubstitute;

namespace GalaxyGame.Core.TestInfrastructure
{
    public static class ContextExtensions
    {
        public static IContext Mock<T>(this IContext context, ICollection<T> items) where T : class, IEntity, new()
        {
            var dbset = new FakeDbSet<T>(items);

            var collection = context.DbSet<T>();

            if (collection == null)
                context.DbSet<T>().Returns(dbset);
            else
                items.ForEach(i => collection.Add(i));

            return context;
        }
    }
}