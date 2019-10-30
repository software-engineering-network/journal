using System.Windows.Input;

namespace SoftwareEngineeringNetwork.JournalApplication.Wpf
{
    public interface IOpenRegisterUserDialog
    {
        #region Properties

        ICommand OpenRegisterUserDialogCommand { get; }

        #endregion
    }
}
