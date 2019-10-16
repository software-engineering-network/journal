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

        public Person CreatedBy { get; private set; }
        public DateTime? CreatedDate { get; private set; }
        public Person ModifiedBy { get; private set; }
        public DateTime? ModifiedDate { get; private set; }

        public IAuditable Create(Person person)
        {
            CreatedBy = person;
            CreatedDate = _dateTimeProvider.Now();
            Modify(person, CreatedDate);
            return this;
        }

        public IAuditable Modify(Person person, DateTime? now = null)
        {
            ModifiedBy = person;
            ModifiedDate = now ?? _dateTimeProvider.Now();
            return this;
        }
    }
}
