using System.Linq;
using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Infrastructure.InMemory
{
    public class JournalRepository : InMemoryRepository<Journal>, IJournalRepository
    {
        #region Construction

        public JournalRepository(ICurrentUserProvider currentUserProvider) : base(currentUserProvider)
        {
        }

        #endregion

        #region IJournalRepository Members

        public Journal Find(UserId userId, JournalTitle journalTitle)
        {
            return _entities.Single(x => x.UserId == userId && x.JournalTitle == journalTitle);
        }

        #endregion
    }
}
