using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Services
{
    public interface IJournalEntryManagementService
    {
        IJournalEntryManagementService CreateJournalEntry(CreateJournalEntry createJournalEntry);
    }
}