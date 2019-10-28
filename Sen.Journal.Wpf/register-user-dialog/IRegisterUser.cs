using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Wpf
{
    public interface IRegisterUser
    {
        CreateUser CreateCreateUser();
        void RegisterUser();
    }
}
