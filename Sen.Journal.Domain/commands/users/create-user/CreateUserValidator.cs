using FluentValidation;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class CreateUserValidator : AbstractValidator<CreateUser>
    {
        #region Fields

        private readonly IUserRepository _userRepository;

        #endregion

        #region Construction

        public CreateUserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            RuleFor(x => x.Username)
                .Must(x => !_userRepository.UsernameExists(x));
        }

        #endregion
    }
}
