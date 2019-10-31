using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Test.Wpf
{
    public class JohnDoeCurrentUserProvider : ICurrentUserProvider
    {
        public User GetCurrentUser()
        {
            return new User(
                new UserId(1), 
                new EmailAddress("john.doe@gmail.com"),
                new Name("John"), 
                new Password("peanutbuttereggdirt"),
                new RecordName("jdoe"), 
                new Surname("Doe"), 
                new Username("JohnDoe")
            );
        }
    }
}
