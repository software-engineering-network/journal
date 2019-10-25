namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class Journal : Entity
    {
        #region Properties

        public UserId UserId { get; set; }
        public JournalTitle JournalTitle { get; set; }

        #endregion

        #region Construction

        public Journal(
            UserId userId,
            JournalTitle journalTitle
        )
        {
            UserId = userId;
            JournalTitle = journalTitle;
        }

        public Journal(
            JournalId journalId,
            UserId userId,
            JournalTitle journalTitle
        ) : this(userId, journalTitle)
        {
            Id = journalId;
        }

        #endregion
    }
}
