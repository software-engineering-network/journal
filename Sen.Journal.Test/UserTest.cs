using FluentAssertions;
using Sen.Journal.Domain;
using Xunit;

namespace Sen.Journal.Test
{
    public class UserTest
    {
        public UserTest()
        {
            User = new User(
                new Id(1),
                new EmailAddress("john.doe@gmail.com"),
                new Password("peanutbuttereggdirt"),
                new Username("JohnDoe")
            );
        }

        private static User CreateUserFromPrimitives(
            ulong id,
            string emailAddress,
            string password,
            string username
        )
        {
            return new User(
                new Id(id),
                new EmailAddress(emailAddress),
                new Password(password),
                new Username(username)
            );
        }

        public User User { get; set; }

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


        [Theory]
        [InlineData(
            1,
            "john.doe@gmail.com",
            "peanutbuttereggdirt",
            "JohnDoe"
        )]
        public void WhenCheckingForEquality_ItMatchesIdentifierEquality(
            ulong primitiveId,
            string primitiveEmailAddress,
            string primitivePassword,
            string primitiveUsername
        )
        {
            var user1 = CreateUserFromPrimitives(
                primitiveId,
                primitiveEmailAddress,
                primitivePassword,
                primitiveUsername
            );
            var user2 = CreateUserFromPrimitives(
                primitiveId,
                "",
                "",
                ""
            );

            user1.Should().Be(user2);
            (user1 == user2).Should().BeTrue();
        }

        [Fact]
        public void WhenCheckingForEquality_ItMatchesReferenceEquality()
        {
            var user1 = User;
            var user2 = User;

            user1.Should().Be(user2);
            (user1 == user2).Should().BeTrue();
        }
    }
}
