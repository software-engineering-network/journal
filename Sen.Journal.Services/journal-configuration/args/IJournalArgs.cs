namespace SoftwareEngineeringNetwork.JournalApplication.Services
{
    public interface IJournalArgs : IPersonForeignKeyArgs
    {
        string JournalTitle { get; set; }
    }
}
