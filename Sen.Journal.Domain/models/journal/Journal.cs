namespace Sen.Journal.Domain
{
    public class Journal : Entity
    {
        public JournalTitle JournalTitle { get; }

        public Journal(
            Id id,
            JournalTitle journalTitle
        ) : base(id)
        {
            JournalTitle = journalTitle;
        }
    }
}
