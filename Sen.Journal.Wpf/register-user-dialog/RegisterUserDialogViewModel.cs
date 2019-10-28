using System.ComponentModel;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using SoftwareEngineeringNetwork.JournalApplication.Services;

namespace SoftwareEngineeringNetwork.JournalApplication.Wpf
{
    public class RegisterUserDialogViewModel : INotifyPropertyChanged, IRegisterUser
    {
        #region Fields

        private readonly INotifyPropertyChanged _notifyPropertyChangedImplementation;

        private readonly IUserManagementService _userManagementService;

        #endregion

        #region Properties

        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }

        #endregion

        #region Construction

        public RegisterUserDialogViewModel(
            INotifyPropertyChanged notifyPropertyChangedImplementation,
            IUserManagementService userManagementService
        )
        {
            _notifyPropertyChangedImplementation = notifyPropertyChangedImplementation;
            _userManagementService = userManagementService;
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged
        {
            add => _notifyPropertyChangedImplementation.PropertyChanged += value;
            remove => _notifyPropertyChangedImplementation.PropertyChanged -= value;
        }

        #endregion

        #region IRegisterUser Members

        public CreateUser CreateCreateUser()
        {
            return new CreateUser(
                new EmailAddress(EmailAddress),
                new Name(Name),
                new Password(Password),
                new Surname(Surname),
                new Username(Username)
            );
        }

        public void RegisterUser()
        {
            var createUser = CreateCreateUser();
            _userManagementService.CreateUser(createUser);
        }

        #endregion
    }
}
