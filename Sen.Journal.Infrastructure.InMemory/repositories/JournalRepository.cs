using System.Linq;
using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Infrastructure.InMemory
{
    public class JournalRepository : InMemoryRepository<Journal>, IJournalRepository
    {
        #region Construction

        public JournalRepository(
            Context context,
            ICurrentUserProvider currentUserProvider
        ) : base(context, currentUserProvider)
        {
            GetEntities = () => Context.Journals;
        }

        #endregion

        #region Implementation of IJournalRepository

        public Journal Find(UserId userId, JournalTitle journalTitle)
        {
            return Entities.Single(x => x.UserId == userId && x.JournalTitle == journalTitle);
        }

        public bool JournalTitleExists(JournalTitle journalTitle)
        {
            return Exists(x => x.JournalTitle == journalTitle);
        }

        #endregion
    }
}
