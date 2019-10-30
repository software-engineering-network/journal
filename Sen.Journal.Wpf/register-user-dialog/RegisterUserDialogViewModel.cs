using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using SoftwareEngineeringNetwork.JournalApplication.Services;

namespace SoftwareEngineeringNetwork.JournalApplication.Wpf
{
    public class RegisterUserDialogViewModel :
        ViewModelBase,
        IOpenCreateJournalDialog,
        IRegisterUser
    {
        #region Fields

        private readonly ICreateJournalDialogViewModelFactory _createJournalDialogViewModelFactory;
        private readonly ObservableCollection<string> _errorMessages;
        private readonly IUserManagementService _userManagementService;
        private string _emailAddress;
        private bool _isFormValid;
        private string _username;

        #endregion

        #region Properties

        public string EmailAddress
        {
            get => _emailAddress;
            set
            {
                _emailAddress = value;
                OnPropertyChanged(nameof(EmailAddress));
                CanRegisterUser();
            }
        }

        public string Name { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
                CanRegisterUser();
            }
        }

        public string ErrorMessages
        {
            get
            {
                var stringBuilder = new StringBuilder();
                foreach (var errorMessage in _errorMessages)
                    stringBuilder.Append($"{errorMessage}\n");

                return stringBuilder.ToString();
            }
        }

        public bool IsFormValid
        {
            get => _isFormValid;
            set
            {
                _isFormValid = value;
                OnPropertyChanged(nameof(IsFormValid));
            }
        }

        #endregion

        #region Construction

        public RegisterUserDialogViewModel(
            INotifyPropertyChanged notifyPropertyChanged,
            IUserManagementService userManagementService,
            ICreateJournalDialogViewModelFactory createJournalDialogViewModelFactory
        ) : base(notifyPropertyChanged)
        {
            _userManagementService = userManagementService;
            _createJournalDialogViewModelFactory = createJournalDialogViewModelFactory;

            _errorMessages = new ObservableCollection<string>();
            RegisterUserCommand = new DelegateCommand(RegisterUser, CanRegisterUser);
        }

        #endregion

        #region IOpenCreateJournalDialog Members

        public void OpenCreateJournalDialog()
        {
            var createJournalDialogViewModel = _createJournalDialogViewModelFactory.Create();
            var createJournalDialog = new CreateJournalDialog
            {
                DataContext = createJournalDialogViewModel
            };
            var result = createJournalDialog.ShowDialog();
        }

        #endregion

        #region IRegisterUser Members

        public DelegateCommand RegisterUserCommand { get; }

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

        #endregion

        private void RegisterUser()
        {
            _userManagementService.CreateUser(BuildCreateUserCommand());
        }

        private bool CanRegisterUser()
        {
            var validationResult = _userManagementService.ValidateCreateUser(BuildCreateUserCommand());

            _errorMessages.Clear();

            foreach (var errorMessage in validationResult.ErrorMessages)
                _errorMessages.Add(errorMessage);

            OnPropertyChanged(nameof(ErrorMessages));
            IsFormValid = validationResult.IsValid;

            return IsFormValid;
        }
    }
}
