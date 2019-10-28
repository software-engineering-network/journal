namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class CreateJournalEntry
    {
        #region Properties

        public UserId UserId { get; }
        public JournalId JournalId { get; }
        public JournalEntryTitle JournalEntryTitle { get; }
        public JournalEntryContent JournalEntryContent { get; }

        #endregion

        #region Construction

        public CreateJournalEntry(
            UserId userId,
            JournalId journalId,
            JournalEntryTitle journalEntryTitle,
            JournalEntryContent journalEntryContent
        )
        {
            UserId = userId;
            JournalId = journalId;
            JournalEntryTitle = journalEntryTitle;
            JournalEntryContent = journalEntryContent;
        }

        #endregion
    }
}
