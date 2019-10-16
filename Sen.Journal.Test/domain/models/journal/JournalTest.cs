using FluentAssertions;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using Xunit;

namespace SoftwareEngineeringNetwork.JournalApplication.Test.domain
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
            ulong personId,
            string journalTitle
        )
        {
            var journal = new Journal(
                new PersonId(personId),
                new JournalTitle(journalTitle),
                new JournalId(id)
            );

            journal.Should().NotBeNull();
            journal.Id.Should().Be(id);
            journal.JournalTitle.Should().Be(journalTitle);
        }
    }
}
