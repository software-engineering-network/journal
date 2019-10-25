using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Services
{
    public static class JournalMappingExtensions
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
