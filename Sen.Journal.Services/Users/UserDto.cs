namespace SoftwareEngineeringNetwork.JournalApplication.Services
{
    public class UserDto : IEntityDto
    {
        #region Construction

        public UserDto(ulong id, string displayName)
        {
            Id = id;
            DisplayName = displayName;
        }

        #endregion

        #region IEntityDto Members

        public ulong Id { get; }
        public string DisplayName { get; }

        #endregion
    }
}
