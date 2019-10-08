namespace Sen.Journal.Domain
{
    public class User
    {
        public EmailAddress EmailAddress { get; }
        public Password Password { get; }
        public Username Username { get; }

        public User(EmailAddress emailAddress, Password password, Username username)
        {
            EmailAddress = emailAddress;
            Password = password;
            Username = username;
        }
    }
}
