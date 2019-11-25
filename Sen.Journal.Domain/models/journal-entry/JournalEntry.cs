namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class JournalEntry : Entity
    {
        #region Properties

        public UserId UserId { get; set; }
        public JournalId JournalId { get; set; }
        public JournalEntryTitle JournalEntryTitle { get; set; }
        public JournalEntryContent JournalEntryContent { get; set; }

        #endregion

        #region Construction

        public JournalEntry(
            UserId userId,
            JournalId journalId,
            JournalEntryTitle journalEntryTitle,
            JournalEntryContent journalEntryContent
        ) : base(null)
        {
            UserId = userId;
            JournalId = journalId;
            JournalEntryTitle = journalEntryTitle;
            JournalEntryContent = journalEntryContent;
        }

        #endregion
    }
}
