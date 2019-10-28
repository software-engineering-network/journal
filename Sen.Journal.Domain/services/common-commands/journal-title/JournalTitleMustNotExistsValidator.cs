using FluentValidation;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class JournalTitleMustNotExistsValidator : AbstractValidator<IJournalTitleCommand>
    {
        #region Construction

        public JournalTitleMustNotExistsValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.JournalTitle)
                .Must(x => !unitOfWork.JournalRepository.JournalTitleExists(x))
                .WithMessage("Cannot create duplicate '{PropertyName}' '{PropertyValue}'");
        }

        #endregion
    }
}
