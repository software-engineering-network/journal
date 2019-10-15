using System.Collections.Generic;

namespace Sen.Journal.Domain
{
    public class Person : Entity
    {
        public EmailAddress EmailAddress { get; }
        public Password Password { get; }
        public Username Username { get; }
        public List<Journal> Journals { get; }

        public Person(
            Id id,
            EmailAddress emailAddress,
            Password password,
            Username username,
            IEnumerable<Journal> journals = null
        ) : base(id)
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
