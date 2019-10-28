namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class CreateUser :
        IEmailAddressCommand,
        IUsernameCommand
    {
        #region Properties

        public Name Name { get; }
        public Password Password { get; }
        public Surname Surname { get; }

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

        #region IEmailAddressCommand Members

        public EmailAddress EmailAddress { get; }

        #endregion

        #region IUsernameCommand Members

        public Username Username { get; }

        #endregion
    }
}
