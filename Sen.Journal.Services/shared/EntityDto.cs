namespace SoftwareEngineeringNetwork.JournalApplication.Services
{
    public class EntityDto : IEntityDto
    {
        #region Construction

        public EntityDto(ulong id, string displayName)
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