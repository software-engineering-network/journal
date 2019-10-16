using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Test
{
    public class TestObjectFactory
    {
        public static Journal CreateJournal(
            ulong id,
            string journalTitle
        )
        {
            return new Journal(
                new Id(1),
                new JournalTitle(journalTitle),
                new Id(id)
            );
        }

        public static Journal CreateMusicJournal(ulong id = 0)
        {
            return CreateJournal(
                id,
                "Music Journal"
            );
        }

        public static Person CreatePerson(
            ulong id,
            string emailAddress,
            string password,
            string username
        )
        {
            return new Person(
                new Id(id),
                new EmailAddress(emailAddress),
                new Password(password),
                new Username(username)
            );
        }

        public static Person CreateJohnDoe(ulong id = 0)
        {
            return CreatePerson(
                id,
                "john.doe@gmail.com",
                "peanutbuttereggdirt",
                "JohnDoe"
            );
        }
    }
}
