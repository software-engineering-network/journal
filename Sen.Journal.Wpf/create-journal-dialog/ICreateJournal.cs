using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Wpf
{
    public interface ICreateJournal
    {
        CreateJournal BuildCreateJournalCommand();
        void CreateJournal();
    }
}
