using System.Collections.Generic;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class Person : Entity
    {
        public EmailAddress EmailAddress { get; }
        public Password Password { get; }
        public Username Username { get; }
        public List<Journal> Journals { get; }

        public Person(
            PersonId personId,
            EmailAddress emailAddress,
            Password password,
            Username username,
            IEnumerable<Journal> journals = null
        ) : base(personId)
        {
            EmailAddress = emailAddress;
            Password = password;
            Username = username;
            Journals = journals == null
                ? new List<Journal>()
                : (List<Journal>) journals;
        }

        public Person AddJournal(Journal journal)
        {
            Journals.Add(journal);
            return this;
        }
    }
}
