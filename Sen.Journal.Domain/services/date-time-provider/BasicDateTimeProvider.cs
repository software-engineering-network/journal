using System;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class BasicDateTimeProvider : IDateTimeProvider
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
