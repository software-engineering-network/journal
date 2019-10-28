using FluentValidation;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class JournalIdMustExistValidator : AbstractValidator<IJournalIdCommand>
    {
        public JournalIdMustExistValidator(IJournalRepository journalRepository)
        {
            RuleFor(x => x.JournalId)
                .Must(journalRepository.Exists)
                .WithMessage("Journal not found.");
        }
    }
}
