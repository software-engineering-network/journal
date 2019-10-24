namespace SoftwareEngineeringNetwork.JournalApplication.Domain.UserManagement
{
    public class User : Entity
    {
        #region Properties

        public EmailAddress EmailAddress { get; }
        public Name Name { get; }
        public Password Password { get; }
        public Surname Surname { get; }
        public Username Username { get; }

        #endregion

        #region Construction

        public User(
            EmailAddress emailAddress,
            Name name,
            Password password,
            RecordName recordName,
            Surname surname,
            Username username
        ) : this(
            null,
            emailAddress,
            name,
            password,
            recordName,
            surname,
            username
        )
        {
        }

        public User(
            UserId userId,
            EmailAddress emailAddress,
            Name name,
            Password password,
            RecordName recordName,
            Surname surname,
            Username username
        ) : base(userId)
        {
            Id = userId;
            EmailAddress = emailAddress;
            Name = name;
            Password = password;
            RecordName = recordName;
            Surname = surname;
            Username = username;
        }

        #endregion
    }
}
