using FluentAssertions;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using SoftwareEngineeringNetwork.JournalApplication.Infrastructure.InMemory;
using Xunit;

namespace SoftwareEngineeringNetwork.JournalApplication.Test.UserManagement
{
    public class CreateUserValidatorTest
    {
        private readonly CreateUserValidator _createUserValidator;
        private readonly UserManager _userManager;

        public CreateUserValidatorTest()
        {
            var userRepository = new UserRepository();
            _createUserValidator = new CreateUserValidator(userRepository);
            _userManager = new UserManager(userRepository);
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

            // setup storage
            _userManager.CreateUser(createUser);

            // evaluate command when username already exists
            var validationResult = _createUserValidator.Validate(createUser);

            validationResult.IsValid.Should().Be(false);
        }
    }
}
