using System.Configuration;
using System.Data;
using System.Windows;
using UBYS_WPF.MVVM.ViewModels;
using UBYS_WPF.MVVM.Views;
using UBYS_WPF.Services;
using UBYS_WPF.Stores;

namespace UBYS_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // NavigationStore oluştur
            var navigationStore = new NavigationStore();

            // INavigationService oluştur (örneğin, NavigationService)
            var navigationService = new NavigationService(navigationStore);

            // ViewModel oluştur ve NavigationService'i enjekte et
            var mainVM = new MainVM(navigationStore, navigationService);

            // View oluştur ve DataContext olarak ViewModel'i bağla
            var mainWindow = new MainWindow(mainVM)
            {
                DataContext = mainVM
            };

            // Pencereyi göster
            mainWindow.Show();
        }
    }
}
