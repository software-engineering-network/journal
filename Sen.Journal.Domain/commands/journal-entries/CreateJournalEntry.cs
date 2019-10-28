namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class CreateJournalEntry :
        IUserIdCommand,
        IJournalIdCommand,
        IJournalEntryContentCommand
    {
        #region Properties

        public JournalEntryTitle JournalEntryTitle { get; }

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

        #region IJournalEntryContentCommand Members

        public JournalEntryContent JournalEntryContent { get; }

        #endregion

        #region IJournalIdCommand Members

        public JournalId JournalId { get; }

        #endregion

        #region IUserIdCommand Members

        public UserId UserId { get; }

        #endregion
    }
}
