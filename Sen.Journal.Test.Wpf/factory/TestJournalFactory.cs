using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Test.Wpf
{
    public class TestJournalFactory
    {
        public static Journal CreateJournal(
            ulong journalId,
            ulong userId,
            string journalTitle
        )
        {
            return new Journal(
                new JournalId(journalId),
                new UserId(userId),
                new JournalTitle(journalTitle)
            );
        }

        public static Journal CreateMusicCoversJournal(
            ulong journalId = 0,
            ulong userId = 0
        )
        {
            return CreateJournal(
                journalId,
                userId,
                "Music Covers Journal"
            );
        }
    }
}
