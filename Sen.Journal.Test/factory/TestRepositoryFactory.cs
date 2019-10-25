using SoftwareEngineeringNetwork.JournalApplication.Domain;
using SoftwareEngineeringNetwork.JournalApplication.Infrastructure.InMemory;

namespace SoftwareEngineeringNetwork.JournalApplication.Test
{
    public class TestRepositoryFactory
    {
        public static IJournalRepository CreateJournalRepository()
        {
            var currentUserProvider = TestObjectFactory.CreateCurrentUserProvider();
            var journalRepository = new JournalRepository(currentUserProvider);
            return journalRepository;
        }

        public static IJournalRepository CreatePopulatedJournalRepository()
        {
            var journalRepository = CreateJournalRepository();
            journalRepository.Create(TestJournalFactory.CreateMusicCoversJournal());
            return journalRepository;
        }

        public static IJournalEntryRepository CreateJournalEntryRepository()
        {
            var currentUserProvider = TestObjectFactory.CreateCurrentUserProvider();
            var journalEntryRepository = new JournalEntryRepository(currentUserProvider);
            return journalEntryRepository;
        }
    }
}
