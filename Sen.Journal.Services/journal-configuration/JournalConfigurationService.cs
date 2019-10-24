﻿using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Services
{
    public class JournalConfigurationService : IJournalConfigurationService
    {
        private readonly IRepository<Journal> _journalRepository;

        public JournalConfigurationService(IRepository<Journal> journalRepository)
        {
            _journalRepository = journalRepository;
        }

        public Journal CreateJournal(CreateJournalArgs args)
        {
            var journal = new Journal(
                new UserId(args.PersonId),
                new JournalTitle(args.JournalTitle)
            );

            return _journalRepository.Create(journal);
        }

        public Journal UpdateJournal(UpdateJournalArgs args)
        {
            var journal = _journalRepository.Find(new Id(args.Id));

            journal.Update(
                new UserId(args.PersonId),
                new JournalTitle(args.JournalTitle)
            );

            return _journalRepository.Update(journal);
        }
    }
}
