using System;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public interface IAuditable
    {
        PersonId CreatedBy { get; }
        DateTime? CreatedDate { get; }
        PersonId ModifiedBy { get; }
        DateTime? ModifiedDate { get; }

        IAuditable SetCreatedInfo(PersonId personId);
        IAuditable SetModifiedInfo(PersonId personId, DateTime? now = null);
    }
}
