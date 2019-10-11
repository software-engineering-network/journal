namespace Sen.Journal.Domain
{
    public class Journal : Entity
    {
        public Id PersonId { get; set; }
        public JournalTitle JournalTitle { get; }

        public Journal(
            Id id,
            Id personId,
            JournalTitle journalTitle
        ) : base(id)
        {
            JournalTitle = journalTitle;
        }
    }
}
