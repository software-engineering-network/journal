using System.Collections.Generic;
using Sen.Journal.Domain;
using Sen.Journal.Infrastructure.InMemory;

namespace Sen.Journal.Test
{
    public class TestObjectFactory
    {
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

        public static IPersonRepository CreatePersonRepository(params Person[] seed)
        {
            var personRepository = new PersonRepository();

            foreach (var person in seed)
                personRepository.Create(person);

            return personRepository;
        }
    }
}
