using Autofac;
using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Infrastructure.InMemory
{
    public class InfrastructureInMemoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JournalEntryRepository>().As<IJournalEntryRepository>();
            builder.RegisterType<JournalRepository>().As<IJournalRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
        }
    }
}
