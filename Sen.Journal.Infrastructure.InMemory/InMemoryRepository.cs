using System.Collections.Generic;
using System.Linq;
using Sen.Journal.Domain;

namespace Sen.Journal.Infrastructure.InMemory
{
    public abstract class InMemoryRepository<T> : IRepository<T> where T : Entity
    {
        public List<T> Entities { get; }

        protected InMemoryRepository()
        {
            Entities = new List<T>();
        }

        public abstract T Create(T entity);

        protected Id NextId(IEnumerable<T> persons)
        {
            var maxId = Entities.Count == 0
                ? 0
                : persons.Select(x => x.Id.Value).Max();

            return new Id(++maxId);
        }
    }
}
