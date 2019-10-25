using SoftwareEngineeringNetwork.JournalApplication.Domain;
using SoftwareEngineeringNetwork.JournalApplication.Domain.JournalManagement;
using SoftwareEngineeringNetwork.JournalApplication.Services.Users;

namespace SoftwareEngineeringNetwork.JournalApplication.Services.Journals
{
    public interface IJournalService
    {
        JournalDto Find(ulong userId, string journalTitle);
    }

    public class JournalDto : IEntityDto
    {
        #region Properties

        public ulong UserId { get; }

        #endregion

        #region Construction

        public JournalDto(
            ulong id,
            ulong userId,
            string displayName
        )
        {
            Id = id;
            UserId = userId;
            DisplayName = displayName;
        }

        #endregion

        #region IEntityDto Members

        public ulong Id { get; }
        public string DisplayName { get; }

        #endregion
    }

    public class JournalService : IJournalService
    {
        #region Fields

        private readonly IJournalRepository _journalRepository;

        #endregion

        #region Construction

        public JournalService(IJournalRepository journalRepository)
        {
            _journalRepository = journalRepository;
        }

        #endregion

        #region IJournalService Members

        public JournalDto Find(ulong userId, string journalTitle)
        {
            return _journalRepository
                .Find(
                    new UserId(userId),
                    new JournalTitle(journalTitle)
                )
                .ToJournalDto();
        }

        #endregion
    }

    public static class JournalDtoExtensions
    {
        public static JournalDto ToJournalDto(this Journal journal)
        {
            return new JournalDto(
                journal.Id.Value,
                journal.UserId.Value,
                journal.JournalTitle.Value
            );
        }
    }
}
