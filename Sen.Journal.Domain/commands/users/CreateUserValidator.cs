using FluentValidation;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class CreateUserValidator : AbstractValidator<CreateUser>
    {
        #region Construction

        public CreateUserValidator(IUserRepository userRepository)
        {
            RuleFor(x => x.Username)
                .Must(x => !userRepository.UsernameExists(x));
        }

        #endregion
    }
}
