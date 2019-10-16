using Sen.Journal.Domain;

namespace Sen.Journal.Services
{
    public class JournalConfigurationService : IJournalConfigurationService
    {
        private readonly IRepository<Domain.Journal> _journalRepository;

        public JournalConfigurationService(IRepository<Domain.Journal> journalRepository)
        {
            _journalRepository = journalRepository;
        }

        public Domain.Journal CreateJournal(CreateJournalArgs args)
        {
            var journal = new Domain.Journal(
                new Id(args.PersonId),
                new JournalTitle(args.JournalTitle)
            );

            return _journalRepository.Create(journal);
        }

        public Domain.Journal UpdateJournal(UpdateJournalArgs args)
        {
            var journal = _journalRepository.Find(new Id(args.Id));

            journal.Update(
                new Id(args.PersonId),
                new JournalTitle(args.JournalTitle)
            );

            return _journalRepository.Update(journal);
        }
    }
}
