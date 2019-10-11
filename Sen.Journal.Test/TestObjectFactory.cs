using Sen.Journal.Domain;

namespace Sen.Journal.Test
{
    public class TestObjectFactory
    {
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
            => CreatePerson(id, "john.doe@gmail.com", "peanutbuttereggdirt", "JohnDoe");
    }
}
