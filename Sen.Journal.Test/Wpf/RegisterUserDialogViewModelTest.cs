using FluentAssertions;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using SoftwareEngineeringNetwork.JournalApplication.Services;
using SoftwareEngineeringNetwork.JournalApplication.Wpf;
using Xunit;

namespace SoftwareEngineeringNetwork.JournalApplication.Test.Wpf
{
    public class RegisterUserDialogViewModelTest
    {
        #region Fields

        private readonly RegisterUserDialogViewModel _registerUserDialogViewModel;

        private readonly IUserService _userService;

        #endregion

        #region Construction

        public RegisterUserDialogViewModelTest()
        {
            var unitOfWork = TestUnitOfWorkFactory.CreateUnitOfWork();
            _userService = new UserService(unitOfWork.UserRepository);

            var notifyPropertyChanged = new NotifyPropertyChanged();

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

            _registerUserDialogViewModel = new RegisterUserDialogViewModel(
                notifyPropertyChanged,
                userManagementService
            );
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
            _registerUserDialogViewModel.EmailAddress = emailAddress;
            _registerUserDialogViewModel.Name = name;
            _registerUserDialogViewModel.Password = password;
            _registerUserDialogViewModel.Surname = surname;
            _registerUserDialogViewModel.Username = username;
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

            var createUser = _registerUserDialogViewModel.BuildCreateUserCommand();

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
            // arrange
            UpdateCreateUserDialogViewModel(
                emailAddress,
                name,
                password,
                surname,
                username
            );

            // act
            _registerUserDialogViewModel.RegisterUser();

            // assert
            var user = _userService.Find(_registerUserDialogViewModel.Username);
            var targetUser = TestUserFactory
                .CreateJohnDoe(1)
                .ToUserDto();

            user.Should().BeEquivalentTo(targetUser);
        }
    }
}
