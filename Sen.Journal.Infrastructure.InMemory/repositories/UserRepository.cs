using System;
using System.Collections.Generic;
using System.Linq;
using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Infrastructure.InMemory
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

        public User Find(Username username)
        {
            return _persons.Single(x => x.Username == username.Value).ToUser();
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

        public bool UserIdExists(UserId userId)
        {
            return _persons.Exists(x => x.Id == userId.Value);
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
}
