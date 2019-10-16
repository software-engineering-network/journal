namespace Sen.Journal.Services
{
    public interface IJournalArgs : IPersonForeignKeyArgs
    {
        string JournalTitle { get; set; }
    }
}
