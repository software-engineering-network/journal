using FluentValidation;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class SurnameIsRequiredValidator : AbstractValidator<ISurnameCommand>
    {
        #region Construction

        public SurnameIsRequiredValidator()
        {
            RuleFor(x => x.Surname)
                .Must(x => !string.IsNullOrWhiteSpace(x.Value))
                .WithMessage("{PropertyName} is required.");
        }

        #endregion
    }
}