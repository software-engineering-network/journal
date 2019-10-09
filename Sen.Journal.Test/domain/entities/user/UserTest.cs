using FluentAssertions;
using Sen.Journal.Domain;
using Xunit;

namespace Sen.Journal.Test
{
    public class UserTest
    {
        [Theory]
        [InlineData(
            1,
            "john.doe@gmail.com",
            "peanutbuttereggdirt",
            "JohnDoe"
        )]
        public void WhenInstantiatingAUser_WithValidRequiredArgs_ItReturnsAUser(
            ulong primitiveId,
            string primitiveEmailAddress,
            string primitivePassword,
            string primitiveUsername
        )
        {
            var id = new Id(primitiveId);
            var emailAddress = new EmailAddress(primitiveEmailAddress);
            var password = new Password(primitivePassword);
            var username = new Username(primitiveUsername);
            var user = new User(
                id,
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
