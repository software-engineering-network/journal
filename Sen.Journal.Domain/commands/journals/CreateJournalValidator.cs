using FluentValidation;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class CreateJournalValidator : AbstractValidator<CreateJournal>
    {
        #region Construction

        public CreateJournalValidator(
            UserIdMustExistValidator userIdMustExistValidator,
            JournalTitleIsRequiredValidator journalTitleIsRequiredValidator,
            JournalTitleMustNotExistValidator journalTitleMustNotExistValidator
        )
        {
            Include(userIdMustExistValidator);
            Include(journalTitleIsRequiredValidator);
            Include(journalTitleMustNotExistValidator);
        }

        #endregion
    }
}
