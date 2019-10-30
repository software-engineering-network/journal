using FluentValidation;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class CreateUserValidator : AbstractValidator<CreateUser>
    {
        #region Construction

        public CreateUserValidator(
            EmailAddressIsRequiredValidator emailAddressIsRequiredValidator,
            EmailAddressMustBeValid emailAddressMustBeValid,
            EmailAddressMustNotExistValidator emailAddressMustNotExistValidator,
            UsernameIsRequiredValidator usernameIsRequiredValidator,
            UsernameMustNotExistValidator usernameMustNotExistValidator
        )
        {
            Include(emailAddressIsRequiredValidator);
            Include(emailAddressMustBeValid);
            Include(emailAddressMustNotExistValidator);
            Include(usernameIsRequiredValidator);
            Include(usernameMustNotExistValidator);
        }

        #endregion
    }
}
