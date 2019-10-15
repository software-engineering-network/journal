using FluentAssertions;
using Sen.Journal.Domain;
using Xunit;

namespace Sen.Journal.Test.Domain
{
    public class UsernameTest
    {
        [Theory]
        [InlineData("JohnDoe")]
        public void WhenInstantiatingAUsername_WithAValidValue_ItReturnsAUsername(string value)
        {
            var username = new Username(value);

            username.Should().NotBeNull();
            username.Value.Should().Be(value);
        }
    }
}
