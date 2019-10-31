using SoftwareEngineeringNetwork.JournalApplication.Domain;
using SoftwareEngineeringNetwork.JournalApplication.Services;

namespace SoftwareEngineeringNetwork.JournalApplication.Wpf
{
    public class CreateJournalDialogViewModel :
        ViewModelBase,
        ICreateJournal
    {
        #region Fields

        private readonly IJournalManagementService _journalManagementService;

        #endregion

        #region Properties

        public ulong UserId { get; set; }
        public string JournalTitle { get; set; }

        #endregion

        #region Construction

        public CreateJournalDialogViewModel(IJournalManagementService journalManagementService)
        {
            _journalManagementService = journalManagementService;
        }

        #endregion

        #region ICreateJournal Members

        public CreateJournal BuildCreateJournalCommand()
        {
            return new CreateJournal(
                new UserId(UserId),
                new JournalTitle(JournalTitle)
            );
        }

        public void CreateJournal()
        {
            var createJournal = BuildCreateJournalCommand();
            _journalManagementService.CreateJournal(createJournal);
        }

        #endregion
    }
}
