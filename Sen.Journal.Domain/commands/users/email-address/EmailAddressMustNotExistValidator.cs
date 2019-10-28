using FluentValidation;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class EmailAddressMustNotExistValidator : AbstractValidator<IEmailAddressCommand>
    {
        #region Construction

        public EmailAddressMustNotExistValidator(IUserRepository userRepository)
        {
            RuleFor(x => x.EmailAddress)
                .Must(x => !userRepository.EmailAddressExists(x))
                .WithMessage("{PropertyName} exists.");
        }

        #endregion
    }
}
