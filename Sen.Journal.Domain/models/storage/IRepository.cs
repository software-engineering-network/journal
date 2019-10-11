namespace Sen.Journal.Domain.storage
{
    public interface IRepository<T>
    {
        T Create(T entity);
    }
}
