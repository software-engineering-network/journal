using FluentValidation;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class CreateJournalEntryValidator : AbstractValidator<CreateJournalEntry>
    {
        #region Construction

        public CreateJournalEntryValidator(
            UserIdMustExistValidator userIdMustExistValidator,
            JournalIdMustExistValidator journalIdMustExistValidator,
            JournalEntryContentIsRequiredValidator journalEntryContentIsRequiredValidator
        )
        {
            Include(userIdMustExistValidator);
            Include(journalIdMustExistValidator);
            Include(journalEntryContentIsRequiredValidator);
        }

        #endregion
    }
}
