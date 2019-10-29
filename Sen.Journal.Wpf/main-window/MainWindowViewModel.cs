using System.ComponentModel;
using System.Windows.Input;
using SoftwareEngineeringNetwork.JournalApplication.Wpf.register_user_dialog;

namespace SoftwareEngineeringNetwork.JournalApplication.Wpf
{
    public class MainWindowViewModel :
        INotifyPropertyChanged,
        IOpenRegisterUserDialog
    {
        #region Fields

        private readonly INotifyPropertyChanged _notifyPropertyChanged;
        private readonly OpenRegisterUserDialogCommand _openRegisterUserDialogCommand;
        private ICommand _openRegisterUserDialog;

        #endregion

        #region Properties

        public string OpenRegisterUserDialogButtonContent => "Register User";

        #endregion

        #region Construction

        public MainWindowViewModel()
            : this(
                new NotifyPropertyChanged(),
                new OpenRegisterUserDialogCommand(
                    new RegisterUserDialog()
                )
            )
        {
        }

        public MainWindowViewModel(
            INotifyPropertyChanged notifyPropertyChanged,
            OpenRegisterUserDialogCommand openRegisterUserDialogCommand
        )
        {
            _notifyPropertyChanged = notifyPropertyChanged;
            OpenRegisterUserDialogCommand = openRegisterUserDialogCommand;
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged
        {
            add => _notifyPropertyChanged.PropertyChanged += value;
            remove => _notifyPropertyChanged.PropertyChanged -= value;
        }

        #endregion

        #region IOpenRegisterUserDialog Members

        public ICommand OpenRegisterUserDialogCommand { get; }

        #endregion

        public void OpenRegisterUserDialog()
        {
            OpenRegisterUserDialogCommand.Execute(null);
        }
    }
}
