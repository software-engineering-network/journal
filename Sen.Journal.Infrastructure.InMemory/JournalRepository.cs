using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Infrastructure.InMemory
{
    public class JournalRepository : InMemoryRepository<Journal>
    {
        public JournalRepository(ICurrentUserProvider currentUserProvider) : base(currentUserProvider)
        {
        }

        public override Journal Create(Journal entity)
        {
            var newJournal = new Journal(
                entity.UserId,
                entity.JournalTitle,
                new JournalId(NextId(_entities))
            );

            var currentUser = _currentUserProvider.GetCurrentUser();
            newJournal.SetCreatedInfo((UserId) currentUser.Id);

            _entities.Add(newJournal);

            return newJournal;
        }
    }
}
