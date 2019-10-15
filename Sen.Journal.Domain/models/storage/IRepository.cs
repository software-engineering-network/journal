namespace Sen.Journal.Domain
{
    public interface IRepository<T>
    {
        T Create(T entity);
    }
}
