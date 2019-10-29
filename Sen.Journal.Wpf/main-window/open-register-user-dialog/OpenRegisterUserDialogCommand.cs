using System;
using System.Windows.Input;
using SoftwareEngineeringNetwork.JournalApplication.Wpf.register_user_dialog;

namespace SoftwareEngineeringNetwork.JournalApplication.Wpf
{
    public class OpenRegisterUserDialogCommand : ICommand
    {
        #region Fields

        private readonly RegisterUserDialog _registerUserDialog;

        #endregion

        #region Construction

        public OpenRegisterUserDialogCommand(RegisterUserDialog registerUserDialog)
        {
            _registerUserDialog = registerUserDialog;
        }

        #endregion

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _registerUserDialog.ShowDialog();
        }

        public event EventHandler CanExecuteChanged;

        #endregion
    }
}