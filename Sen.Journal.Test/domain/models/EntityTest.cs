using FluentAssertions;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using Xunit;

namespace SoftwareEngineeringNetwork.JournalApplication.Test.Domain
{
    public class EntityTest
    {
        public Entity Entity { get; set; }

        [Fact]
        public void WhenCheckingForEquality_ItDoesNotMatchNull()
        {
            var person = TestObjectFactory.CreateJohnDoe();
            User person2 = null;

            person.Equals(person2).Should().BeFalse();
            (person == person2).Should().BeFalse();
            (person2 == person).Should().BeFalse();
        }

        [Fact]
        public void WhenCheckingForEquality_ItMatchesIdentifierEquality()
        {
            var person1 = TestObjectFactory.CreateJohnDoe(1);
            var person2 = TestObjectFactory.CreateJaneDoe(2);

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
            User person = null;
            User person2 = null;

            (person == person2).Should().BeTrue();
            (person2 == person).Should().BeTrue();
        }
    }
}
