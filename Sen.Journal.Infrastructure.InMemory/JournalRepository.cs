using System.Linq;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using SoftwareEngineeringNetwork.JournalApplication.Domain.JournalManagement;

namespace SoftwareEngineeringNetwork.JournalApplication.Infrastructure.InMemory
{
    public class JournalRepository : InMemoryRepository<Journal>, IJournalRepository
    {
        public JournalRepository(ICurrentUserProvider currentUserProvider) : base(currentUserProvider)
        {
        }

        public override Journal Create(Journal entity)
        {
            var currentUser = _currentUserProvider.GetCurrentUser();
            entity.Id = new Id(NextId(_entities));
            entity.SetCreatedInfo((UserId) currentUser.Id);

            _entities.Add(entity);

            return entity;
        }

        public Journal Find(UserId userId, JournalTitle journalTitle)
        {
            return _entities.Single(x => x.UserId == userId && x.JournalTitle == journalTitle);
        }
    }
}
