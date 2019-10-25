using SoftwareEngineeringNetwork.JournalApplication.Services.Users;

namespace SoftwareEngineeringNetwork.JournalApplication.Services.Journals
{
    public class JournalDto : IEntityDto
    {
        #region Properties

        public ulong UserId { get; }

        #endregion

        #region Construction

        public JournalDto(
            ulong id,
            ulong userId,
            string displayName
        )
        {
            Id = id;
            UserId = userId;
            DisplayName = displayName;
        }

        #endregion

        #region IEntityDto Members

        public ulong Id { get; }
        public string DisplayName { get; }

        #endregion
    }
}