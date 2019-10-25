namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public interface IJournalEntryManager
    {
        IJournalEntryManager CreateJournalEntry(CreateJournalEntry createJournalEntry);
    }
}