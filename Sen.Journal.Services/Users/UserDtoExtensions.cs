using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Services
{
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