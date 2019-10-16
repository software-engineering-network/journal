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
                entity.PersonId,
                entity.JournalTitle,
                NextId(_entities)
            );

            var currentUser = _currentUserProvider.GetCurrentUser();
            newJournal.Create(currentUser);

            _entities.Add(newJournal);

            return newJournal;
        }
    }
}
