using FluentValidation;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class CreateJournalValidator : AbstractValidator<CreateJournal>
    {
        #region Construction

        public CreateJournalValidator(
            UserIdMustExistValidator userIdMustExistValidator,
            JournalTitleMustNotExistValidator journalTitleMustNotExistValidator
        )
        {
            Include(userIdMustExistValidator);
            Include(journalTitleMustNotExistValidator);
        }

        #endregion
    }
}
