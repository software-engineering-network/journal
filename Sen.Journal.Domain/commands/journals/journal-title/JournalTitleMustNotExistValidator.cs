using FluentValidation;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class JournalTitleMustNotExistValidator : AbstractValidator<IJournalTitleCommand>
    {
        #region Construction

        public JournalTitleMustNotExistValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.JournalTitle)
                .Must(x => !unitOfWork.JournalRepository.JournalTitleExists(x))
                .WithMessage("'{PropertyValue}' exists.");
        }

        #endregion
    }
}
