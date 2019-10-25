using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Services
{
    public class JournalEntryService : IJournalEntryService
    {
        #region Fields

        private readonly IJournalEntryRepository _journalEntryRepository;

        #endregion

        #region Construction

        public JournalEntryService(IJournalEntryRepository journalEntryRepository)
        {
            _journalEntryRepository = journalEntryRepository;
        }

        #endregion

        #region IJournalEntryService Members

        public JournalEntryDto Find(ulong journalId, string journalEntryTitle)
        {
            return _journalEntryRepository.Find(
                    new JournalId(journalId),
                    new JournalEntryTitle(journalEntryTitle)
                )
                .ToJournalEntryDto();
        }

        #endregion
    }
}