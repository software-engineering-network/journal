namespace SoftwareEngineeringNetwork.JournalApplication.Wpf
{
    public class MainWindowViewModel :
        ViewModelBase,
        IOpenRegisterUserDialog
    {
        #region Properties

        public string Title => "Sen.Journal";

        #endregion

        #region Construction

        public MainWindowViewModel(OpenRegisterUserDialogCommand openRegisterUserDialogCommand)
        {
            OpenRegisterUserDialogCommand = openRegisterUserDialogCommand;
        }

        #endregion

        #region IOpenRegisterUserDialog Members

        public OpenRegisterUserDialogCommand OpenRegisterUserDialogCommand { get; }
        public string OpenRegisterUserDialogText => "Register User";

        #endregion
    }
}
