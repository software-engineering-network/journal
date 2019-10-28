using FluentValidation;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class EmailAddressIsRequiredValidator : AbstractValidator<IEmailAddressCommand>
    {
        #region Construction

        public EmailAddressIsRequiredValidator()
        {
            RuleFor(x => x.EmailAddress)
                .Must(x => !string.IsNullOrWhiteSpace(x.Value))
                .WithMessage("{PropertyName} is required.");
        }

        #endregion
    }
}
