using Autofac;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using SoftwareEngineeringNetwork.JournalApplication.Services;

namespace SoftwareEngineeringNetwork.JournalApplication.Wpf
{
    public static class AutofacSetup
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            RegisterModules(builder);

            return builder.Build();
        }

        public static void RegisterModules(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule<WpfModule>();
            containerBuilder.RegisterModule<ServicesModule>();
            containerBuilder.RegisterModule<DomainModule>();
        }
    }
}
