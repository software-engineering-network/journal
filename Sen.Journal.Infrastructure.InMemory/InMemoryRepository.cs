﻿using System;
using System.Collections.Generic;
using System.Linq;
using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Infrastructure.InMemory
{
    public abstract class InMemoryRepository<T> : IRepository<T> where T : Entity
    {
        #region Fields

        protected readonly ICurrentUserProvider _currentUserProvider;
        protected readonly List<T> _entities;

        #endregion

        #region Construction

        protected InMemoryRepository(ICurrentUserProvider currentUserProvider)
        {
            _currentUserProvider = currentUserProvider;
            _entities = new List<T>();
        }

        #endregion

        #region IRepository<T> Members

        public abstract T Create(T entity);

        public bool Exists(Func<T, bool> predicate)
        {
            try
            {
                var existingEntity = _entities.First(predicate);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<T> Fetch()
        {
            return _entities;
        }

        public virtual T Find(Id id)
        {
            return _entities.Find(x => x.Id == id);
        }

        public T FirstOrDefault(Func<T, bool> predicate)
        {
            return _entities.FirstOrDefault(predicate);
        }

        public IEnumerable<T> Fetch(Func<T, bool> predicate)
        {
            return _entities.Where(predicate);
        }

        public virtual T Update(T entity)
        {
            var storedEntity = _entities.Find(x => x.Id == entity.Id);

            var currentUser = _currentUserProvider.GetCurrentUser();
            storedEntity.SetModifiedInfo((UserId) currentUser.Id);

            return Find(entity.Id);
        }

        #endregion

        public IEnumerable<RecordName> WithMatchingRecordNames(RecordName recordName)
        {
            return Fetch(x => x.RecordName.Value.StartsWith(recordName.Value))
                .Select(x => x.RecordName);
        }

        protected ulong NextId(IEnumerable<T> persons)
        {
            var maxId = _entities.Count == 0
                ? 0
                : persons.Select(x => x.Id.Value).Max();

            return ++maxId;
        }
    }
}
