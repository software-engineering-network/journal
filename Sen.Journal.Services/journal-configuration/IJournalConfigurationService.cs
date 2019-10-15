namespace Sen.Journal.Services
{
    public interface IJournalConfigurationService
    {
        /// <summary>
        /// Creates and persists a new Journal.
        /// </summary>
        /// <param name="args"></param>
        /// <returns>The new Journal</returns>
        Domain.Journal CreateJournal(CreateJournalArgs args);
    }
}
