using SoftwareEngineeringNetwork.JournalApplication.Domain;
using SoftwareEngineeringNetwork.JournalApplication.Domain.UserManagement;

namespace SoftwareEngineeringNetwork.JournalApplication.Test
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
                new RecordName("JohnDoe"), 
                new Surname("Doe"), 
                new Username("JohnDoe")
            );
        }
    }
}
