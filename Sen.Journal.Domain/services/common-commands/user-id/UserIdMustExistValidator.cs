using FluentValidation;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class UserIdMustExistValidator : AbstractValidator<IUserIdCommand>
    {
        #region Construction

        public UserIdMustExistValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.UserId)
                .Must(x => unitOfWork.UserRepository.UserIdExists(x));
        }

        #endregion
    }
}
