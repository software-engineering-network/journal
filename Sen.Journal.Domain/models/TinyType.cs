using System;
using System.Collections.Generic;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public abstract class TinyType<T> : IEquatable<TinyType<T>>
    {
        public T Value { get; }

        protected TinyType(T value)
        {
            Value = value;
        }

        #region IEquatable<TinyType<T>>

        public bool Equals(TinyType<T> other)
        {
            if (ReferenceEquals(null, other))
                return false;

            // reference equality
            if (ReferenceEquals(this, other))
                return true;

            // wrapped type equality
            return EqualityComparer<T>.Default.Equals(Value, other.Value);
        }

        #endregion

        #region Operators

        public static bool operator ==(TinyType<T> left, TinyType<T> right)
        {
            if (left is null && right is null)
                return true;

            if (left is null || right is null)
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(TinyType<T> left, TinyType<T> right)
        {
            return !(left == right);
        }

        #endregion

        #region System.Object

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            // reference equality
            if (ReferenceEquals(this, other))
                return true;

            // tiny type to wrapped type equality
            if (other.GetType() == Value.GetType())
                return Value.Equals(other);

            // tiny type equality
            if (other.GetType() == GetType())
                return Equals((TinyType<T>) other);

            // ¯\_(ツ)_/¯
            return false;
        }

        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode(Value);
        }

        #endregion
    }
}
