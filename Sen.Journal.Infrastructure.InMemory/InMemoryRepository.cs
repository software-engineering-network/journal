using System.Collections.Generic;
using System.Linq;
using Sen.Journal.Domain;

namespace Sen.Journal.Infrastructure.InMemory
{
    public abstract class InMemoryRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly ICurrentUserProvider _currentUserProvider;
        protected readonly List<T> _entities;

        protected InMemoryRepository(ICurrentUserProvider currentUserProvider)
        {
            _currentUserProvider = currentUserProvider;
            _entities = new List<T>();
        }

        public abstract T Create(T entity);

        public virtual T Find(Id id)
        {
            return _entities.Find(x => x.Id == id);
        }

        public virtual T Update(T entity)
        {
            var storedEntity = _entities.Find(x => x.Id == entity.Id);

            var currentUser = _currentUserProvider.GetCurrentUser();
            storedEntity.Modify(currentUser);

            return Find(entity.Id);
        }

        protected Id NextId(IEnumerable<T> persons)
        {
            var maxId = _entities.Count == 0
                ? 0
                : persons.Select(x => x.Id.Value).Max();

            return new Id(++maxId);
        }
    }
}
