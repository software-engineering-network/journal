using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Services.UserManagement
{
    public interface IUserManagementService
    {
        void CreateUser(CreateUser createUser);
    }
}
