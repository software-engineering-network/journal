using System;
using System.Collections.Generic;

namespace Sen.Journal.Domain
{
    public abstract class TinyType<T> : IEquatable<TinyType<T>>
    {
        public T Value { get; }

        protected TinyType(T value)
        {
            Value = value;
        }

        public bool Equals(TinyType<T> other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (Value.Equals(other.Value))
                return true;

            return EqualityComparer<T>.Default.Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((TinyType<T>) obj);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode(Value);
        }

        public static bool operator ==(TinyType<T> left, TinyType<T> right)
        {
            if (left is null && right is null)
                return true;

            if (left is null || right is null)
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(TinyType<T> left, TinyType<T> right) => !(left == right);
    }
}
