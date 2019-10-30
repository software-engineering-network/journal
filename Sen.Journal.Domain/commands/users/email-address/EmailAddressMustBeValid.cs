using FluentValidation;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class EmailAddressMustBeValid : AbstractValidator<IEmailAddressCommand>
    {
        #region Construction

        public EmailAddressMustBeValid()
        {
            RuleFor(x => x.EmailAddress.Value)
                .EmailAddress()
                .WithMessage(x => $"'{x.EmailAddress.Value}' is not a valid email address.");
        }

        #endregion
    }
}
