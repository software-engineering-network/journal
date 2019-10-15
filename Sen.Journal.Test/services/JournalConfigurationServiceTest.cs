using FluentAssertions;
using Sen.Journal.Domain;
using Sen.Journal.Infrastructure.InMemory;
using Sen.Journal.Services;
using Xunit;

namespace Sen.Journal.Test.Services
{
    public class JournalConfigurationServiceTest
    {
        private static IJournalConfigurationService CreateJournalConfigurationService()
        {
            var currentUserService = new JohnDoeCurrentUserProvider();
            var repository = new JournalRepository(currentUserService);
            return new JournalConfigurationService(repository);
        }

        private static CreateJournalArgs CreateCreateJournalArgs(
            ulong personId = 1,
            string journalTitle = "Music Journal"
        )
        {
            return new CreateJournalArgs
            {
                PersonId = personId,
                JournalTitle = journalTitle
            };
        }

        [Fact]
        public void WhenCreatingAJournal_WithValidArgs_ItReturnsANewJournal()
        {
            var service = CreateJournalConfigurationService();
            var args = CreateCreateJournalArgs();

            var journal = service.CreateJournal(args);

            journal.Should().NotBeNull();
            journal.Id.Should().NotBe(0);
            journal.PersonId.Should().Be(args.PersonId);
            journal.JournalTitle.Should().Be(args.JournalTitle);
        }

        [Fact]
        public void WhenCreatingAJournal_WithValidArgs_ItUpdatesTheAuditingData()
        {
            var service = CreateJournalConfigurationService();
            var args = CreateCreateJournalArgs();

            var journal = service.CreateJournal(args);

            journal.CreatedBy.Should().NotBeNull();
            journal.CreatedDate.Should().NotBeNull();
            journal.ModifiedBy.Should().NotBeNull();
            journal.ModifiedDate.Should().NotBeNull();
        }
    }
}
