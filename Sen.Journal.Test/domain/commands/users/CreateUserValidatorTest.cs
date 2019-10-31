using System;
using FluentAssertions;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using Xunit;

namespace SoftwareEngineeringNetwork.JournalApplication.Test.Domain
{
    public class CreateUserValidatorTest
    {
        #region Fields

        private readonly CreateUserValidator _createUserValidator;

        #endregion

        #region Construction

        public CreateUserValidatorTest()
        {
            var unitOfWork = TestUnitOfWorkFactory
                .CreateUnitOfWork()
                .WithUsers();

            _createUserValidator = new CreateUserValidator(
                new EmailAddressIsRequiredValidator(),
                new EmailAddressMustBeValid(),
                new EmailAddressMustNotExistValidator(unitOfWork.UserRepository),
                new NameIsRequiredValidator(), 
                new PasswordIsRequiredValidator(), 
                new SurnameIsRequiredValidator(), 
                new UsernameIsRequiredValidator(),
                new UsernameMustNotExistValidator(unitOfWork.UserRepository)
            );
        }

        #endregion

        [Theory]
        [InlineData(null, "JamesDoe", "*Email Address is required.*")]
        [InlineData("", "JamesDoe", "*Email Address is required.*")]
        [InlineData(" ", "JamesDoe", "*Email Address is required.*")]
        [InlineData("john.doe@gmail.com", "JamesDoe", "*Email Address exists.*")]
        [InlineData("james.doe@gmail.com", null, "*Username is required.*")]
        [InlineData("james.doe@gmail.com", "", "*Username is required.*")]
        [InlineData("james.doe@gmail.com", " ", "*Username is required.*")]
        [InlineData("james.doe@gmail.com", "JohnDoe", "*Username exists.*")]
        public void WhenCreatingAUser_WithInvalidArgs_ItThrowsAnInvalidCommandException(
            string emailAddress,
            string username,
            string errorMessage
        )
        {
            // create command
            var createUser = new CreateUser(
                new EmailAddress(emailAddress),
                new Name("John"),
                new Password("peanutbuttereggdirt"),
                new Surname("Doe"),
                new Username(username)
            );

            // evaluate command when username already exists
            Action validate = () => _createUserValidator.ValidateAndThrowCustom(createUser);

            validate.Should()
                .Throw<InvalidCommandException>()
                .WithMessage(errorMessage);
        }
    }
}
