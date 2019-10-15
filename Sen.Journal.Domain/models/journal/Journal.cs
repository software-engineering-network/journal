namespace Sen.Journal.Domain
{
    public class Journal : Entity
    {
        public Id PersonId { get; }
        public JournalTitle JournalTitle { get; }

        public Journal(
            Id personId,
            JournalTitle journalTitle,
            Id id = null
        ) : base(id)
        {
            PersonId = personId;
            JournalTitle = journalTitle;
        }
    }
}
