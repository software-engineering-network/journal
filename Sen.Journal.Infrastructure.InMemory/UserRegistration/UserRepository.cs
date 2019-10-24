using System;
using System.Collections.Generic;
using System.Linq;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using SoftwareEngineeringNetwork.JournalApplication.Domain.UserManagement;

namespace SoftwareEngineeringNetwork.JournalApplication.Infrastructure.InMemory.UserRegistration
{
    public class UserRepository : IUserRepository
    {
        #region Fields

        private readonly List<Person> _persons;

        #endregion

        #region Construction

        public UserRepository()
        {
            _persons = new List<Person>();
        }

        #endregion

        #region IUserRepository Members

        public User Create(User entity)
        {
            var person = entity.ToPerson();
            person.Id = NextId();

            _persons.Add(person);

            return FirstOrDefault(x => x.RecordName == entity.RecordName);
        }

        public bool Exists(Func<User, bool> predicate)
        {
            try
            {
                var matchingPerson = Fetch().First(predicate);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<User> Fetch()
        {
            return _persons.Select(x => x.ToUser());
        }

        public IEnumerable<User> Fetch(Func<User, bool> predicate)
        {
            return Fetch().Where(predicate);
        }

        public User Find(Id id)
        {
            return _persons.Find(x => x.Id == id.Value).ToUser();
        }

        public User FirstOrDefault(Func<User, bool> predicate)
        {
            return Fetch().FirstOrDefault(predicate);
        }

        public User Update(User entity)
        {
            var person = _persons.Find(x => x.Id == entity.Id.Value);
            person.EmailAddress = entity.EmailAddress.Value;
            person.Name = entity.Name.Value;
            person.RecordName = entity.RecordName.Value;
            person.Surname = entity.Surname.Value;
            person.Username = entity.Username.Value;

            return person.ToUser();
        }

        public IEnumerable<RecordName> FindMatchingRecordNames(RecordName recordName)
        {
            return _persons
                .Where(x => x.RecordName.StartsWith(recordName.Value))
                .Select(x => new RecordName(x.RecordName));
        }

        public bool RecordNameExists(RecordName recordName)
        {
            return _persons.Exists(x => x.RecordName == recordName.Value);
        }

        public bool UsernameExists(Username username)
        {
            return _persons.Exists(x => x.Username == username.Value);
        }

        #endregion

        private ulong NextId()
        {
            var maxId = _persons.Count == 0
                ? 0
                : _persons.Select(x => x.Id).Max();

            return ++maxId;
        }
    }

    public static class PersonMapping
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
