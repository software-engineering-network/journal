using FluentValidation;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class UsernameMustNotExistValidator : AbstractValidator<IUsernameCommand>
    {
        #region Construction

        public UsernameMustNotExistValidator(IUserRepository userRepository)
        {
            RuleFor(x => x.Username)
                .Must(x => !userRepository.UsernameExists(x))
                .WithMessage("{PropertyName} exists.");
        }

        #endregion
    }
}
