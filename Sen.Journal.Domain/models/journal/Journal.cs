namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class Journal : Entity
    {
        public UserId UserId { get; private set; }
        public JournalTitle JournalTitle { get; private set; }

        public Journal(
            UserId userId,
            JournalTitle journalTitle,
            JournalId journalId = null
        ) : base(journalId)
        {
            UserId = userId;
            JournalTitle = journalTitle;
        }

        public Journal Update(
            UserId personId,
            JournalTitle journalTitle
        )
        {
            UserId = personId;
            JournalTitle = journalTitle;
            return this;
        }
    }
}
