using System;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class InvalidCommandException : Exception
    {
        #region Construction

        public InvalidCommandException(string errorMessages)
            : base(errorMessages)
        {
        }

        #endregion
    }
}
