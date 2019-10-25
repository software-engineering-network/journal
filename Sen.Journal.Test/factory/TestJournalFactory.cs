using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Test
{
    public class TestJournalFactory
    {
        public static Journal CreateJournal(
            ulong journalId,
            string journalTitle
        )
        {
            return new Journal(
                new UserId(1),
                new JournalTitle(journalTitle)
            );
        }

        public static Journal CreateMusicCoversJournal(ulong id = 0)
        {
            return CreateJournal(
                id,
                "Music Covers Journal"
            );
        }
    }
}
