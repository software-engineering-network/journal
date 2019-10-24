using System;
using System.Collections.Generic;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public interface IRepository<T>
    {
        T Create(T entity);
        bool Exists(Func<T, bool> predicate);
        T Find(Id id);
        T FirstOrDefault(Func<T, bool> predicate);
        IEnumerable<T> Fetch(Func<T, bool> predicate);
        T Update(T entity);
    }
}
