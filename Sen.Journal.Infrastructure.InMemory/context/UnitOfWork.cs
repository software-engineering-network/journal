using System;
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

    public class UnitOfWork : IUnitOfWork
    {
        #region Fields

        private readonly Context _context;
        private readonly ICurrentUserProvider _currentUserProvider;

        private IJournalEntryRepository _journalEntryRepository;
        private IJournalRepository _journalRepository;
        private IUserRepository _userRepository;

        #endregion

        #region Construction

        public UnitOfWork(Context context, ICurrentUserProvider currentUserProvider)
        {
            _context = context;
            _currentUserProvider = currentUserProvider;
        }

        #endregion

        #region IUnitOfWork Members

        public IJournalEntryRepository JournalEntryRepository =>
            _journalEntryRepository
            ?? (_journalEntryRepository = new JournalEntryRepository(_context, _currentUserProvider));

        public IJournalRepository JournalRepository =>
            _journalRepository
            ?? (_journalRepository = new JournalRepository(_context, _currentUserProvider));

        public IUserRepository UserRepository =>
            _userRepository
            ?? (_userRepository = new UserRepository());

        public IUnitOfWork Commit()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
