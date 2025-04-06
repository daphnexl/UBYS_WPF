using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using UBYS_WPF.MVVM.ViewModels;
using UBYS_WPF.MVVM.Views;
using UBYS_WPF.Stores;
using UBYS_WPF.Services;

namespace UBYS_WPF
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            // Stores
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<NavigationBarPropertiesStore>();
            services.AddSingleton<TeacherNavigationBarPropertiesStore>();
            services.AddSingleton<AdminNavigationBarPropertiesStore>();

            // Services
            services.AddSingleton<INavigationService>(s => CreateHomeNavigationService(s));
            services.AddSingleton<NavigationBarPropertiesServices>(s => new NavigationBarPropertiesServices(s.GetRequiredService<NavigationBarPropertiesStore>()));
            services.AddSingleton<TeacherNavigationBarPropertiesServices>(s => new TeacherNavigationBarPropertiesServices(s.GetRequiredService<TeacherNavigationBarPropertiesStore>()));
            services.AddSingleton<AdminNavigationBarProServices>(s => new AdminNavigationBarProServices(s.GetRequiredService<AdminNavigationBarPropertiesStore>()));

            // ViewModels
            services.AddSingleton<MainVM>(s => new MainVM(
                s.GetRequiredService<INavigationService>(),
                s.GetRequiredService<NavigationStore>()
            ));

            services.AddTransient<HomeVM>(s => new HomeVM(
                s.GetRequiredService<HomeStore>(),
                s.GetRequiredService<INavigationService>()
            ));

            services.AddTransient<ExitVM>(s => new ExitVM(
                s.GetRequiredService<ExitStore>(),
                s.GetRequiredService<INavigationService>()
            ));

            services.AddTransient<MyScoreVM>(s => new MyScoreVM(
                s.GetRequiredService<MyScoreStore>(),
                s.GetRequiredService<INavigationService>()
            ));

            services.AddTransient<CourseSelectionVM>(s => new CourseSelectionVM(
                s.GetRequiredService<CourseSelectionStore>(),
                s.GetRequiredService<INavigationService>()
            ));

            services.AddTransient<SFCourseSelectionVM>(s => new SFCourseSelectionVM(
                s.GetRequiredService<SFCourseSelectionStore>(),
                s.GetRequiredService<INavigationService>()
            ));

            // Windows
            services.AddSingleton<MainWindow>(s => new MainWindow
            {
                DataContext = s.GetRequiredService<MainVM>()
            });

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            // Initialize navigation service and start the application
            var initialNavigationService = _serviceProvider.GetRequiredService<INavigationService>();
            initialNavigationService.Navigate();

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        private INavigationService CreateHomeNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<HomeVM>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<HomeVM>()
            );
        }

        private INavigationService CreateExitNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<ExitVM>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<ExitVM>()
            );
        }

        private INavigationService CreateCourseSelectionNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<CourseSelectionVM>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<CourseSelectionVM>()
            );
        }

        private INavigationService CreateMyScoreNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<MyScoreVM>(
                serviceProvider.GetRequiredService<NavigationStore>()
                );
        }
    }
}
