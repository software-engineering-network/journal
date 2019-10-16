using FluentAssertions;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using SoftwareEngineeringNetwork.JournalApplication.Infrastructure.InMemory;
using Xunit;

namespace SoftwareEngineeringNetwork.JournalApplication.Test.Infrastructure.InMemory
{
    public class InMemoryRepositoryTest
    {
        [Fact]
        public void WhenCreatingAnEntity_WithValidArgs_ItCreatesAndReturnsAnEntity()
        {
            var johnDoe = TestObjectFactory.CreateJohnDoe();
            var currentUserProvider = new JohnDoeCurrentUserProvider();
            var personRepository = new PersonRepository(currentUserProvider);

            johnDoe = personRepository.Create(johnDoe);

            johnDoe.Should().NotBeNull();
            johnDoe.Id.Should().Be(1ul);
        }
    }
}
