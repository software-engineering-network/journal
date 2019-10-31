using System.Collections.ObjectModel;
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
        private bool _canRegisterUser;
        private string _name;
        private string _password;
        private string _surname;
        private string _username;

        #endregion

        #region Properties

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

        public bool CanRegisterUser
        {
            get => _canRegisterUser;
            set
            {
                _canRegisterUser = value;
                OnPropertyChanged(nameof(CanRegisterUser));
            }
        }

        #endregion

        #region Construction

        public RegisterUserDialogViewModel(
            IUserManagementService userManagementService,
            ICreateJournalDialogViewModelFactory createJournalDialogViewModelFactory
        )
        {
            _userManagementService = userManagementService;
            _createJournalDialogViewModelFactory = createJournalDialogViewModelFactory;

            _errorMessages = new ObservableCollection<string>();
            RegisterUserCommand = new DelegateCommand(RegisterUser, CheckCanRegisterUser);
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

        public string EmailAddress
        {
            get => _emailAddress;
            set
            {
                _emailAddress = value;
                OnPropertyChanged(nameof(EmailAddress));
                CheckCanRegisterUser();
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
                CheckCanRegisterUser();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                CheckCanRegisterUser();
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
                CheckCanRegisterUser();
            }
        }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
                CheckCanRegisterUser();
            }
        }

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

        public void RegisterUser()
        {
            var createUser = BuildCreateUserCommand();
            _userManagementService.CreateUser(createUser);
        }

        #endregion

        private bool CheckCanRegisterUser()
        {
            var createUser = BuildCreateUserCommand();
            var validationResult = _userManagementService.ValidateCreateUser(createUser);

            CanRegisterUser = validationResult.IsValid;
            _errorMessages.Clear();

            if (!CanRegisterUser)
                foreach (var errorMessage in validationResult.ErrorMessages)
                    _errorMessages.Add(errorMessage);

            OnPropertyChanged(nameof(ErrorMessages));

            return CanRegisterUser;
        }
    }
}
