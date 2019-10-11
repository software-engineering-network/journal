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
            "Music Journal"
        )]
        public void WhenInstantiatingAJournal_WithValidArgs_ItReturnsAJournal(
            ulong primitiveId,
            string primitiveJournalTitle
        )
        {
            var id = new Id(primitiveId);
            var journalTitle = new JournalTitle(primitiveJournalTitle);

            var journal = new Domain.Journal(
                id,
                journalTitle
            );

            journal.Should().NotBeNull();
            journal.Id.Should().Be(id);
            journal.JournalTitle.Should().Be(journalTitle);
        }
    }
}
