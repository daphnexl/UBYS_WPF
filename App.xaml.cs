using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Interop;
using UBYS_WPF.Components;
using Microsoft.Extensions.ObjectPool;
using UBYS_WPF.MVVM.ViewModels;
using UBYS_WPF.MVVM.Views;
using UBYS_WPF.Services;
using UBYS_WPF.Stores;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace UBYS_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            //Stores
            services.AddSingleton<NavigationMonitorStore>();
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<NavigationBarPropertiesStore>();

            //Services
            services.AddSingleton<INavigationService>(s => CreateHomeNavigationService(s));

            //ViewModels
            services.AddSingleton<MainVM>();
            services.AddSingleton<LayoutViewModel>();
            services.AddTransient<NavigationBarViewModel>(s => CreateNavigationBarViewModel(s));

            //Windows
            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainVM>()
            });

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationService initialNavigationService = _serviceProvider.GetRequiredService<INavigationService>();
            initialNavigationService.Navigate();

            var monitorView = _serviceProvider.GetRequiredService<MainWindow>();
            monitorView.Show();

            base.OnStartup(e);
        }

        private INavigationService CreateHomeNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<MainVM>(
                serviceProvider.GetRequiredService<NavigationMonitorStore>(),
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>(),
                serviceProvider.GetRequiredService<NavigationBarPropertiesStore>());
        }

        private NavigationBarViewModel CreateNavigationBarViewModel(IServiceProvider serviceProvider)
        {
            return new NavigationBarViewModel(
                serviceProvider.GetRequiredService<NavigationBarPropertiesStore>(),
                CreateHomeNavigationService(serviceProvider),
                CreateConnectNavigationService(serviceProvider),
                CreateScanNavigationService(serviceProvider),
                CreateTestNavigationService(serviceProvider),
                CreateImagingNavigationService(serviceProvider));
        }
    }
}
