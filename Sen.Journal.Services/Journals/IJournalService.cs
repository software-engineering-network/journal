namespace SoftwareEngineeringNetwork.JournalApplication.Services.Journals
{
    public interface IJournalService
    {
        JournalDto Find(ulong userId, string journalTitle);
    }
}
