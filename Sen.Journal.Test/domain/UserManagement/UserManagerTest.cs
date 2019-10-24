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
            var createUser = new CreateUser(
                new EmailAddress(emailAddress),
                new Name(name),
                new Password(password),
                new Surname(surname),
                new Username(username)
            );

            _userManager.CreateUser(createUser);
            var user = _userService.FindUserDetails(username);

            user.Should().NotBeNull();
            user.RecordName.Should().Be("jdoe");
        }

        [Fact]
        public void WhenCreatingSimilarUsers_DifferentRecordNamesArePersisted()
        {
            var createJohnDoe = new CreateUser(
                new EmailAddress("john.doe@gmail.com"),
                new Name("John"),
                new Password("peanutbuttereggdirt"),
                new Surname("Doe"),
                new Username("JohnDoe")
            );

            var createJaneDoe = new CreateUser(
                new EmailAddress("jane.doe@gmail.com"),
                new Name("Jane"),
                new Password("peanutbuttereggdirt"),
                new Surname("Doe"),
                new Username("JaneDoe")
            );

            var createJamesDoe = new CreateUser(
                new EmailAddress("james.doe@gmail.com"),
                new Name("James"),
                new Password("peanutbuttereggdirt"),
                new Surname("Doe"),
                new Username("JamesDoe")
            );

            _userManager.CreateUser(createJohnDoe);
            _userManager.CreateUser(createJaneDoe);
            _userManager.CreateUser(createJamesDoe);

            var johnDoe = _userService.FindUserDetails("JohnDoe");
            var janeDoe = _userService.FindUserDetails("JaneDoe");
            var jamesDoe = _userService.FindUserDetails("JamesDoe");

            johnDoe.RecordName.Should().Be("jdoe");
            janeDoe.RecordName.Should().Be("jdoe1");
            jamesDoe.RecordName.Should().Be("jdoe2");
        }
    }
}
