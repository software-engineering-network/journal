using System;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public interface IAuditable
    {
        Person CreatedBy { get; }
        DateTime? CreatedDate { get; }
        Person ModifiedBy { get; }
        DateTime? ModifiedDate { get; }

        IAuditable Create(Person person);
        IAuditable Modify(Person person, DateTime? now = null);
    }
}
