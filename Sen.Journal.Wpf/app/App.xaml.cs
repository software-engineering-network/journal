using System.Windows;
using Autofac;

namespace SoftwareEngineeringNetwork.JournalApplication.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IContainer AutofacContainer { get; set; }

        public App()
        {
            AutofacContainer = AutofacSetup.BuildContainer();
        }
    }
}
