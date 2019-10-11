using FluentAssertions;
using Sen.Journal.Domain;
using Xunit;

namespace Sen.Journal.Test
{
    public class PersonTest
    {
        [Theory]
        [InlineData(
            1,
            "john.doe@gmail.com",
            "peanutbuttereggdirt",
            "JohnDoe"
        )]
        public void WhenInstantiatingAPerson_WithValidRequiredArgs_ItReturnsAPerson(
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
            var person = new Person(
                id,
                emailAddress,
                password,
                username
            );

            person.Should().NotBeNull();
            person.EmailAddress.Should().Be(emailAddress);
            person.Password.Should().Be(password);
            person.Username.Should().Be(username);
        }
    }
}
