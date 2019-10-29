using System.ComponentModel;
using SoftwareEngineeringNetwork.JournalApplication.Services;

namespace SoftwareEngineeringNetwork.JournalApplication.Wpf
{
    public class CreateJournalDialogViewModelFactory : ICreateJournalDialogViewModelFactory
    {
        #region Fields

        private readonly INotifyPropertyChanged _notifyPropertyChanged;
        private readonly IJournalManagementService _journalManagementService;

        #endregion

        #region Construction

        public CreateJournalDialogViewModelFactory(
            INotifyPropertyChanged notifyPropertyChanged,
            IJournalManagementService journalManagementService
        )
        {
            _notifyPropertyChanged = notifyPropertyChanged;
            _journalManagementService = journalManagementService;
        }

        #endregion

        #region ICreateJournalDialogViewModelFactory Members

        public CreateJournalDialogViewModel Create()
        {
            return new CreateJournalDialogViewModel(
                _notifyPropertyChanged,
                _journalManagementService
            );
        }

        #endregion
    }
}
