namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public interface IUnitOfWork
    {
        IJournalEntryRepository JournalEntryRepository { get; }
        IJournalRepository JournalRepository { get; }
        IUserRepository UserRepository { get; }

        IUnitOfWork Commit();
    }
}