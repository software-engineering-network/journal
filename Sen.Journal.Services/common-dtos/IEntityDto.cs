namespace SoftwareEngineeringNetwork.JournalApplication.Services
{
    public interface IEntityDto
    {
        #region Properties

        ulong Id { get; }
        string DisplayName { get; }

        #endregion
    }

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
