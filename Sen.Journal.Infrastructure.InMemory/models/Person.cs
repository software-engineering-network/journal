namespace SoftwareEngineeringNetwork.JournalApplication.Infrastructure.InMemory
{
    /// <summary>
    /// External representation of a User
    /// </summary>
    public class Person
    {
        public ulong Id { get; set; }
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string RecordName { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
    }
}
