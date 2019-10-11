using System;
using System.Collections.Generic;
using System.Linq;
using Sen.Journal.Domain;

namespace Sen.Journal.Infrastructure.InMemory
{
    public class PersonRepository : IPersonRepository
    {
        private List<Person> _persons;

        public PersonRepository()
        {
            _persons = new List<Person>();
        }

        public Person Create(Person person)
        {
            var personToStore = new Person(
                new Id(NextId(_persons)), 
                new EmailAddress(person.EmailAddress.Value), 
                new Password(person.Password.Value), 
                new Username(person.Username.Value)
            );

            _persons.Add(personToStore);

            return personToStore;
        }

        private ulong NextId(IEnumerable<Person> persons)
        {
            var maxId = _persons.Count == 0 
                ? 0
                : persons.Select(x => x.Id.Value).Max();

            return ++maxId;
        }
    }
}
