using SoftwareEngineeringNetwork.JournalApplication.Domain.JournalManagement;

namespace SoftwareEngineeringNetwork.JournalApplication.Services.Journals
{
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