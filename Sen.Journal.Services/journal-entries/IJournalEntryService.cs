namespace SoftwareEngineeringNetwork.JournalApplication.Services
{
    public interface IJournalEntryService
    {
        JournalEntryDto Find(ulong journalId, string journalEntryTitle);
    }
}