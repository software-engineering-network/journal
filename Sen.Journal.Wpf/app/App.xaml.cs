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
            OpenMainWindow();
        }

        #endregion

        private void OpenMainWindow()
        {
            var mainWindowViewModel = AutofacContainer.Resolve<MainWindowViewModel>();
            var mainWindow = new MainWindow();
            mainWindow.DataContext = mainWindowViewModel;
            mainWindow.Show();
        }
    }
}
