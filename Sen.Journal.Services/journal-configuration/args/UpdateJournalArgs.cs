namespace Sen.Journal.Services
{
    public class UpdateJournalArgs : 
        IEntityArgs, 
        IJournalArgs
    {
        public ulong Id { get; set; }
        public ulong PersonId { get; set; }
        public string JournalTitle { get; set; }
    }
}