using System.ComponentModel;
using Autofac;

namespace SoftwareEngineeringNetwork.JournalApplication.Wpf
{
    public class WpfModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainWindowViewModel>();
            builder.RegisterType<NotifyPropertyChanged>().As<INotifyPropertyChanged>();
            builder.RegisterType<CreateJournalDialogViewModelFactory>().As<ICreateJournalDialogViewModelFactory>();
        }
    }
}
