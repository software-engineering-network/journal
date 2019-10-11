using Sen.Journal.Domain.storage;

namespace Sen.Journal.Domain.services
{
    public interface IJournalService
    {
        Journal CreateJournal(CreateJournalArgs args);
    }

    public class JournalService : IJournalService
    {
        private readonly IRepository<Journal> _journalRepository;
        
        public JournalService(IRepository<Journal> journalRepository)
        {
            _journalRepository = journalRepository;
        }

        public Journal CreateJournal(CreateJournalArgs args)
        {
            var journal = new Journal(
                new Id(0), 
                new Id(args.PersonId),
                new JournalTitle(args.JournalTitle)
            );

            return _journalRepository.Create(journal);
        }
    }

    public class CreateJournalArgs
    {
        public ulong PersonId { get; set; }
        public string JournalTitle { get; set; }
    }
}
