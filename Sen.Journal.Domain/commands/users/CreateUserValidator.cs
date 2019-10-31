﻿using FluentValidation;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class CreateUserValidator : AbstractValidator<CreateUser>
    {
        #region Construction

        public CreateUserValidator(
            EmailAddressIsRequiredValidator emailAddressIsRequiredValidator,
            EmailAddressMustBeValid emailAddressMustBeValid,
            EmailAddressMustNotExistValidator emailAddressMustNotExistValidator,
            NameIsRequiredValidator nameIsRequiredValidator,
            PasswordIsRequiredValidator passwordIsRequiredValidator,
            SurnameIsRequiredValidator surnameIsRequiredValidator,
            UsernameIsRequiredValidator usernameIsRequiredValidator,
            UsernameMustNotExistValidator usernameMustNotExistValidator
        )
        {
            Include(emailAddressIsRequiredValidator);
            Include(emailAddressMustBeValid);
            Include(emailAddressMustNotExistValidator);
            Include(nameIsRequiredValidator);
            Include(passwordIsRequiredValidator);
            Include(surnameIsRequiredValidator);
            Include(usernameIsRequiredValidator);
            Include(usernameMustNotExistValidator);
        }

        #endregion
    }
}
