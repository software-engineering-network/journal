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
            string primitiveEmailAddress,
            string primtivePassword,
            string primitiveUsername
        )
        {
            var emailAddress = new EmailAddress(primitiveEmailAddress);
            var password = new Password(primtivePassword);
            var username = new Username(primitiveUsername);
            var user = new User(
                emailAddress,
                password,
                username
            );

            user.Should().NotBeNull();
            user.EmailAddress.Should().Be(emailAddress);
            user.Password.Should().Be(password);
            user.Username.Should().Be(username);
        }
    }
}
