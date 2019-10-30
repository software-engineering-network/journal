using Autofac;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterValidators(builder);
            RegisterAuditing(builder);
            RegisterFactories(builder);
            RegisterServices(builder);
        }

        private static void RegisterValidators(ContainerBuilder builder)
        {
            builder.RegisterType<JournalEntryContentIsRequiredValidator>();
            builder.RegisterType<JournalIdMustExistValidator>();
            builder.RegisterType<JournalTitleIsRequiredValidator>();
            builder.RegisterType<JournalTitleMustNotExistValidator>();
            builder.RegisterType<EmailAddressIsRequiredValidator>();
            builder.RegisterType<EmailAddressMustBeValid>();
            builder.RegisterType<EmailAddressMustNotExistValidator>();
            builder.RegisterType<NameIsRequiredValidator>();
            builder.RegisterType<PasswordIsRequiredValidator>();
            builder.RegisterType<SurnameIsRequiredValidator>();
            builder.RegisterType<UserIdMustExistValidator>();
            builder.RegisterType<UsernameIsRequiredValidator>();
            builder.RegisterType<UsernameMustNotExistValidator>();

            builder.RegisterType<CreateJournalValidator>();
            builder.RegisterType<CreateUserValidator>();
        }

        private static void RegisterAuditing(ContainerBuilder builder)
        {
            builder.RegisterType<Auditable>().As<IAuditable>();
        }

        private static void RegisterFactories(ContainerBuilder builder)
        {
            builder.RegisterType<UserFactory>().As<IUserFactory>();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<BasicDateTimeProvider>().As<IDateTimeProvider>();
            builder.RegisterType<CurrentUserProvider>().As<ICurrentUserProvider>();
        }
    }
}
