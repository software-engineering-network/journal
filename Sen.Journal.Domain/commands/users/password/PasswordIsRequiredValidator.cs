using FluentValidation;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class PasswordIsRequiredValidator : AbstractValidator<IPasswordCommand>
    {
        #region Construction

        public PasswordIsRequiredValidator()
        {
            RuleFor(x => x.Password)
                .Must(x => !string.IsNullOrWhiteSpace(x.Value))
                .WithMessage("{PropertyName} is required.");
        }

        #endregion
    }
}
