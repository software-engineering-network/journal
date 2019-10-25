using FluentAssertions;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using SoftwareEngineeringNetwork.JournalApplication.Services;
using Xunit;

namespace SoftwareEngineeringNetwork.JournalApplication.Test
{
    public class JournalEntryManagerTest
    {
        private readonly JournalEntryManager _journalEntryManager;
        private readonly Journal _musicCoversJournal;
        private readonly User _johnDoe;
        private readonly IJournalEntryService _journalEntryService;

        public JournalEntryManagerTest()
        {
            _musicCoversJournal = TestJournalFactory.CreateMusicCoversJournal();
            var journalEntryRepository = TestRepositoryFactory.CreateJournalEntryRepository();
            _journalEntryManager = new JournalEntryManager(journalEntryRepository);
            _johnDoe = TestUserFactory.CreateJohnDoe();
            _journalEntryService = new JournalEntryService(journalEntryRepository);
        }

        [Theory]
        [InlineData("Fall to Pieces", "Tuning: half-step down\nVerse: D D C G 4x\nPrechorus: A A G D A A G A")]
        public void WhenCreatingAPost_APostIsPersisted(string journalEntryTitle, string journalEntryContent)
        {
            var createJournalEntry = new CreateJournalEntry(
                _johnDoe.Id.Value,
                _musicCoversJournal.Id.Value,
                journalEntryTitle,
                journalEntryContent
            );

            _journalEntryManager.CreateJournalEntry(createJournalEntry);

            var journalEntry = _journalEntryService.Find(
                _musicCoversJournal.Id.Value,
                journalEntryTitle
            );

            journalEntry.Should().NotBeNull();
        }
    }
}
