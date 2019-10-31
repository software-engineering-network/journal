using System;
using System.Windows.Input;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using SoftwareEngineeringNetwork.JournalApplication.Services;

namespace SoftwareEngineeringNetwork.JournalApplication.Wpf
{
    public class RegisterUserCommand : ICommand
    {
        #region Fields

        private readonly IUserManagementService _userManagementService;

        #endregion

        #region Construction

        public RegisterUserCommand(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        #endregion

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return _userManagementService.ValidateCreateUser(GetCreateUser(parameter)).IsValid;
        }

        public void Execute(object parameter)
        {
            _userManagementService.CreateUser(GetCreateUser(parameter));
        }

        public event EventHandler CanExecuteChanged;

        #endregion

        private static CreateUser GetCreateUser(object parameter)
        {
            return (CreateUser) parameter;
        }
    }
}
