using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Test
{
    public class TestObjectFactory
    {
        public static Journal CreateJournal(
            ulong journalId,
            string journalTitle
        )
        {
            return new Journal(
                new PersonId(1),
                new JournalTitle(journalTitle),
                new JournalId(journalId)
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
            ulong personId,
            string emailAddress,
            string password,
            string username
        )
        {
            return new Person(
                new PersonId(personId),
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
