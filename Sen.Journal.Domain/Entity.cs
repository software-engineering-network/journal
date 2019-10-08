namespace Sen.Journal.Domain
{
    public abstract class Entity
    {
        public Id Id { get; }

        protected Entity(Id id)
        {
            Id = id;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Entity;

            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            var unsetId = new Id(0);
            if (Id == unsetId || other.Id == unsetId)
                return false;

            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return (Id != null ? Id.GetHashCode() : 0);
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (left is null && right is null)
                return true;

            if (left is null || right is null)
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right) => !(left == right);
    }
}