namespace SoftwareEngineeringNetwork.JournalApplication.Services
{
    public interface IJournalService
    {
        JournalDto Find(ulong userId, string journalTitle);
    }
}
