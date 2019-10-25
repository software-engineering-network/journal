using System.Collections.Generic;
using System.Linq;
using SoftwareEngineeringNetwork.JournalApplication.Domain;

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

        public UserDetailsDto FindUserDetails(string username)
        {
            return _userRepository.Find(new Username(username)).ToUserDetailsDto();
        }

        public IEnumerable<UserDto> Fetch()
        {
            return _userRepository.Fetch().Select(x => x.ToUserDto());
        }

        public IEnumerable<UserDetailsDto> FetchUserDetails()
        {
            return _userRepository.Fetch().Select(x => x.ToUserDetailsDto());
        }

        public UserDto Find(string username)
        {
            return _userRepository.Find(new Username(username)).ToUserDto();
        }

        #endregion
    }
}
