namespace SoftwareEngineeringNetwork.JournalApplication.Services.Users
{
    public interface IEntityDto
    {
        #region Properties

        ulong Id { get; }
        string DisplayName { get; }

        #endregion
    }
}
