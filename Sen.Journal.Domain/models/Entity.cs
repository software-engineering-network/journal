using System;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public abstract class Entity : IAuditable
    {
        #region Fields

        private readonly IAuditable _auditable;

        #endregion

        #region Properties

        public Id Id { get; protected set; }
        public RecordName RecordName { get; protected set; }

        #endregion

        #region Construction

        protected Entity()
        {
        }

        protected Entity(Id id)
        {
            Id = id;

            var dateTimeProvider = new BasicDateTimeProvider();
            _auditable = new Auditable(dateTimeProvider);
        }

        #endregion

        #region IAuditable Members

        public UserId CreatedBy => _auditable.CreatedBy;

        public DateTime? CreatedDate => _auditable.CreatedDate;

        public UserId ModifiedBy => _auditable.ModifiedBy;

        public DateTime? ModifiedDate => _auditable.ModifiedDate;

        public IAuditable SetCreatedInfo(UserId userId)
        {
            return _auditable.SetCreatedInfo(userId);
        }

        public IAuditable SetModifiedInfo(UserId userId, DateTime? now = null)
        {
            return _auditable.SetModifiedInfo(userId, now);
        }

        #endregion

        #region object Overrides

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

        #region Operator Overloads

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
    }
}
