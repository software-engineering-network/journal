using SoftwareEngineeringNetwork.JournalApplication.Domain.UserManagement;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public interface ICurrentUserProvider
    {
        User GetCurrentUser();
    }
}
