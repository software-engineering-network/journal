using Autofac;

namespace SoftwareEngineeringNetwork.JournalApplication.Services
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterManagementServices(builder);
            RegisterModelServices(builder);
        }

        private static void RegisterManagementServices(ContainerBuilder builder)
        {
            builder.RegisterType<JournalEntryManagementService>().As<IJournalEntryManagementService>();
            builder.RegisterType<JournalManagementService>().As<IJournalManagementService>();
            builder.RegisterType<UserManagementService>().As<IUserManagementService>();
        }

        private static void RegisterModelServices(ContainerBuilder builder)
        {
            builder.RegisterType<JournalEntryService>().As<IJournalEntryService>();
            builder.RegisterType<JournalService>().As<IJournalService>();
            builder.RegisterType<UserService>().As<IUserService>();
        }
    }
}
