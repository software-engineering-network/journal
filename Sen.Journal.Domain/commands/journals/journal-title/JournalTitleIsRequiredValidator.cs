using FluentValidation;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class JournalTitleIsRequiredValidator : AbstractValidator<IJournalTitleCommand>
    {
        #region Construction

        public JournalTitleIsRequiredValidator()
        {
            RuleFor(x => x.JournalTitle)
                .Must(x => x != null && !string.IsNullOrWhiteSpace(x.Value))
                .WithMessage("{PropertyName} is required.");
        }

        #endregion
    }
}
