namespace Sen.Journal.Domain
{
    public class JohnDoeCurrentUserProvider : ICurrentUserProvider
    {
        public Person GetCurrentUser()
        {
            return new Person(
                new Id(1),
                new EmailAddress("john.doe@gmail.com"),
                new Password("peanutbuttereggdirt"),
                new Username("JohnDoe")
            );
        }
    }
}