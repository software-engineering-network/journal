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

        private readonly IRepository<Person> _personRepository;

        #endregion

        #region Construction

        public UserRepository(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        #endregion

        #region IUserRepository Members

        public User Create(User entity)
        {
            return _personRepository.Create(entity.ToPerson());
        }

        public bool Exists(Func<User, bool> predicate)
        {
            return _personRepository.Exists(predicate);
        }

        public User Find(Id id)
        {
            return _personRepository.Find(id);
        }

        public User FirstOrDefault(Func<User, bool> predicate)
        {
            return _personRepository.FirstOrDefault(predicate);
        }

        public IEnumerable<User> Fetch(Func<User, bool> predicate)
        {
            return _personRepository.Fetch(predicate);
        }

        public User Update(User entity)
        {
            return _personRepository.Update(entity);
        }

        public IEnumerable<RecordName> FindMatchingRecordNames(RecordName recordName)
        {
            return _personRepository
                .Fetch(x => x.RecordName.Value.StartsWith(recordName.Value))
                .Select(x => x.RecordName);
        }

        public bool UsernameExists(Username username)
        {
            return _personRepository.Exists(x => x.Username == username);
        }

        #endregion
    }

    public static class PersonMapping
    {
        public static Person ToPerson(this User user)
        {
            return new Person
            {
                Id = user.Id.Value,
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
                person.EmailAddress,
                person.Name,
                person.Password,
                person.RecordName,
                person.Surname,
                person.Username,
            );
        }
    }
}
