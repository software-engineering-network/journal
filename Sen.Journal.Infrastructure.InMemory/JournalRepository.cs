using Sen.Journal.Domain;

namespace Sen.Journal.Infrastructure.InMemory
{
    public class JournalRepository : InMemoryRepository<Domain.Journal>
    {
        public JournalRepository(ICurrentUserProvider currentUserProvider) : base(currentUserProvider)
        {
        }

        public override Domain.Journal Create(Domain.Journal entity)
        {
            var newJournal = new Domain.Journal(
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
