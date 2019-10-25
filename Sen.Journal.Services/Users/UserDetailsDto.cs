namespace SoftwareEngineeringNetwork.JournalApplication.Services
{
    public class UserDetailsDto
    {
        #region Properties

        public ulong Id { get; }
        public string EmailAddress { get; }
        public string Name { get; }
        public string Password { get; }
        public string RecordName { get; }
        public string Surname { get; }
        public string Username { get; }

        #endregion

        #region Construction

        public UserDetailsDto(
            ulong id,
            string emailAddress,
            string name,
            string password,
            string recordName,
            string surname,
            string username
        )
        {
            Id = id;
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
