namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class JournalEntryManager : IJournalEntryManager
    {
        private readonly IJournalEntryRepository _journalEntryRepository;

        public JournalEntryManager(IJournalEntryRepository journalEntryRepository)
        {
            _journalEntryRepository = journalEntryRepository;
        }

        #region IJournalEntryManager Members

        public IJournalEntryManager CreateJournalEntry(CreateJournalEntry createJournalEntry)
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