using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Infrastructure.InMemory
{
    public class PersonRepository : InMemoryRepository<Person>
    {
        #region Construction

        public PersonRepository(ICurrentUserProvider currentUserProvider) : base(currentUserProvider)
        {
        }

        #endregion

        #region InMemoryRepository<Person> Overrides

        public override Person Create(Person entity)
        {
            var newPerson = new Person(
                new PersonId(NextId(_entities)),
                new EmailAddress(entity.EmailAddress.Value),
                new Password(entity.Password.Value),
                new Username(entity.Username.Value)
            );

            _entities.Add(newPerson);

            return newPerson;
        }

        #endregion
    }
}
