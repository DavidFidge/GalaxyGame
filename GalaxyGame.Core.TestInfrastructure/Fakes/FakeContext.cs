using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GalaxyGame.Core.Interfaces;

namespace GalaxyGame.Core.TestInfrastructure.Fakes
{
    public class FakeContext : IContext
    {
        private readonly Dictionary<Type, object> _collection;

        public FakeContext()
        {
            _collection = new Dictionary<Type, object>();
        }

        public void BeginTransaction()
        {
        }

        public void Commit()
        {
        }

        public IDbSet<T> DbSet<T>() where T : class, IEntity
        {
            if (_collection.ContainsKey(typeof(T)))
                return _collection[typeof(T)] as IDbSet<T>;

            var list = new List<T>();

            var fakeSet = new FakeDbSet<T>(list);

            _collection[typeof(T)] = fakeSet;

            return fakeSet;
        }

        public void Save()
        {
        }

        public void Dispose()
        {
        }
    }
}