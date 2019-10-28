namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public interface IJournalRepository : IRepository<Journal>
    {
        Journal Find(UserId userId, JournalTitle journalTitle);
        bool JournalTitleExists(JournalTitle journalTitle);
    }
}