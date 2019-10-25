using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Services.Journals
{
    public class JournalService : IJournalService
    {
        #region Fields

        private readonly IJournalRepository _journalRepository;

        #endregion

        #region Construction

        public JournalService(IJournalRepository journalRepository)
        {
            _journalRepository = journalRepository;
        }

        #endregion

        #region IJournalService Members

        public JournalDto Find(ulong userId, string journalTitle)
        {
            return _journalRepository
                .Find(
                    new UserId(userId),
                    new JournalTitle(journalTitle)
                )
                .ToJournalDto();
        }

        #endregion
    }
}