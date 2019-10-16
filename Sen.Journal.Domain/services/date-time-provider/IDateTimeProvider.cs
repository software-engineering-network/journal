using System;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public interface IDateTimeProvider
    {
        DateTime Now();
    }
}
