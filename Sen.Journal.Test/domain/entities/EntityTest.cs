using FluentAssertions;
using Sen.Journal.Domain;
using Xunit;

namespace Sen.Journal.Test
{
    public class EntityTest
    {
        public Entity Entity { get; set; }

        [Fact]
        public void WhenCheckingForEquality_ItMatchesIdentifierEquality()
        {
            var person1 = TestObjectFactory.CreatePerson(
                1,
                "john.doe@gmail.com",
                "alligator1",
                "JohnDoe"
            );
            var person2 = TestObjectFactory.CreatePerson(
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
