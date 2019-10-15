using FluentAssertions;
using Sen.Journal.Domain;
using Xunit;

namespace Sen.Journal.Test
{
    public class EntityTest
    {
        public Entity Entity { get; set; }

        [Fact]
        public void WhenCheckingForEquality_ItDoesNotMatchNull()
        {
            var person = TestObjectFactory.CreateJohnDoe();
            Person person2 = null;

            person.Equals(person2).Should().BeFalse();
            (person == person2).Should().BeFalse();
            (person2 == person).Should().BeFalse();
        }

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

        [Fact]
        public void WhenCheckingForEquality_NullMatchesNull()
        {
            Person person = null;
            Person person2 = null;

            (person == person2).Should().BeTrue();
            (person2 == person).Should().BeTrue();
        }
    }
}
