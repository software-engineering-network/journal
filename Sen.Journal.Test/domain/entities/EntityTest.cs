using FluentAssertions;
using Sen.Journal.Domain;
using Xunit;

namespace Sen.Journal.Test
{
    public class EntityTest
    {
        public Entity Entity { get; set; }

        private static Entity CreateUserFromPrimitives(
            ulong id,
            string emailAddress,
            string password,
            string username
        )
        {
            return new User(
                new Id(id),
                new EmailAddress(emailAddress),
                new Password(password),
                new Username(username)
            );
        }

        [Fact]
        public void WhenCheckingForEquality_ItMatchesIdentifierEquality()
        {
            var user1 = CreateUserFromPrimitives(
                1,
                "john.doe@gmail.com",
                "alligator1",
                "JohnDoe"
            );
            var user2 = CreateUserFromPrimitives(
                1,
                "jane.doe@gmail.com",
                "alligator1",
                "JaneDoe"
            );

            user1.Should().Be(user2);
            (user1 == user2).Should().BeTrue();
        }

        [Fact]
        public void WhenCheckingForEquality_ItMatchesReferenceEquality()
        {
            var user1 = Entity;
            var user2 = Entity;

            user1.Should().Be(user2);
            (user1 == user2).Should().BeTrue();
        }
    }
}
