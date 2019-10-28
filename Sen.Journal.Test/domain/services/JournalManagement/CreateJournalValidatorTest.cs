using System;
using FluentAssertions;
using FluentValidation;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using SoftwareEngineeringNetwork.JournalApplication.Services;
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
            var journalTitleMustExistValidator = new JournalTitleMustNotExistValidator(unitOfWork);

            _createJournalValidator = new CreateJournalValidator(
                userIdMustExistValidator,
                journalTitleMustExistValidator
            );
        }

        #endregion

        [Theory]
        [InlineData(0, "New Journal Title", "Cannot find user.")]
        [InlineData(1, "Existing Journal Title", "Cannot create duplicate 'Journal Title' 'Existing Journal Title'")]
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

            Action validateCreateJournal = () => _createJournalValidator.ValidateAndThrowCustom(createJournal);

            validateCreateJournal.Should()
                .Throw<Exception>()
                .WithMessage(errorMessage[0]);
        }
    }
}
