using FluentValidation;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class UsernameIsRequiredValidator : AbstractValidator<IUsernameCommand>
    {
        #region Construction

        public UsernameIsRequiredValidator()
        {
            RuleFor(x => x.Username)
                .Must(x => !string.IsNullOrWhiteSpace(x.Value))
                .WithMessage("{PropertyName} is required.");
        }

        #endregion
    }
}
