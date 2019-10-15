using FluentAssertions;
using Sen.Journal.Infrastructure.InMemory;
using Sen.Journal.Services;
using Xunit;

namespace Sen.Journal.Test
{
    public class JournalConfigurationServiceTest
    {
        [Theory]
        [InlineData(1, "Music Journal")]
        public void WhenCreatingAJournal_WithValidArgs_ItReturnsANewJournal(
            ulong personId,
            string journalTitle
        )
        {
            var repository = new JournalRepository();
            var service = new JournalConfigurationService(repository);
            var args = new CreateJournalArgs
            {
                PersonId = personId,
                JournalTitle = journalTitle
            };

            var journal = service.CreateJournal(args);

            journal.Should().NotBeNull();
            journal.Id.Should().NotBe(0);
            journal.PersonId.Should().Be(personId);
            journal.JournalTitle.Should().Be(journalTitle);
        }
    }
}
