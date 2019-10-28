using FluentValidation;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class JournalEntryContentIsRequiredValidator : AbstractValidator<IJournalEntryContentCommand>
    {
        #region Construction

        public JournalEntryContentIsRequiredValidator()
        {
            RuleFor(x => x.JournalEntryContent)
                .Must(x => !string.IsNullOrWhiteSpace(x.Value))
                .WithMessage("{PropertyName} is required.");
        }

        #endregion
    }
}