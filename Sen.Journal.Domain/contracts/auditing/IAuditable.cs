using System;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public interface IAuditable
    {
        UserId CreatedBy { get; }
        DateTime? CreatedDate { get; }
        UserId ModifiedBy { get; }
        DateTime? ModifiedDate { get; }

        IAuditable SetCreatedInfo(UserId userId);
        IAuditable SetModifiedInfo(UserId userId, DateTime? now = null);
    }
}
