using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Services
{
    public class JournalEntryManagementService : IJournalEntryManagementService
    {
        #region Fields

        private readonly IJournalEntryRepository _journalEntryRepository;

        #endregion

        #region Construction

        public JournalEntryManagementService(IJournalEntryRepository journalEntryRepository)
        {
            _journalEntryRepository = journalEntryRepository;
        }

        #endregion

        #region IJournalEntryManagementService Members

        public IJournalEntryManagementService CreateJournalEntry(CreateJournalEntry createJournalEntry)
        {
            var journalEntry = new JournalEntry(
                createJournalEntry.UserId,
                createJournalEntry.JournalId,
                createJournalEntry.JournalEntryTitle,
                createJournalEntry.JournalEntryContent
            );

            _journalEntryRepository.Create(journalEntry);

            return this;
        }

        #endregion
    }
}
