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

        public PersonId CreatedBy { get; private set; }
        public DateTime? CreatedDate { get; private set; }
        public PersonId ModifiedBy { get; private set; }
        public DateTime? ModifiedDate { get; private set; }

        public IAuditable SetCreatedInfo(PersonId personId)
        {
            CreatedBy = personId;
            CreatedDate = _dateTimeProvider.Now();
            SetModifiedInfo(personId, CreatedDate);
            return this;
        }

        public IAuditable SetModifiedInfo(PersonId personId, DateTime? now = null)
        {
            ModifiedBy = personId;
            ModifiedDate = now ?? _dateTimeProvider.Now();
            return this;
        }
    }
}
