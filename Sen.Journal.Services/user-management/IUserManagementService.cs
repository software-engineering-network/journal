using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Services
{
    public interface IUserManagementService
    {
        IUserManagementService CreateUser(CreateUser createUser);
    }
}
