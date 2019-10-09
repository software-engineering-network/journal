namespace Sen.Journal.Domain
{
    public class User : Entity
    {
        public EmailAddress EmailAddress { get; }
        public Password Password { get; }
        public Username Username { get; }

        public User(
            Id id,
            EmailAddress emailAddress,
            Password password,
            Username username
        ) : base(id)
        {
            EmailAddress = emailAddress;
            Password = password;
            Username = username;
        }
    }
}
