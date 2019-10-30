﻿using System.ComponentModel;

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

        public MainWindowViewModel(
            INotifyPropertyChanged notifyPropertyChanged,
            OpenRegisterUserDialogCommand openRegisterUserDialogCommand
        ) : base(notifyPropertyChanged)
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
