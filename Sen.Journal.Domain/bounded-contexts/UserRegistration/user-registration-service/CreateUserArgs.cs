namespace SoftwareEngineeringNetwork.JournalApplication.Domain.UserRegistration
{
    public class CreateUserArgs
    {
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
    }
}
