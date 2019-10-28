using FluentValidation;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class CreateJournalValidator : AbstractValidator<CreateJournal>
    {
        #region Construction

        public CreateJournalValidator(
            UserIdMustExistValidator userIdMustExistValidator,
            JournalTitleMustNotBeNullOrWhitespaceValidator journalTitleMustNotBeNullOrWhitespaceValidator,
            JournalTitleMustNotExistValidator journalTitleMustNotExistValidator
        )
        {
            Include(userIdMustExistValidator);
            Include(journalTitleMustNotBeNullOrWhitespaceValidator);
            Include(journalTitleMustNotExistValidator);
        }

        #endregion
    }
}
