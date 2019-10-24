namespace SoftwareEngineeringNetwork.JournalApplication.Domain.UserManagement
{
    public interface IUserManager
    {
        void CreateUser(CreateUserCommand createUserCommand);
    }
}
