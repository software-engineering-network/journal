using System;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public abstract class Entity : IAuditable
    {
        #region Fields

        private readonly IAuditable _auditable;

        #endregion

        #region Properties

        public Id Id { get; set; }
        public RecordName RecordName { get; protected set; }

        #endregion

        #region Construction

        protected Entity()
        {
        }

        protected Entity(IAuditable auditable, Id id)
        {
            _auditable = auditable;
            Id = id;
        }

        protected Entity(IAuditable auditable)
        {
            _auditable = auditable;
        }

        #endregion

        #region IAuditable Members

        public UserId CreatedBy => _auditable.CreatedBy;

        public DateTime? CreatedDate => _auditable.CreatedDate;

        public UserId ModifiedBy => _auditable.ModifiedBy;

        public DateTime? ModifiedDate => _auditable.ModifiedDate;

        public IAuditable Update()
        {
            return _auditable.Update();
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
