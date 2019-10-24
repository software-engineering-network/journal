using System.Collections.Generic;
using System.Linq;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
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
            return _userRepository.Fetch().Select(x => x.ToDto());
        }

        public UserDto Find(string username)
        {
            return _userRepository.Find(new Username(username)).ToDto();
        }

        #endregion
    }

    public static class UserDtoExtensions
    {
        public static UserDto ToDto(this User user)
        {
            return new UserDto(
                user.Id.Value,
                user.Username.Value
            );
        }
    }
}
