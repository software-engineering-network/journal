namespace Sen.Journal.Domain
{
    public class Journal : Entity
    {
        public Id PersonId { get; private set; }
        public JournalTitle JournalTitle { get; private set; }

        public Journal(
            Id personId,
            JournalTitle journalTitle,
            Id id = null
        ) : base(id)
        {
            PersonId = personId;
            JournalTitle = journalTitle;
        }

        public Journal Update(
            Id personId,
            JournalTitle journalTitle
        )
        {
            PersonId = personId;
            JournalTitle = journalTitle;
            return this;
        }
    }
}
