using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Infrastructure.InMemory
{
    public static class PersonMappingExtensions
    {
        public static Person ToPerson(this User user)
        {
            return new Person
            {
                Id = user.Id?.Value ?? 0,
                EmailAddress = user.EmailAddress.Value,
                Name = user.Name.Value,
                Password = user.Password.Value,
                RecordName = user.RecordName.Value,
                Surname = user.Surname.Value,
                Username = user.Username.Value
            };
        }

        public static User ToUser(this Person person)
        {
            return new User(
                new UserId(person.Id), 
                new EmailAddress(person.EmailAddress),
                new Name(person.Name),
                new Password(person.Password),
                new RecordName(person.RecordName),
                new Surname(person.Surname),
                new Username(person.Username)
            );
        }
    }
}