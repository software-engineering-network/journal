namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class CreateUser :
        IEmailAddressCommand,
        INameCommand,
        IPasswordCommand,
        ISurnameCommand,
        IUsernameCommand
    {
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

        #region INameCommand Members

        public Name Name { get; }

        #endregion

        #region IPasswordCommand Members

        public Password Password { get; }

        #endregion

        #region ISurnameCommand Members

        public Surname Surname { get; }

        #endregion

        #region IUsernameCommand Members

        public Username Username { get; }

        #endregion
    }
}
