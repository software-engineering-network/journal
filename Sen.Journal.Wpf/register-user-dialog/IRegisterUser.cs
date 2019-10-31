using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Wpf
{
    public interface IRegisterUser
    {
        #region Properties

        string EmailAddress { get; set; }
        string Name { get; set; }
        string Password { get; set; }
        string Surname { get; set; }
        string Username { get; set; }

        DelegateCommand RegisterUserCommand { get; }

        #endregion

        CreateUser BuildCreateUserCommand();

        void RegisterUser();
    }
}
