using System.Linq;
using FluentAssertions;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using SoftwareEngineeringNetwork.JournalApplication.Domain.UserManagement;
using SoftwareEngineeringNetwork.JournalApplication.Infrastructure.InMemory.UserRegistration;
using Xunit;

namespace SoftwareEngineeringNetwork.JournalApplication.Test.Domain.UserManagement
{
    public class UserManagerTest
    {
        #region Fields

        private readonly UserManager _userManager;
        private readonly IUserRepository _userRepository;

        #endregion

        #region Construction

        public UserManagerTest()
        {
            _userRepository = new UserRepository();
            _userManager = CreateUserManager(_userRepository);
        }

        #endregion

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
            var createUserCommand = new CreateUser(
                new EmailAddress(emailAddress),
                new Name(name),
                new Password(password),
                new Surname(surname),
                new Username(username)
            );

            _userManager.CreateUser(createUserCommand);
            _userManager.CreateUser(createUserCommand);

            _userRepository.Fetch().Count().Should().Be(1);
        }

        [Theory]
        [InlineData(
            "john.doe@gmail.com",
            "John",
            "peanutbuttereggdirt",
            "Doe",
            "JohnDoe"
        )]
        public void WhenCreatingAUser_WithValidArgs_AUserIsCreated(
            string emailAddress,
            string name,
            string password,
            string surname,
            string username
        )
        {
            var createUserCommand = new CreateUser(
                new EmailAddress(emailAddress),
                new Name(name),
                new Password(password),
                new Surname(surname),
                new Username(username)
            );

            _userManager.CreateUser(createUserCommand);

            _userRepository.Fetch().Count().Should().Be(1);
        }

        private static UserManager CreateUserManager(IUserRepository userRepository)
        {
            var createUserCommandValidator = new CreateUserValidator(userRepository);

            return new UserManager(
                userRepository,
                createUserCommandValidator
            );
        }
    }
}
