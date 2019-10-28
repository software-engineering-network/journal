using FluentValidation;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class JournalTitleMustNotBeNullOrWhitespaceValidator : AbstractValidator<IJournalTitleCommand>
    {
        #region Construction

        public JournalTitleMustNotBeNullOrWhitespaceValidator()
        {
            RuleFor(x => x.JournalTitle.Value)
                .NotEmpty()
                .WithMessage("Please set a 'Journal Title'.");
        }

        #endregion
    }
}
