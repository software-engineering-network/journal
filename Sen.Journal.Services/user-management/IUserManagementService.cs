using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Services
{
    public interface IUserManagementService
    {
        void CreateUser(CreateUser createUser);
    }
}
