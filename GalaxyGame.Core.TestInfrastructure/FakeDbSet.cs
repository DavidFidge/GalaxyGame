using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Castle.Core.Internal;
using GalaxyGame.Core.Interfaces;

namespace GalaxyGame.Core.TestInfrastructure
{
    public class FakeDbSet<T> : IDbSet<T> where T : class, IEntity
    {
        private readonly ICollection<T> _list;

        public FakeDbSet(ICollection<T> list)
        {
            _list = list ?? new List<T>();
        }

        public T Add(T entity)
        {
            _list.Add(entity);

            return entity;
        }

        public T Attach(T entity)
        {
            _list.Add(entity);

            return entity;
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            return typeof(T).CreateInstance<T>() as TDerivedEntity;
        }

        public T Create()
        {
            return typeof(T).CreateInstance<T>();
        }

        public T Find(params object[] keyValues)
        {
            return _list.FirstOrDefault(l => keyValues.Any(kv => (Guid) kv == l.Id));
        }

        public ObservableCollection<T> Local
        {
            get { return new ObservableCollection<T>(_list); }
        }

        public T Remove(T entity)
        {
            _list.Remove(entity);

            return entity;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public Type ElementType
        {
            get { return _list.AsQueryable().ElementType; }
        }

        public Expression Expression
        {
            get { return _list.AsQueryable().Expression; }
        }

        public IQueryProvider Provider
        {
            get { return _list.AsQueryable().Provider; }
        }
    }
}