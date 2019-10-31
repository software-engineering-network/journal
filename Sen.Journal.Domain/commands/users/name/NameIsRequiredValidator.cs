using FluentValidation;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class NameIsRequiredValidator : AbstractValidator<INameCommand>
    {
        #region Construction

        public NameIsRequiredValidator()
        {
            RuleFor(x => x.Name)
                .Must(x => !string.IsNullOrWhiteSpace(x.Value))
                .WithMessage("{PropertyName} is required.");
        }

        #endregion
    }
}