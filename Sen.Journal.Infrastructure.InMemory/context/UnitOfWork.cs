using System;
using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Infrastructure.InMemory
{
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
