using System.ComponentModel;
using Autofac;

namespace SoftwareEngineeringNetwork.JournalApplication.Wpf
{
    public class WpfModule : Module
    {
        #region Module Overrides

        protected override void Load(ContainerBuilder builder)
        {
            RegisterCommands(builder);
            RegisterServices(builder);
            RegisterViewModels(builder);
        }

        #endregion

        private static void RegisterCommands(ContainerBuilder builder)
        {
            builder.RegisterType<OpenRegisterUserDialogCommand>();
            builder.RegisterType<RegisterUserCommand>();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<NotifyPropertyChanged>().As<INotifyPropertyChanged>();

            builder.RegisterType<CreateJournalDialogViewModelFactory>().As<ICreateJournalDialogViewModelFactory>();
        }

        private static void RegisterViewModels(ContainerBuilder builder)
        {
            builder.RegisterType<MainWindowViewModel>();
            builder.RegisterType<RegisterUserDialogViewModel>();
        }
    }
}
