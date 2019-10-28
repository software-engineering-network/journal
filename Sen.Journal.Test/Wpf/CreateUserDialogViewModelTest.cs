using FluentAssertions;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using SoftwareEngineeringNetwork.JournalApplication.Services;
using SoftwareEngineeringNetwork.JournalApplication.Wpf;
using Xunit;

namespace SoftwareEngineeringNetwork.JournalApplication.Test.Wpf
{
    public class CreateUserDialogViewModelTest
    {
        #region Fields

        private readonly IUserService _userService;
        private readonly CreateUserDialogViewModel _createUserDialogViewModel;

        #endregion

        #region Construction

        public CreateUserDialogViewModelTest()
        {
            var unitOfWork = TestUnitOfWorkFactory.CreateUnitOfWork();
            _userService = new UserService(unitOfWork.UserRepository);

            var userManagementService = new UserManagementService(
                new CreateUserValidator(
                    new EmailAddressIsRequiredValidator(),
                    new EmailAddressMustNotExistValidator(unitOfWork.UserRepository),
                    new UsernameIsRequiredValidator(),
                    new UsernameMustNotExistValidator(unitOfWork.UserRepository)
                ),
                unitOfWork,
                new UserFactory(unitOfWork.UserRepository)
            );

            _createUserDialogViewModel = new CreateUserDialogViewModel(userManagementService);
        }

        #endregion

        private void UpdateCreateUserDialogViewModel(
            string emailAddress,
            string name,
            string password,
            string surname,
            string username
        )
        {
            _createUserDialogViewModel.EmailAddress = emailAddress;
            _createUserDialogViewModel.Name = name;
            _createUserDialogViewModel.Password = password;
            _createUserDialogViewModel.Surname = surname;
            _createUserDialogViewModel.Username = username;
        }

        [Theory]
        [InlineData(
            "john.doe@gmail.com",
            "John",
            "peanutbuttereggdirt",
            "Doe",
            "JohnDoe"
        )]
        public void WhenRegisteringAUser_ItBuildsACreateUserCommandFromItsProperties(
            string emailAddress,
            string name,
            string password,
            string surname,
            string username
        )
        {
            UpdateCreateUserDialogViewModel(
                emailAddress,
                name,
                password,
                surname,
                username
            );

            var createUser = _createUserDialogViewModel.CreateCreateUser();

            var targetCreateUser = new CreateUser(
                new EmailAddress(emailAddress),
                new Name(name),
                new Password(password),
                new Surname(surname),
                new Username(username)
            );

            createUser.Should().BeEquivalentTo(targetCreateUser);
        }

        [Theory]
        [InlineData(
            "john.doe@gmail.com",
            "John",
            "peanutbuttereggdirt",
            "Doe",
            "JohnDoe"
        )]
        public void WhenRegisteringAUser_AUserIsPersisted(
            string emailAddress,
            string name,
            string password,
            string surname,
            string username
        )
        {
            UpdateCreateUserDialogViewModel(
                emailAddress,
                name,
                password,
                surname,
                username
            );

            _createUserDialogViewModel.RegisterUser();

            var user = _userService.Find(_createUserDialogViewModel.Username);

            var targetUser = TestUserFactory.CreateJohnDoe(1).ToUserDto();

            user.Should().BeEquivalentTo(targetUser);
        }
    }
}
