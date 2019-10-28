using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Services
{
    public class UserManagementService : IUserManagementService
    {
        #region Fields

        private readonly CreateUserValidator _createUserValidator;
        private readonly UserManager _userManager;

        #endregion

        #region Construction

        public UserManagementService(
            UserManager userManager,
            CreateUserValidator createUserValidator
        )
        {
            _userManager = userManager;
            _createUserValidator = createUserValidator;
        }

        #endregion

        #region IUserManagementService Members

        public void CreateUser(CreateUser createUser)
        {
            _createUserValidator.ValidateAndThrowCustom(createUser);



            _userManager.CreateUser(createUser);
        }

        #endregion
    }
}
