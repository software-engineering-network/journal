using System.ComponentModel;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using SoftwareEngineeringNetwork.JournalApplication.Services;

namespace SoftwareEngineeringNetwork.JournalApplication.Wpf
{
    public class RegisterUserDialogViewModel :
        INotifyPropertyChanged,
        IRegisterUser,
        IOpenCreateJournalDialog
    {
        #region Fields

        private readonly INotifyPropertyChanged _notifyPropertyChanged;
        private readonly IUserManagementService _userManagementService;
        private readonly ICreateJournalDialogViewModelFactory _createJournalDialogViewModelFactory;

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
            INotifyPropertyChanged notifyPropertyChanged,
            IUserManagementService userManagementService,
            ICreateJournalDialogViewModelFactory createJournalDialogViewModelFactory
        )
        {
            _notifyPropertyChanged = notifyPropertyChanged;
            _userManagementService = userManagementService;
            _createJournalDialogViewModelFactory = createJournalDialogViewModelFactory;
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged
        {
            add => _notifyPropertyChanged.PropertyChanged += value;
            remove => _notifyPropertyChanged.PropertyChanged -= value;
        }

        #endregion

        #region IOpenCreateJournalDialog Members

        public void OpenCreateJournalDialog()
        {
            var createJournalDialogViewModel = _createJournalDialogViewModelFactory.Create();
            var createJournalDialog = new CreateJournalDialog();

            var result = createJournalDialog.ShowDialog();
        }

        #endregion

        #region IRegisterUser Members

        public CreateUser BuildCreateUserCommand()
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
            var createUser = BuildCreateUserCommand();
            _userManagementService.CreateUser(createUser);
        }

        #endregion
    }
}
