using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Test.Wpf
{
    public class TestUserFactory
    {
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
                "jdoe",
                "Doe",
                "JohnDoe",
                id
            );
        }

        public static User CreateJaneDoe(ulong id = 0)
        {
            return CreatePerson(
                "jane.doe@gmail.com",
                "Jane",
                "peanutbuttereggdirt",
                "jdoe1",
                "Doe",
                "JaneDoe",
                id
            );
        }
    }
}