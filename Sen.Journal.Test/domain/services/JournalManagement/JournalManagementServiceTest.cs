using FluentAssertions;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using SoftwareEngineeringNetwork.JournalApplication.Services;
using Xunit;

namespace SoftwareEngineeringNetwork.JournalApplication.Test.JournalManagement
{
    public class JournalManagementServiceTest
    {
        #region Fields

        private readonly User _johnDoe;
        private readonly JournalManagementService _journalManagementService;
        private readonly IJournalService _journalService;

        #endregion

        #region Construction

        public JournalManagementServiceTest()
        {
            var unitOfWork = TestUnitOfWorkFactory
                .CreateUnitOfWork()
                .WithUsers();

            _journalService = new JournalService(unitOfWork.JournalRepository);

            var createJournalValidator = new CreateJournalValidator(
                new UserIdMustExistValidator(unitOfWork),
                new JournalTitleMustNotExistsValidator(unitOfWork)
            );

            _journalManagementService = new JournalManagementService(
                createJournalValidator,
                unitOfWork.JournalRepository
            );
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

            _journalManagementService.CreateJournal(createJournal);

            var journal = _journalService.Find(_johnDoe.Id.Value, journalTitle);
            journal.DisplayName.Should().Be(journalTitle);
        }
    }
}
