using System.Linq;
using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Infrastructure.InMemory
{
    public class JournalEntryRepository : InMemoryRepository<JournalEntry>, IJournalEntryRepository
    {
        #region Construction

        public JournalEntryRepository(ICurrentUserProvider currentUserProvider) : base(currentUserProvider)
        {
        }

        #endregion

        #region Implementation of IJournalEntryRepository

        public JournalEntry Find(JournalId journalId, JournalEntryTitle journalEntryTitle)
        {
            return _entities.Single(x => x.JournalId == journalId && x.JournalEntryTitle == journalEntryTitle);
        }

        #endregion
    }
}
