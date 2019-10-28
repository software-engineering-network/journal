using System;
using FluentAssertions;
using FluentValidation;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using Xunit;

namespace SoftwareEngineeringNetwork.JournalApplication.Test.JournalManagement
{
    public class CreateJournalValidatorTest
    {
        #region Fields

        private readonly CreateJournalValidator _createJournalValidator;

        #endregion

        #region Construction

        public CreateJournalValidatorTest()
        {
            var unitOfWork = TestUnitOfWorkFactory
                .CreateUnitOfWork()
                .WithUsers()
                .WithJournals();

            var userIdMustExistValidator = new UserIdMustExistValidator(unitOfWork);
            var journalTitleMustExistValidator = new JournalTitleMustNotExistsValidator(unitOfWork);

            _createJournalValidator = new CreateJournalValidator(
                userIdMustExistValidator,
                journalTitleMustExistValidator
            );
        }

        #endregion

        [Theory]
        [InlineData(0, "New Journal Title", "Cannot create journal because the associated user was not found.")]
        [InlineData(1, "Existing Journal Title", "Journal \'Existing Journal Title\' already exists.")]
        public void WhenCreatingAJournal_WithInvalidArgs_TheCorrectExceptionIsThrown(
            ulong userId,
            string journalTitle,
            params string[] errorMessage
        )
        {
            var createJournal = new CreateJournal(
                new UserId(userId),
                new JournalTitle(journalTitle)
            );

            Action validateCreateJournal = () => _createJournalValidator.ValidateAndThrow(createJournal);

            validateCreateJournal.Should().Throw<Exception>(errorMessage[0]);
        }
    }
}
