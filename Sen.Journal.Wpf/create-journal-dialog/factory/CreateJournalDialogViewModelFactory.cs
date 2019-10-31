using SoftwareEngineeringNetwork.JournalApplication.Services;

namespace SoftwareEngineeringNetwork.JournalApplication.Wpf
{
    public class CreateJournalDialogViewModelFactory : ICreateJournalDialogViewModelFactory
    {
        #region Fields

        private readonly IJournalManagementService _journalManagementService;

        #endregion

        #region Construction

        public CreateJournalDialogViewModelFactory(IJournalManagementService journalManagementService)
        {
            _journalManagementService = journalManagementService;
        }

        #endregion

        #region ICreateJournalDialogViewModelFactory Members

        public CreateJournalDialogViewModel Create()
        {
            return new CreateJournalDialogViewModel(_journalManagementService);
        }

        #endregion
    }
}
