namespace Sen.Journal.Domain
{
    public interface IRepository<T>
    {
        T Create(T entity);
        T Find(Id id);
        T Update(T entity);
    }
}
