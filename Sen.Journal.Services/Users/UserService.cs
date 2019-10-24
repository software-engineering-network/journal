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

    public static class UserDtoExtensions
    {
        public static UserDto ToUserDto(this User user)
        {
            return new UserDto(
                user.Id.Value,
                user.Username.Value
            );
        }

        public static UserDetailsDto ToUserDetailsDto(this User user)
        {
            return new UserDetailsDto(
                user.Id.Value,
                user.EmailAddress.Value,
                user.Name.Value,
                user.Password.Value,
                user.RecordName.Value,
                user.Surname.Value,
                user.Username.Value
            );
        }
    }
}
