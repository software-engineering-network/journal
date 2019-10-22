namespace SoftwareEngineeringNetwork.JournalApplication.Domain.UserRegistration
{
    public class User : Entity
    {
        public EmailAddress EmailAddress { get; set; }
        public Password Password { get; set; }
        public Username Username { get; set; }
    }
}
