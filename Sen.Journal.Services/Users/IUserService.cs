using System.Collections.Generic;

namespace SoftwareEngineeringNetwork.JournalApplication.Services.Users
{
    public interface IUserService
    {
        UserDetailsDto FindUserDetails(string username);
        IEnumerable<UserDto> Fetch();
        IEnumerable<UserDetailsDto> FetchUserDetails();
        UserDto Find(string username);
    }
}
