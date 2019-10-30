using Autofac;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //RegisterValidators(builder);
            RegisterAuditing(builder);
            RegisterFactories(builder);
            RegisterServices(builder);
        }

        private void RegisterValidators(ContainerBuilder builder)
        {
            builder.RegisterType<JournalEntryContentIsRequiredValidator>();
            builder.RegisterType<JournalIdMustExistValidator>();
            builder.RegisterType<JournalTitleIsRequiredValidator>();
            builder.RegisterType<JournalTitleMustNotExistValidator>();
            builder.RegisterType<EmailAddressIsRequiredValidator>();
            builder.RegisterType<EmailAddressMustNotExistValidator>();
            builder.RegisterType<UserIdMustExistValidator>();
            builder.RegisterType<UsernameIsRequiredValidator>();
            builder.RegisterType<UsernameMustNotExistValidator>();
        }

        private void RegisterAuditing(ContainerBuilder builder)
        {
            builder.RegisterType<Auditable>().As<IAuditable>();
        }

        private void RegisterFactories(ContainerBuilder builder)
        {
            builder.RegisterType<UserFactory>().As<IUserFactory>();
        }

        private void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<BasicDateTimeProvider>().As<IDateTimeProvider>();
            builder.RegisterType<CurrentUserProvider>().As<ICurrentUserProvider>();
        }
    }
}
