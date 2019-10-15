namespace Sen.Journal.Infrastructure.InMemory
{
    public class JournalRepository : InMemoryRepository<Domain.Journal>
    {
        public override Domain.Journal Create(Domain.Journal entity)
        {
            var newJournal = new Domain.Journal(
                entity.PersonId,
                entity.JournalTitle,
                NextId(Entities)
            );

            Entities.Add(newJournal);

            return newJournal;
        }
    }
}
