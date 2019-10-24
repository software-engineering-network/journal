using FluentAssertions;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using Xunit;

namespace SoftwareEngineeringNetwork.JournalApplication.Test.Domain
{
    public class JournalTest
    {
        [Theory]
        [InlineData(
            1,
            1,
            "Music Journal"
        )]
        public void WhenInstantiatingAJournal_WithValidArgs_ItReturnsAJournal(
            ulong id,
            ulong userId,
            string journalTitle
        )
        {
            var journal = new Journal(
                new UserId(userId),
                new JournalTitle(journalTitle),
                new JournalId(id)
            );

            journal.Should().NotBeNull();
            journal.Id.Should().Be(id);
            journal.JournalTitle.Should().Be(journalTitle);
        }
    }
}
