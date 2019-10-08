using FluentAssertions;
using Sen.Journal.Domain;
using Xunit;

namespace Sen.Journal.Test
{
    public class UserTest
    {
        [Theory]
        [InlineData(
            "john.doe@gmail.com",
            "peanutbuttereggdirt",
            "JohnDoe"
        )]
        public void WhenInstantiatingAUser_WithValidRequiredArgs_ItReturnsAUser(
            string email,
            string password,
            string primitiveUsername
        )
        {
            var username = new Username(primitiveUsername);
            var user = new User(
                email,
                password,
                username
            );

            user.Should().NotBeNull();
            user.Email.Should().Be(email);
            user.Password.Should().Be(password);
            user.Username.Should().Be(username);
        }
    }
}
