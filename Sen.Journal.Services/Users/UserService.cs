using System.Collections.Generic;
using System.Linq;
using SoftwareEngineeringNetwork.JournalApplication.Domain.UserManagement;

namespace SoftwareEngineeringNetwork.JournalApplication.Services.Users
{
    public class UserService : IUserService
    {
        #region Fields

        private readonly IUserRepository _userRepository;

        #endregion

        #region Construction

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion

        #region IUserService Members

        public IEnumerable<UserDto> Fetch()
        {
            return _userRepository
                .Fetch()
                .Select(
                    x => new UserDto(
                        x.Id.Value,
                        x.Username.Value
                    )
                );
        }

        #endregion
    }
}
