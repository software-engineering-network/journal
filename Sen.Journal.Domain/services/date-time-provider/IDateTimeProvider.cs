using System;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public interface IDateTimeProvider
    {
        #region Properties

        DateTime Now { get; }

        #endregion
    }
}
