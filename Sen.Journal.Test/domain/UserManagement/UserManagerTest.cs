using System.Linq;
using FluentAssertions;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using SoftwareEngineeringNetwork.JournalApplication.Domain.UserManagement;
using SoftwareEngineeringNetwork.JournalApplication.Infrastructure.InMemory.UserManagement;
using SoftwareEngineeringNetwork.JournalApplication.Services.Users;
using Xunit;

namespace SoftwareEngineeringNetwork.JournalApplication.Test.Domain.UserManagement
{
    public class UserManagerTest
    {
        #region Fields

        private readonly UserManager _userManager;
        private readonly IUserService _userService;

        #endregion

        #region Construction

        public UserManagerTest()
        {
            var userRepository = new UserRepository();
            _userManager = new UserManager(userRepository);
            _userService = new UserService(userRepository);
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
        public void WhenCreatingAUser_AUserIsPersisted(
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

            _userService.Fetch().Count().Should().Be(1);
        }
    }
}
