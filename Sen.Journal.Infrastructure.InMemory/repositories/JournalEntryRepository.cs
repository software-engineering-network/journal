using System.Linq;
using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Infrastructure.InMemory
{
    public class JournalEntryRepository : InMemoryRepository<JournalEntry>, IJournalEntryRepository
    {
        #region Construction

        public JournalEntryRepository(
            Context context,
            ICurrentUserProvider currentUserProvider
        ) : base(context, currentUserProvider)
        {
            GetEntities = () => Context.JournalEntries;
        }

        #endregion

        #region IJournalEntryRepository Members

        public JournalEntry Find(JournalId journalId, JournalEntryTitle journalEntryTitle)
        {
            return Entities.Single(x => x.JournalId == journalId && x.JournalEntryTitle == journalEntryTitle);
        }

        #endregion
    }
}
