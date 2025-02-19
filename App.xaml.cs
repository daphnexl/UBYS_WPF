using System.Configuration;
using System.Data;
using System.Windows;
using UBYS_WPF.MVVM.ViewModels;
using UBYS_WPF.MVVM.Views;

namespace UBYS_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // ViewModel oluştur
            var mainVM = new MainVM();

            // View oluştur ve DataContext olarak ViewModel'i bağla
            var mainWindow = new MainWindow
            {
                DataContext = mainVM
            };

            // Pencereyi göster
            mainWindow.Show();

            base.OnStartup(e);
        }
    }

}
