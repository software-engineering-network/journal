namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class CreateJournal :
        IUserIdCommand,
        IJournalTitleCommand
    {
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

        #region IJournalTitleCommand Members

        public JournalTitle JournalTitle { get; }

        #endregion

        #region IUserIdCommand Members

        public UserId UserId { get; }

        #endregion
    }
}
