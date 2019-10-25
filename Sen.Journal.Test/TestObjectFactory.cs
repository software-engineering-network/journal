using SoftwareEngineeringNetwork.JournalApplication.Domain;
using SoftwareEngineeringNetwork.JournalApplication.Domain.JournalManagement;
using SoftwareEngineeringNetwork.JournalApplication.Domain.UserManagement;

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
                new UserId(1),
                new JournalTitle(journalTitle)
            );
        }

        public static Journal CreateMusicJournal(ulong id = 0)
        {
            return CreateJournal(
                id,
                "Music Journal"
            );
        }

        public static User CreatePerson(
            string emailAddress,
            string name,
            string password,
            string recordName,
            string surname,
            string username,
            ulong id = 0
        )
        {
            return id == 0
                ? new User(
                    new EmailAddress(emailAddress),
                    new Name(name),
                    new Password(password),
                    new RecordName(recordName),
                    new Surname(surname),
                    new Username(username)
                )
                : new User(
                    new UserId(id),
                    new EmailAddress(emailAddress),
                    new Name(name),
                    new Password(password),
                    new RecordName(recordName),
                    new Surname(surname),
                    new Username(username)
                );
        }

        public static User CreateJohnDoe(ulong id = 0)
        {
            return CreatePerson(
                "john.doe@gmail.com",
                "John",
                "peanutbuttereggdirt",
                "JohnDoe",
                "Doe",
                "JohnDoe"
            );
        }

        public static User CreateJaneDoe(ulong id = 0)
        {
            return CreatePerson(
                "jane.doe@gmail.com",
                "Jane",
                "peanutbuttereggdirt",
                "JaneDoe",
                "Doe",
                "JaneDoe"
            );
        }
    }
}
