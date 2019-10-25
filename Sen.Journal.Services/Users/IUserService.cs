using System.Collections.Generic;

namespace SoftwareEngineeringNetwork.JournalApplication.Services
{
    public interface IUserService
    {
        UserDetailsDto FindUserDetails(string username);
        IEnumerable<UserDto> Fetch();
        IEnumerable<UserDetailsDto> FetchUserDetails();
        UserDto Find(string username);
    }
}
