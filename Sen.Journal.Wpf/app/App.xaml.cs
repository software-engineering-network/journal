using System.Windows;
using Autofac;

namespace SoftwareEngineeringNetwork.JournalApplication.Wpf
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Properties

        private static IContainer AutofacContainer { get; set; }

        #endregion

        #region Construction

        public App()
        {
            AutofacContainer = AutofacSetup.BuildContainer();

            ShowMainWindow();
        }

        #endregion

        private static void ShowMainWindow()
        {
            var mainWindow = new MainWindow {DataContext = AutofacContainer.Resolve<MainWindowViewModel>()};
            mainWindow.Show();
        }
    }
}
