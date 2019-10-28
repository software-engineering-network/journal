using FluentValidation;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class CreateJournalValidator : AbstractValidator<CreateJournal>
    {
        #region Construction

        public CreateJournalValidator(
            UserIdMustExistValidator userIdMustExistValidator,
            JournalTitleMustNotExistsValidator journalTitleMustNotExistsValidator
        )
        {
            Include(userIdMustExistValidator);
            Include(journalTitleMustNotExistsValidator);
        }

        #endregion
    }
}
