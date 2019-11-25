using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Test
{
    public class TestCurrentUserProvider : ICurrentUserProvider
    {
        #region Properties

        public User CurrentUser { get; set; }

        #endregion

        #region Construction

        public TestCurrentUserProvider()
        {
            CurrentUser = TestUserFactory.CreateJohnDoe(1);
        }

        #endregion

        #region ICurrentUserProvider Members

        public User GetCurrentUser()
        {
            return CurrentUser;
        }

        #endregion
    }
}
