namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class JournalEntry : Entity
    {
        public UserId UserId { get; set; }
        public JournalId JournalId { get; set; }
        public JournalEntryTitle JournalEntryTitle { get; set; }
        public JournalEntryContent JournalEntryContent { get; set; }
    }
}
