namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class CreateJournal
    {
        #region Properties

        public UserId UserId { get; }
        public JournalTitle JournalTitle { get; }

        #endregion

        #region Construction

        public CreateJournal(
            UserId userId,
            JournalTitle journalTitle
        )
        {
            UserId = userId;
            JournalTitle = journalTitle;
        }

        #endregion
    }
}
