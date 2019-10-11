using System.Collections.Generic;
using System.Linq;
using Sen.Journal.Domain;
using Sen.Journal.Domain.storage;

namespace Sen.Journal.Infrastructure.InMemory
{
    public abstract class InMemoryRepository<T> : IRepository<T>
    {
        public List<T> Entities { get; }

        protected InMemoryRepository()
        {
            Entities = new List<T>();
        }

        public abstract T Create(T entity);

        protected ulong NextId(IEnumerable<Person> persons)
        {
            var maxId = Entities.Count == 0
                ? 0
                : persons.Select(x => x.Id.Value).Max();

            return ++maxId;
        }
    }
}
