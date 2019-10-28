using FluentAssertions;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using SoftwareEngineeringNetwork.JournalApplication.Services;
using Xunit;

namespace SoftwareEngineeringNetwork.JournalApplication.Test.JournalManagement
{
    public class JournalManagerTest
    {
        #region Fields

        private readonly User _johnDoe;
        private readonly JournalManager _journalManager;
        private readonly IJournalService _journalService;

        #endregion

        #region Construction

        public JournalManagerTest()
        {
            var unitOfWork = TestUnitOfWorkFactory.CreateUnitOfWork();
            _journalService = new JournalService(unitOfWork.JournalRepository);
            _journalManager = new JournalManager(unitOfWork.JournalRepository);
            _johnDoe = TestUserFactory.CreateJohnDoe(1);
        }

        #endregion

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
