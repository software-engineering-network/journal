using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Wpf
{
    public interface IRegisterUser
    {
        #region Properties

        DelegateCommand RegisterUserCommand { get; }

        #endregion

        CreateUser BuildCreateUserCommand();
    }
}
