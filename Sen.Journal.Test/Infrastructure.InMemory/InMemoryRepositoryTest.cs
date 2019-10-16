using FluentAssertions;
using Sen.Journal.Domain;
using Sen.Journal.Infrastructure.InMemory;
using Xunit;

namespace Sen.Journal.Test.Infrastructure.InMemory
{
    public class InMemoryRepositoryTest
    {
        [Fact]
        public void WhenCreatingAnEntity_WithValidArgs_ItCreatesAndReturnsAnEntity()
        {
            var johnDoe = TestObjectFactory.CreateJohnDoe();
            var currentUserProvider = new JohnDoeCurrentUserProvider();
            var personRepository = new PersonRepository(currentUserProvider);

            var johnDoeFromStorage = personRepository.Create(johnDoe);

            johnDoeFromStorage.Should().NotBeNull();
            johnDoeFromStorage.Id.Should().Be(1ul);
        }
    }
}
