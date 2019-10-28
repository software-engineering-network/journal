using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Services
{
    public class JournalManagementService : IJournalManagementService
    {
        #region Fields

        private readonly CreateJournalValidator _createJournalValidator;
        private readonly IJournalRepository _journalRepository;

        #endregion

        #region Construction

        public JournalManagementService(
            CreateJournalValidator createJournalValidator,
            IJournalRepository journalRepository
        )
        {
            _createJournalValidator = createJournalValidator;
            _journalRepository = journalRepository;
        }

        #endregion

        #region IJournalManagementService Members

        public IJournalManagementService CreateJournal(CreateJournal createJournal)
        {
            _createJournalValidator.ValidateAndThrowCustom(createJournal);

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
