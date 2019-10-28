using SoftwareEngineeringNetwork.JournalApplication.Domain;
using SoftwareEngineeringNetwork.JournalApplication.Infrastructure.InMemory;

namespace SoftwareEngineeringNetwork.JournalApplication.Test
{
    public static class TestUnitOfWorkFactory
    {
        public static IUnitOfWork CreateUnitOfWork()
        {
            var context = new Context();
            var currentUserProvider = TestObjectFactory.CreateCurrentUserProvider();
            var unitOfWork = new UnitOfWork(context, currentUserProvider);
            return unitOfWork;
        }

        public static IUnitOfWork WithUsers(this IUnitOfWork unitOfWork)
        {
            unitOfWork.UserRepository.Create(TestUserFactory.CreateJohnDoe(1));
            unitOfWork.UserRepository.Create(TestUserFactory.CreateJaneDoe(2));
            return unitOfWork;
        }

        public static IUnitOfWork WithJournals(this IUnitOfWork unitOfWork)
        {
            unitOfWork.JournalRepository.Create(TestJournalFactory.CreateMusicCoversJournal(1));
            unitOfWork.JournalRepository.Create(TestJournalFactory.CreateJournal(2, 1, "Existing Journal Title"));
            return unitOfWork;
        }
    }
}
