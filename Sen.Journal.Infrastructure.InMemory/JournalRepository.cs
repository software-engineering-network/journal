using System;
using Sen.Journal.Domain;

namespace Sen.Journal.Infrastructure.InMemory
{
    public class JournalRepository : InMemoryRepository<Domain.Journal>
    {
        private readonly ICurrentUserProvider _currentUserProvider;

        public JournalRepository(ICurrentUserProvider currentUserProvider)
        {
            _currentUserProvider = currentUserProvider;
        }

        public override Domain.Journal Create(Domain.Journal entity)
        {
            var newJournal = new Domain.Journal(
                entity.PersonId,
                entity.JournalTitle,
                NextId(Entities)
            );

            var currentUser = _currentUserProvider.GetCurrentUser();
            newJournal.Create(currentUser);

            Entities.Add(newJournal);

            return newJournal;
        }
    }
}
