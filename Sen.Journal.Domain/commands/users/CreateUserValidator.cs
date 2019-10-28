using FluentValidation;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class CreateUserValidator : AbstractValidator<CreateUser>
    {
        #region Construction

        public CreateUserValidator(
            EmailAddressIsRequiredValidator emailAddressIsRequiredValidator,
            EmailAddressMustNotExistValidator emailAddressMustNotExistValidator,
            UsernameIsRequiredValidator usernameIsRequiredValidator,
            UsernameMustNotExistValidator usernameMustNotExistValidator
        )
        {
            Include(emailAddressIsRequiredValidator);
            Include(emailAddressMustNotExistValidator);
            Include(usernameIsRequiredValidator);
            Include(usernameMustNotExistValidator);
        }

        #endregion
    }
}
