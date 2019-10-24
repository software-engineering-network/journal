using FluentValidation;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain.UserManagement
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        #region Fields

        private readonly IUserRepository _userRepository;

        #endregion

        #region Construction

        public CreateUserCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            RuleFor(x => x.Username)
                .Must(x => !_userRepository.UsernameExists(x));
        }

        #endregion
    }
}
