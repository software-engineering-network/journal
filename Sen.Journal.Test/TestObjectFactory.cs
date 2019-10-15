using Sen.Journal.Domain;
using Sen.Journal.Infrastructure.InMemory;

namespace Sen.Journal.Test
{
    public class TestObjectFactory
    {
        public static Domain.Journal CreateJournal(
            ulong id,
            string journalTitle
        )
        {
            return new Domain.Journal(
                new Id(1), 
                new JournalTitle(journalTitle),
                new Id(id)
            );
        }

        public static Domain.Journal CreateMusicJournal(ulong id = 0)
        {
            return CreateJournal(
                id,
                "Music Journal"
            );
        }

        public static Person CreatePerson(
            ulong id,
            string emailAddress,
            string password,
            string username
        )
        {
            return new Person(
                new Id(id),
                new EmailAddress(emailAddress),
                new Password(password),
                new Username(username)
            );
        }

        public static Person CreateJohnDoe(ulong id = 0)
        {
            return CreatePerson(
                id,
                "john.doe@gmail.com",
                "peanutbuttereggdirt",
                "JohnDoe"
            );
        }

        public static IRepository<Person> CreatePersonRepository(params Person[] seed)
        {
            var personRepository = new PersonRepository();

            foreach (var person in seed)
                personRepository.Create(person);

            return personRepository;
        }
    }
}
