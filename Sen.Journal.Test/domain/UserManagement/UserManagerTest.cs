using System.Linq;
using FluentAssertions;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using SoftwareEngineeringNetwork.JournalApplication.Infrastructure.InMemory.UserManagement;
using SoftwareEngineeringNetwork.JournalApplication.Services.Users;
using Xunit;

namespace SoftwareEngineeringNetwork.JournalApplication.Test.Domain.UserManagement
{
    public class UserManagerTest
    {
        #region Setup/Teardown

        public UserManagerTest()
        {
            var userRepository = new UserRepository();
            _userManager = new UserManager(userRepository);
            _userService = new UserService(userRepository);
        }

        #endregion

        private readonly UserManager _userManager;
        private readonly IUserService _userService;

        private static CreateUser CreateADoeCommand(string name = "John")
        {
            return new CreateUser(
                new EmailAddress($"{name}.doe@gmail.com"),
                new Name(name),
                new Password("peanutbuttereggdirt"),
                new Surname("Doe"),
                new Username($"{name}Doe")
            );
        }

        [Fact]
        public void WhenCreatingAUser_AUserIsPersisted()
        {
            var createUser = CreateADoeCommand();

            _userManager.CreateUser(createUser);
            var johnDoe = _userService.FindUserDetails(createUser.Username.Value);

            johnDoe.Should().NotBeNull();
            johnDoe.RecordName.Should().Be("jdoe");
        }

        [Fact]
        public void WhenCreatingSimilarUsers_DifferentRecordNamesArePersisted()
        {
            var createJohnDoe = CreateADoeCommand();
            var createJaneDoe = CreateADoeCommand("Jane");
            var createJamesDoe = CreateADoeCommand("James");

            _userManager
                .CreateUser(createJohnDoe)
                .CreateUser(createJaneDoe)
                .CreateUser(createJamesDoe);

            var users = _userService.FetchUserDetails().ToList();

            var johnDoe = users.Single(x => x.Name == "John");
            var janeDoe = users.Single(x => x.Name == "Jane");
            var jamesDoe = users.Single(x => x.Name == "James");

            johnDoe.RecordName.Should().Be("jdoe");
            janeDoe.RecordName.Should().Be("jdoe1");
            jamesDoe.RecordName.Should().Be("jdoe2");
        }
    }
}
