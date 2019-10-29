using System.Collections.Generic;
using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Infrastructure.InMemory
{
    public class Context
    {
        #region Properties

        public List<JournalEntry> JournalEntries { get; }
        public List<Journal> Journals { get; }
        public List<Person> Persons { get; }

        #endregion

        #region Construction

        public Context()
        {
            JournalEntries = new List<JournalEntry>();
            Journals = new List<Journal>();
            Persons = new List<Person>();
        }

        #endregion
    }
}