using FluentAssertions;
using Sen.Journal.Domain;
using Xunit;

namespace Sen.Journal.Test
{
    public class JournalTest
    {
        [Theory]
        [InlineData(1, "Music Journal")]
        public void WhenInstantiatingAJournal_WithValidArgs_ItReturnsAJournal(
            ulong id,
            string journalTitle
        )
        {
            var journal = new Domain.Journal(
                new Id(id),
                new JournalTitle(journalTitle)
            );

            journal.Should().NotBeNull();
            journal.Id.Value.Should().Be(id);
            journal.JournalTitle.Value.Should().Be(journalTitle);
        }
    }
}
