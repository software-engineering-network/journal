using System.Collections.Generic;

namespace SoftwareEngineeringNetwork.JournalApplication.Services.Users
{
    public interface IUserService
    {
        IEnumerable<UserDto> Fetch();
        UserDto Find(string username);
    }
}
