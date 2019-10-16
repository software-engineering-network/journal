namespace Sen.Journal.Services
{
    public class CreateJournalArgs : IJournalArgs
    {
        public ulong PersonId { get; set; }
        public string JournalTitle { get; set; }
    }
}
