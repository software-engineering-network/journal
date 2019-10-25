namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class CreateJournalEntry
    {
        #region Properties

        public ulong UserId { get; }
        public ulong JournalId { get; }
        public string JournalEntryTitle { get; }
        public string JournalEntryContent { get; }

        #endregion

        #region Construction

        public CreateJournalEntry(
            ulong userId,
            ulong journalId,
            string journalEntryTitle,
            string journalEntryContent
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
