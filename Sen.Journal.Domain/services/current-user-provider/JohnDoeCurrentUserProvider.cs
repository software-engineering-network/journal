namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class JohnDoeCurrentUserProvider : ICurrentUserProvider
    {
        public Person GetCurrentUser()
        {
            return new Person(
                new PersonId(1),
                new EmailAddress("john.doe@gmail.com"),
                new Password("peanutbuttereggdirt"),
                new Username("JohnDoe")
            );
        }
    }
}
