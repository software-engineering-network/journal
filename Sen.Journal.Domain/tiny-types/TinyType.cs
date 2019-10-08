namespace Sen.Journal.Domain
{
    public abstract class TinyType<T>
    {
        public T Value { get; }

        protected TinyType(T value)
        {
            Value = value;
        }
    }
}
