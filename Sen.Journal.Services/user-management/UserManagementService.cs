using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Services
{
    public class UserManagementService : IUserManagementService
    {
        #region Fields

        private readonly CreateUserValidator _createUserValidator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserFactory _userFactory;

        #endregion

        #region Construction

        public UserManagementService(
            CreateUserValidator createUserValidator,
            IUnitOfWork unitOfWork,
            IUserFactory userFactory
        )
        {
            _createUserValidator = createUserValidator;
            _unitOfWork = unitOfWork;
            _userFactory = userFactory;
        }

        #endregion

        #region IUserManagementService Members

        public IUserManagementService CreateUser(CreateUser createUser)
        {
            _createUserValidator.ValidateAndThrowCustom(createUser);

            var user = _userFactory.CreateUser(createUser);

            _unitOfWork.UserRepository.Create(user);

            return this;
        }

        #endregion
    }
}
