using FluentAssertions;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using SoftwareEngineeringNetwork.JournalApplication.Services;
using SoftwareEngineeringNetwork.JournalApplication.Wpf;
using Xunit;

namespace SoftwareEngineeringNetwork.JournalApplication.Test.Wpf
{
    public class CreateJournalDialogViewModelTest
    {
        #region Fields

        private readonly CreateJournalDialogViewModel _createJournalDialogViewModel;
        private readonly IJournalService _journalService;

        #endregion

        #region Construction

        public CreateJournalDialogViewModelTest()
        {
            var unitOfWork = TestUnitOfWorkFactory.CreateUnitOfWork().WithUsers();

            var journalManagementService = new JournalManagementService(
                new CreateJournalValidator(
                    new UserIdMustExistValidator(unitOfWork),
                    new JournalTitleIsRequiredValidator(),
                    new JournalTitleMustNotExistValidator(unitOfWork)
                ),
                unitOfWork.JournalRepository
            );

            _createJournalDialogViewModel = new CreateJournalDialogViewModel(
                new NotifyPropertyChanged(),
                journalManagementService
            );

            _journalService = new JournalService(unitOfWork.JournalRepository);
        }

        #endregion

        [Theory]
        [InlineData(1, "My new journal")]
        public void WhenCreatingAJournal_AJournalIsPersisted(ulong userId, string journalTitle)
        {
            // arrange
            _createJournalDialogViewModel.UserId = userId;
            _createJournalDialogViewModel.JournalTitle = journalTitle;

            // act
            _createJournalDialogViewModel.CreateJournal();

            // assert
            var journal = _journalService.Find(userId, journalTitle);
            var targetJournal = new JournalDto(1, userId, journalTitle);
            journal.Should().BeEquivalentTo(targetJournal);
        }
    }
}
