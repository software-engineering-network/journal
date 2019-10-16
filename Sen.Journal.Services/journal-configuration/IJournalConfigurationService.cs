using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Services
{
    public interface IJournalConfigurationService
    {
        /// <summary>
        /// Creates and persists a new Journal.
        /// </summary>
        /// <param name="args"></param>
        /// <returns>The new Journal</returns>
        Journal CreateJournal(CreateJournalArgs args);

        /// <summary>
        /// Updates an existing Journal.
        /// </summary>
        /// <param name="args"></param>
        /// <returns>The updated Journal</returns>
        Journal UpdateJournal(UpdateJournalArgs args);
    }
}
