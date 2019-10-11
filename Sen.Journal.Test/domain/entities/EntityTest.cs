using FluentAssertions;
using Sen.Journal.Domain;
using Xunit;

namespace Sen.Journal.Test
{
    public class EntityTest
    {
        public Entity Entity { get; set; }

        private static Entity CreatePersonFromPrimitives(
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

        [Fact]
        public void WhenCheckingForEquality_ItMatchesIdentifierEquality()
        {
            var person1 = CreatePersonFromPrimitives(
                1,
                "john.doe@gmail.com",
                "alligator1",
                "JohnDoe"
            );
            var person2 = CreatePersonFromPrimitives(
                1,
                "jane.doe@gmail.com",
                "alligator1",
                "JaneDoe"
            );

            person1.Should().Be(person2);
            (person1 == person2).Should().BeTrue();
        }

        [Fact]
        public void WhenCheckingForEquality_ItMatchesReferenceEquality()
        {
            var person1 = Entity;
            var person2 = Entity;

            person1.Should().Be(person2);
            (person1 == person2).Should().BeTrue();
        }
    }
}
