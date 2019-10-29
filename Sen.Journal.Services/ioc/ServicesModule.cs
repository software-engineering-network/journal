using Autofac;

namespace SoftwareEngineeringNetwork.JournalApplication.Services
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JournalEntryService>().As<IJournalEntryService>();
            builder.RegisterType<JournalEntryManagementService>().As<IJournalEntryManagementService>();
            builder.RegisterType<JournalManagementService>().As<IJournalManagementService>();
            builder.RegisterType<JournalService>().As<IJournalService>();
            builder.RegisterType<UserManagementService>().As<IUserManagementService>();
            builder.RegisterType<UserService>().As<IUserService>();
        }
    }
}
