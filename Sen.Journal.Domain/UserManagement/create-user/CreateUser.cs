namespace SoftwareEngineeringNetwork.JournalApplication.Domain.UserManagement
{
    public class CreateUser
    {
        #region Properties

        public EmailAddress EmailAddress { get; }
        public Name Name { get; }
        public Password Password { get; }
        public Surname Surname { get; }
        public Username Username { get; }

        #endregion

        #region Construction

        public CreateUser(
            EmailAddress emailAddress,
            Name name,
            Password password,
            Surname surname,
            Username username
        )
        {
            EmailAddress = emailAddress;
            Name = name;
            Password = password;
            Surname = surname;
            Username = username;
        }

        #endregion
    }
}
