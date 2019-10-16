namespace SoftwareEngineeringNetwork.JournalApplication.Services
{
    public interface IJournalConfigurationService
    {
        /// <summary>
        /// Creates and persists a new Journal.
        /// </summary>
        /// <param name="args"></param>
        /// <returns>The new Journal</returns>
        Domain.Journal CreateJournal(CreateJournalArgs args);

        /// <summary>
        /// Updates an existing Journal.
        /// </summary>
        /// <param name="args"></param>
        /// <returns>The updated Journal</returns>
        Domain.Journal UpdateJournal(UpdateJournalArgs args);
    }
}
