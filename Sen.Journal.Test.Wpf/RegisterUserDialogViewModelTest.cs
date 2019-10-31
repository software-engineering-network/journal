using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using SoftwareEngineeringNetwork.JournalApplication.Services;
using SoftwareEngineeringNetwork.JournalApplication.Wpf;
using System.Linq;

namespace SoftwareEngineeringNetwork.JournalApplication.Test.Wpf
{
    [TestClass]
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

            var userManagementService = new UserManagementService(
                new CreateUserValidator(
                    new EmailAddressIsRequiredValidator(),
                    new EmailAddressMustBeValid(),
                    new EmailAddressMustNotExistValidator(unitOfWork.UserRepository),
                    new NameIsRequiredValidator(),
                    new PasswordIsRequiredValidator(),
                    new SurnameIsRequiredValidator(),
                    new UsernameIsRequiredValidator(),
                    new UsernameMustNotExistValidator(unitOfWork.UserRepository)
                ),
                unitOfWork,
                new UserFactory(unitOfWork.UserRepository)
            );

            _registerUserDialogViewModel = new RegisterUserDialogViewModel(
                userManagementService,
                new CreateJournalDialogViewModelFactory(
                    new JournalManagementService(
                        new CreateJournalValidator(
                            new UserIdMustExistValidator(unitOfWork),
                            new JournalTitleIsRequiredValidator(),
                            new JournalTitleMustNotExistValidator(unitOfWork)
                        ),
                        unitOfWork.JournalRepository
                    )
                )
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

        [TestMethod]
        public void WhenRegisteringAUser_ItBuildsACreateUserCommandFromItsProperties()
        {
            var emailAddress = "john.doe@gmail.com";
            var name = "John";
            var password = "peanutbuttereggdirt";
            var surname = "Doe";
            var username = "JohnDoe";

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

        [TestMethod]
        public void WhenRegisteringAUser_AUserIsPersisted()
        {
            // arrange
            UpdateCreateUserDialogViewModel(
                "john.doe@gmail.com",
                "John",
                "peanutbuttereggdirt",
                "Doe",
                "JohnDoe"
            );

            // act
            _registerUserDialogViewModel.RegisterUserCommand.Execute();

            // assert
            var user = _userService.Find(_registerUserDialogViewModel.Username);
            var targetUser = TestUserFactory
                .CreateJohnDoe(1)
                .ToUserDto();

            user.Should().BeEquivalentTo(targetUser);
        }
    }
}
