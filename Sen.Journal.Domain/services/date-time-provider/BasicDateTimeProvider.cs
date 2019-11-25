using System;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class BasicDateTimeProvider : IDateTimeProvider
    {
        #region IDateTimeProvider Members

        public DateTime Now => DateTime.Now;

        #endregion
    }
}
