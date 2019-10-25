namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class JournalManager : IJournalManager
    {
        #region Fields

        private readonly IJournalRepository _journalRepository;

        #endregion

        #region Construction

        public JournalManager(IJournalRepository journalRepository)
        {
            _journalRepository = journalRepository;
        }

        #endregion

        #region IJournalManager Members

        public IJournalManager CreateJournal(CreateJournal createJournal)
        {
            var journal = new Journal(
                createJournal.UserId,
                createJournal.JournalTitle
            );

            _journalRepository.Create(journal);

            return this;
        }

        #endregion
    }
}
