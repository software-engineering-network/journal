using FluentAssertions;
using Sen.Journal.Infrastructure.InMemory;
using Xunit;

namespace Sen.Journal.Test.Infrastructure.InMemory
{
    public class PersonRepositoryTest
    {
        [Fact]
        public void WhenCreatingAPerson_WithValidArgs_ItCreatesAndReturnsAPerson()
        {
            var johnDoe = TestObjectFactory.CreateJohnDoe();
            var personRepository = new PersonRepository();

            var johnDoeFromStorage = personRepository.Create(johnDoe);

            johnDoeFromStorage.Id.Value.Should().Be(1);
            johnDoeFromStorage.EmailAddress.Should().Be(johnDoe.EmailAddress);
            johnDoeFromStorage.Password.Should().Be(johnDoe.Password);
            johnDoeFromStorage.Username.Should().Be(johnDoe.Username);
        }
    }
}
