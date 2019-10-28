using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Services
{
    public interface IJournalManagementService
    {
        IJournalManagementService CreateJournal(CreateJournal createJournal);
    }
}
