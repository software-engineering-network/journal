using FluentAssertions;
using SoftwareEngineeringNetwork.JournalApplication.Infrastructure.InMemory;
using SoftwareEngineeringNetwork.JournalApplication.Services;
using Xunit;

namespace SoftwareEngineeringNetwork.JournalApplication.Test.services
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

        private static UpdateJournalArgs CreateUpdateJournalArgs(
            ulong id = 1,
            ulong personId = 2,
            string journalTitle = "Medical Journal"
        )
        {
            return new UpdateJournalArgs
            {
                Id = id,
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
            journal.UserId.Should().Be(args.PersonId);
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

        [Fact]
        public void WhenUpdatingAJournal_WithValidArgs_ItUpdatesTheAuditingData()
        {
            var service = CreateJournalConfigurationService();
            var createArgs = CreateCreateJournalArgs();
            var journal = service.CreateJournal(createArgs);

            var updateArgs = CreateUpdateJournalArgs();
            journal = service.UpdateJournal(updateArgs);

            journal.UserId.Should().Be(updateArgs.PersonId);
            journal.JournalTitle.Should().Be(updateArgs.JournalTitle);
            journal.ModifiedBy.Should().NotBeNull();
            journal.ModifiedDate.Should().NotBeNull();
        }
    }
}
