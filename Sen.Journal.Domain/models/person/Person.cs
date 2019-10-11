namespace Sen.Journal.Domain
{
    public class Person : Entity
    {
        public EmailAddress EmailAddress { get; }
        public Password Password { get; }
        public Username Username { get; }

        public Person(
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
