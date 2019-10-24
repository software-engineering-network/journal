namespace SoftwareEngineeringNetwork.JournalApplication.Domain.UserManagement
{
    public class CreateUserCommand
    {
        #region Properties

        public EmailAddress EmailAddress { get; }
        public Name Name { get; }
        public Password Password { get; }
        public Surname Surname { get; }
        public Username Username { get; }

        #endregion

        #region Construction

        public CreateUserCommand(
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
