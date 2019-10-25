namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public interface IJournalEntryRepository : IRepository<JournalEntry>
    {
        JournalEntry Find(JournalId journalId, JournalEntryTitle journalEntryTitle);
    }
}