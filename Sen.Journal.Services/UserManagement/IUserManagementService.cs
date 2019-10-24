using SoftwareEngineeringNetwork.JournalApplication.Domain.UserManagement;

namespace SoftwareEngineeringNetwork.JournalApplication.Services.UserManagement
{
    public interface IUserManagementService
    {
        void CreateUser(CreateUser createUser);
    }
}
