using System;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public abstract class Entity : IAuditable
    {
        private readonly IAuditable _auditable;

        public Id Id { get; }
        public RecordName RecordName { get; protected set; }

        protected Entity()
        {
        }

        protected Entity(Id id)
        {
            Id = id;

            var dateTimeProvider = new BasicDateTimeProvider();
            _auditable = new Auditable(dateTimeProvider);
        }

        #region Operators

        public static bool operator ==(Entity left, Entity right)
        {
            if (left is null && right is null)
                return true;

            if (left is null || right is null)
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        #endregion

        #region System.Object

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
            return Id != null ? Id.GetHashCode() : 0;
        }

        #endregion

        #region IAuditable

        public PersonId CreatedBy => _auditable.CreatedBy;
        public DateTime? CreatedDate => _auditable.CreatedDate;
        public PersonId ModifiedBy => _auditable.ModifiedBy;
        public DateTime? ModifiedDate => _auditable.ModifiedDate;

        public IAuditable SetCreatedInfo(PersonId personId)
        {
            return _auditable.SetCreatedInfo(personId);
        }

        public IAuditable SetModifiedInfo(PersonId personId, DateTime? now = null)
        {
            return _auditable.SetModifiedInfo(personId, now);
        }

        #endregion
    }
}
