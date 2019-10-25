using FluentAssertions;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using SoftwareEngineeringNetwork.JournalApplication.Infrastructure.InMemory;
using SoftwareEngineeringNetwork.JournalApplication.Services.Journals;
using Xunit;

namespace SoftwareEngineeringNetwork.JournalApplication.Test.Domain.JournalManagement
{
    public class JournalManagerTest
    {
        #region Setup/Teardown

        public JournalManagerTest()
        {
            var currentUserProvider = new JohnDoeCurrentUserProvider();
            _johnDoe = currentUserProvider.GetCurrentUser();

            var journalRepository = new JournalRepository(currentUserProvider);
            _journalService = new JournalService(journalRepository);
            _journalManager = new JournalManager(journalRepository);
        }

        #endregion

        private readonly JournalManager _journalManager;
        private readonly IJournalService _journalService;
        private readonly User _johnDoe;

        [Theory]
        [InlineData("Music Cover Notes")]
        public void WhenCreatingAJournal_AJournalIsPersisted(string journalTitle)
        {
            var createJournal = new CreateJournal(
                (UserId) _johnDoe.Id,
                new JournalTitle(journalTitle)
            );

            _journalManager.CreateJournal(createJournal);

            var journal = _journalService.Find(_johnDoe.Id.Value, journalTitle);
            journal.DisplayName.Should().Be(journalTitle);
        }
    }
}
