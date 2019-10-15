using FluentAssertions;
using Sen.Journal.Domain;
using Xunit;

namespace Sen.Journal.Test.Domain
{
    public class TinyTypeTest
    {
        [Fact]
        public void WhenCheckingForEquality_ItDoesNotMatchNull()
        {
            var id = new Id(1);
            Id id2 = null;

            id.Equals(id2).Should().BeFalse();
            (id == id2).Should().BeFalse();
            (id2 == id).Should().BeFalse();
        }

        [Fact]
        public void WhenCheckingForEquality_ItMatchesByReference()
        {
            var id = new Id(1);
            var id2 = id;

            id2.Should().Be(id);
        }

        [Fact]
        public void WhenCheckingForEquality_ItMatchesByWrappedObjects()
        {
            var id = new Id(1);
            var id2 = new Id(1);

            id2.Should().Be(id);
        }

        [Fact]
        public void WhenCheckingForEquality_ItMatchesByWrappedObjectToPrimitive()
        {
            var id = new Id(1);
            var id2 = 1ul;

            id.Should().Be(id2);
        }

        [Fact]
        public void WhenCheckingForEquality_NullMatchesNull()
        {
            Id id = null;
            Id id2 = null;

            (id == id2).Should().BeTrue();
            (id2 == id).Should().BeTrue();
        }
    }
}
