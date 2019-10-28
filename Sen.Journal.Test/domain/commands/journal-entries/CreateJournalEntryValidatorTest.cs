using System;
using FluentAssertions;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using Xunit;

namespace SoftwareEngineeringNetwork.JournalApplication.Test.Domain
{
    public class CreateJournalEntryValidatorTest
    {
        #region Fields

        private readonly CreateJournalEntryValidator _createJournalEntryValidator;

        #endregion

        #region Construction

        public CreateJournalEntryValidatorTest()
        {
            var unitOfWork = TestUnitOfWorkFactory
                .CreateUnitOfWork()
                .WithUsers()
                .WithJournals();

            _createJournalEntryValidator = new CreateJournalEntryValidator(
                new UserIdMustExistValidator(unitOfWork),
                new JournalIdMustExistValidator(unitOfWork.JournalRepository), 
                new JournalEntryContentIsRequiredValidator()
            );
        }

        #endregion

        [Theory]
        [InlineData(0, 1, "This is really limited content", "*User not found.*")]
        [InlineData(1, 0, "This is really limited content", "*Journal not found.*")]
        [InlineData(1, 1, null, "*Journal Entry Content is required.*")]
        [InlineData(1, 1, "", "*Journal Entry Content is required.*")]
        [InlineData(1, 1, " ", "*Journal Entry Content is required.*")]
        public void WhenCreatingAJournalEntry_WithInvalidArgs_ItThrowsAnInvalidCommandException(
            ulong userId,
            ulong journalId,
            string journalEntryContent,
            string errorMessage
        )
        {
            var createJournal = new CreateJournalEntry(
                new UserId(userId),
                new JournalId(journalId), 
                new JournalEntryTitle("Title"), 
                new JournalEntryContent(journalEntryContent)
            );

            Action validateCreateJournal = () => _createJournalEntryValidator.ValidateAndThrowCustom(createJournal);

            validateCreateJournal.Should()
                .Throw<Exception>()
                .WithMessage(errorMessage);
        }
    }
}
