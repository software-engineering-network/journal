namespace SoftwareEngineeringNetwork.JournalApplication.Domain.UserManagement
{
    public class User : Entity
    {
        public EmailAddress EmailAddress { get; }
        public Name Name { get; }
        public Password Password { get; }
        public Surname Surname { get; }
        public Username Username { get; }

        public User(
            EmailAddress emailAddress,
            Name name,
            Password password,
            RecordName recordName,
            Surname surname,
            Username username
        )
        {
            EmailAddress = emailAddress;
            Name = name;
            Password = password;
            RecordName = recordName;
            Surname = surname;
            Username = username;
        }
    }
}
