using SoftwareEngineeringNetwork.JournalApplication.Wpf.register_user_dialog;

namespace SoftwareEngineeringNetwork.JournalApplication.Wpf
{
    public class OpenRegisterUserDialogCommandFactory
    {
        #region Fields

        private readonly RegisterUserDialog _registerUserDialog;

        #endregion

        #region Construction

        public OpenRegisterUserDialogCommandFactory(
            RegisterUserDialog registerUserDialog
        )
        {
            _registerUserDialog = registerUserDialog;
        }

        #endregion
    }
}