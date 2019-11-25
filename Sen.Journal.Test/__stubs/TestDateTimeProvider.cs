using System;
using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Test
{
    public class TestDateTimeProvider : IDateTimeProvider
    {
        #region Properties

        public DateTime DateTimeToProvide { get; set; }

        #endregion

        #region Construction

        public TestDateTimeProvider(DateTime? dateTimeToProvide = null)
        {
            DateTimeToProvide = dateTimeToProvide ?? DateTime.Now;
        }

        #endregion

        #region IDateTimeProvider Members

        public DateTime Now => DateTimeToProvide;

        #endregion
    }
}
