using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Services
{
    public static class JournalEntryMapping
    {
        public static JournalEntryDto ToJournalEntryDto(this JournalEntry journalEntry)
        {
            return new JournalEntryDto(
                journalEntry.Id.Value,
                journalEntry.JournalEntryTitle.Value
            );
        }
    }
}
