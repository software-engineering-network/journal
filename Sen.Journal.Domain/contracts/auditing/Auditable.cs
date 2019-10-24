using System;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class Auditable : IAuditable
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public Auditable(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public UserId CreatedBy { get; private set; }
        public DateTime? CreatedDate { get; private set; }
        public UserId ModifiedBy { get; private set; }
        public DateTime? ModifiedDate { get; private set; }

        public IAuditable SetCreatedInfo(UserId userId)
        {
            CreatedBy = userId;
            CreatedDate = _dateTimeProvider.Now();
            SetModifiedInfo(userId, CreatedDate);
            return this;
        }

        public IAuditable SetModifiedInfo(UserId userId, DateTime? now = null)
        {
            ModifiedBy = userId;
            ModifiedDate = now ?? _dateTimeProvider.Now();
            return this;
        }
    }
}
