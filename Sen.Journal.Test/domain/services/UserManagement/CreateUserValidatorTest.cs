using FluentAssertions;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using SoftwareEngineeringNetwork.JournalApplication.Infrastructure.InMemory;
using Xunit;

namespace SoftwareEngineeringNetwork.JournalApplication.Test.UserManagement
{
    public class CreateUserValidatorTest
    {
        private readonly CreateUserValidator _createUserValidator;

        public CreateUserValidatorTest()
        {
            var unitOfWork = TestUnitOfWorkFactory
                .CreateUnitOfWork()
                .WithUsers();

            _createUserValidator = new CreateUserValidator(unitOfWork.UserRepository);
        }

        [Theory]
        [InlineData(
            "john.doe@gmail.com",
            "John",
            "peanutbuttereggdirt",
            "Doe",
            "JohnDoe"
        )]
        public void WhenCreatingAUser_WithAnExistingUsername_NoUserIsCreated(
            string emailAddress,
            string name,
            string password,
            string surname,
            string username
        )
        {
            // create command
            var createUser = new CreateUser(
                new EmailAddress(emailAddress),
                new Name(name),
                new Password(password),
                new Surname(surname),
                new Username(username)
            );

            // evaluate command when username already exists
            var validationResult = _createUserValidator.Validate(createUser);

            validationResult.IsValid.Should().Be(false);
        }
    }
}
