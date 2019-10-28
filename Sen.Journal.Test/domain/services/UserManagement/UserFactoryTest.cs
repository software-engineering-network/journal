using FluentAssertions;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using Xunit;

namespace SoftwareEngineeringNetwork.JournalApplication.Test.UserManagement
{
    public class UserFactoryTest
    {
        #region Setup/Teardown

        public UserFactoryTest()
        {
            var unitOfWork = TestUnitOfWorkFactory.CreateUnitOfWork();
            _userFactory = new UserFactory(unitOfWork.UserRepository);
        }

        #endregion

        private readonly UserFactory _userFactory;

        [Fact]
        public void WhenCreatingAUser_ItReturnsAUserWithANewRecordName()
        {
            var createUser = new CreateUser(
                new EmailAddress("john.doe@gmail.com"),
                new Name("John"),
                new Password("peanutbuttereggdirt"),
                new Surname("Doe"),
                new Username("JohnDoe")
            );

            var user = _userFactory.CreateUser(createUser);

            user.RecordName.Should().Be("jdoe");
        }

        [Fact]
        public void WhenCreatingAUser_ThatWouldCreateADuplicateRecordName_ItReturnsAUserWithAnIncrementedRecordName()
        {
            var unitOfWork = TestUnitOfWorkFactory
                .CreateUnitOfWork()
                .WithUsers();

            var userFactory = new UserFactory(unitOfWork.UserRepository);

            var createUser = new CreateUser(
                new EmailAddress("james.doe@gmail.com"),
                new Name("James"),
                new Password("peanutbuttereggdirt"),
                new Surname("Doe"),
                new Username("JamesDoe")
            );

            var user = userFactory.CreateUser(createUser);

            user.RecordName.Should().Be("jdoe2");
        }
    }
}
