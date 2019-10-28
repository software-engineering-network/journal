using FluentAssertions;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using SoftwareEngineeringNetwork.JournalApplication.Services;
using Xunit;

namespace SoftwareEngineeringNetwork.JournalApplication.Test.Services.JournalEntryManagement
{
    public class JournalEntryManagerTest
    {
        #region Fields

        private readonly User _johnDoe;
        private readonly JournalEntryManagementService _journalEntryManagementService;
        private readonly IJournalEntryService _journalEntryService;
        private readonly Journal _musicCoversJournal;

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Construction

        public JournalEntryManagerTest()
        {
            _unitOfWork = TestUnitOfWorkFactory
                .CreateUnitOfWork()
                .WithUsers()
                .WithJournals();

            _musicCoversJournal = TestJournalFactory.CreateMusicCoversJournal(1);
            _journalEntryManagementService = new JournalEntryManagementService(_unitOfWork.JournalEntryRepository);
            _johnDoe = TestUserFactory.CreateJohnDoe(1);
            _journalEntryService = new JournalEntryService(_unitOfWork.JournalEntryRepository);
        }

        #endregion

        [Theory]
        [InlineData(
            "Fall to Pieces",
            "Tuning: half-step down\nVerse: D D C G 4x\nPrechorus: A A G D A A G A"
        )]
        public void WhenCreatingAPost_APostIsPersisted(string journalEntryTitle, string journalEntryContent)
        {
            var createJournalEntry = new CreateJournalEntry(
                (UserId) _johnDoe.Id,
                (JournalId) _musicCoversJournal.Id,
                new JournalEntryTitle(journalEntryTitle),
                new JournalEntryContent(journalEntryContent)
            );

            _journalEntryManagementService.CreateJournalEntry(createJournalEntry);

            var journalEntry = _journalEntryService.Find(
                _musicCoversJournal.Id.Value,
                journalEntryTitle
            );

            journalEntry.Should().NotBeNull();
        }
    }
}
