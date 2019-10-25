namespace SoftwareEngineeringNetwork.JournalApplication.Services
{
    public class JournalEntryDto : IEntityDto
    {
        #region Fields

        private readonly IEntityDto _entityDto;

        #endregion

        #region Construction

        public JournalEntryDto(ulong id, string displayName)
        {
            _entityDto = new EntityDto(id, displayName);
        }

        #endregion

        #region IEntityDto Members

        public ulong Id => _entityDto.Id;

        public string DisplayName => _entityDto.DisplayName;

        #endregion
    }
}