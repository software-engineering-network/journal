using FluentAssertions;
using Sen.Journal.Domain;
using Xunit;

namespace Sen.Journal.Test
{
    public class UserTest
    {
        [Theory]
        [InlineData("john.doe@gmail.com", "JohnDoe", "peanutbuttereggdirt")]
        public void WhenInstantiatingAUser_WithValidRequiredArgs_AUserIsReturned(
            string email,
            string username,
            string password
        )
        {
            var user = new User(username, email, password);

            user.Should().NotBeNull();
            user.Email.Should().Be(email);
            user.Password.Should().Be(password);
            user.Username.Should().Be(username);
        }
    }
}
