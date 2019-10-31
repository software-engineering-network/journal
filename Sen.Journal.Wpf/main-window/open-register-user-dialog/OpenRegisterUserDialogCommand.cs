using System;
using System.Windows;
using System.Windows.Input;
using SoftwareEngineeringNetwork.JournalApplication.Wpf.register_user_dialog;

namespace SoftwareEngineeringNetwork.JournalApplication.Wpf
{
    public class OpenRegisterUserDialogCommand : ICommand
    {
        #region Fields

        private readonly RegisterUserDialogViewModel _registerUserDialogViewModel;

        #endregion

        #region Construction

        public OpenRegisterUserDialogCommand(RegisterUserDialogViewModel registerUserDialogViewModel)
        {
            _registerUserDialogViewModel = registerUserDialogViewModel;
        }

        #endregion

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var registerUserDialog = new RegisterUserDialog
            {
                DataContext = _registerUserDialogViewModel,
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            registerUserDialog.ShowDialog();
        }

        public event EventHandler CanExecuteChanged;

        #endregion
    }
}
