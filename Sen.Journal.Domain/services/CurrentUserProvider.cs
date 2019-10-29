using System;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class CurrentUserProvider : ICurrentUserProvider
    {
        #region ICurrentUserProvider Members

        public User GetCurrentUser()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}