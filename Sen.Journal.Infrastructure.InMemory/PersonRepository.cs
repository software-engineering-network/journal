using Sen.Journal.Domain;

namespace Sen.Journal.Infrastructure.InMemory
{
    public class PersonRepository : InMemoryRepository<Person>
    {
        public override Person Create(Person entity)
        {
            var newPerson = new Person(
                NextId(Entities), 
                new EmailAddress(entity.EmailAddress.Value), 
                new Password(entity.Password.Value), 
                new Username(entity.Username.Value)
            );

            Entities.Add(newPerson);

            return newPerson;
        }
    }
}
