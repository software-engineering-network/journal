using FluentAssertions;
using Sen.Journal.Domain;
using Xunit;

namespace Sen.Journal.Test.Domain
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
        public void WhenInstantiatingAPerson_WithValidArgs_ItReturnsAPerson(
            ulong id,
            string emailAddress,
            string password,
            string username
        )
        {
            var person = new Person(
                new Id(id),
                new EmailAddress(emailAddress),
                new Password(password),
                new Username(username)
            );

            person.Should().NotBeNull();
            person.EmailAddress.Should().Be(emailAddress);
            person.Password.Should().Be(password);
            person.Username.Should().Be(username);
        }

        [Fact]
        public void WhenAddingAJournal_WithValidArgs_TheJournalIsAddedToJournals()
        {
            var johnDoe = TestObjectFactory.CreateJohnDoe(1);
            var musicJournal = TestObjectFactory.CreateMusicJournal(1);

            johnDoe.AddJournal(musicJournal);

            johnDoe.Journals.Should().Contain(musicJournal);
        }
    }
}
