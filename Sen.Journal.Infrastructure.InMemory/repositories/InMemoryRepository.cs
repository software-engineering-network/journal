using System;
using System.Collections.Generic;
using System.Linq;
using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Infrastructure.InMemory
{
    public abstract class InMemoryRepository<T> : IRepository<T> where T : Entity
    {
        #region Fields

        private readonly ICurrentUserProvider _currentUserProvider;

        #endregion

        #region Properties

        protected Context Context { get; }
        protected Func<List<T>> GetEntities { get; set; }
        protected List<T> Entities => GetEntities.Invoke();

        #endregion

        #region Construction

        protected InMemoryRepository(
            Context context,
            ICurrentUserProvider currentUserProvider
        )
        {
            Context = context;
            _currentUserProvider = currentUserProvider;
        }

        #endregion

        #region IRepository<T> Members

        public T Create(T entity)
        {
            var currentUser = _currentUserProvider.GetCurrentUser();
            entity.Id = new Id(NextId(Entities));
            entity.SetCreatedInfo((UserId) currentUser.Id);

            Entities.Add(entity);

            return entity;
        }

        public bool Exists(Func<T, bool> predicate)
        {
            try
            {
                var existingEntity = Entities.First(predicate);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<T> Fetch()
        {
            return Entities;
        }

        public virtual T Find(Id id)
        {
            return Entities.Find(x => x.Id == id);
        }

        public T FirstOrDefault(Func<T, bool> predicate)
        {
            return Entities.FirstOrDefault(predicate);
        }

        public IEnumerable<T> Fetch(Func<T, bool> predicate)
        {
            return Entities.Where(predicate);
        }

        public virtual T Update(T entity)
        {
            var storedEntity = Entities.Find(x => x.Id == entity.Id);

            var currentUser = _currentUserProvider.GetCurrentUser();
            storedEntity.SetModifiedInfo((UserId) currentUser.Id);

            return Find(entity.Id);
        }

        #endregion

        protected ulong NextId(List<T> entities)
        {
            var maxId = entities.Count == 0
                ? 0
                : entities.Select(x => x.Id.Value).Max();

            return ++maxId;
        }
    }
}
