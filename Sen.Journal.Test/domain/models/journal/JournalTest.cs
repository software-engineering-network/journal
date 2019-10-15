using FluentAssertions;
using Sen.Journal.Domain;
using Xunit;

namespace Sen.Journal.Test
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
            var journal = new Domain.Journal(
                new Id(personId),
                new JournalTitle(journalTitle),
                new Id(id)
            );

            journal.Should().NotBeNull();
            journal.Id.Should().Be(id);
            journal.JournalTitle.Should().Be(journalTitle);
        }
    }
}
