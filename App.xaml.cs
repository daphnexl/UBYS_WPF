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
using System.Windows.Navigation;

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
  
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<NavigationBarPropertiesStore>();
            services.AddSingleton<TeacherNavigationBarPropertiesStore>();
            services.AddSingleton<AdminNavigationBarPropertiesStore>();

           

            //Services
            services.AddSingleton<INavigationService>(s => CreateHomeNavigationService(s));
            services.AddSingleton<TeacherNavigationBarPropertiesServices>(s => new TeacherNavigationBarPropertiesServices(s.GetRequiredService<TeacherNavigationBarPropertiesStore>()));
            services.AddSingleton<AdminNavigationBarProServices>(s => new AdminNavigationBarProServices(s.GetRequiredService<AdminNavigationBarPropertiesStore>()));
            services.AddSingleton<NavigationBarPropertiesServices>(s => new NavigationBarPropertiesServices(s.GetRequiredService<NavigationBarPropertiesStore>()));


          


            //ViewModels
            services.AddSingleton<AdminNavigationBarViewModel>(s => new AdminNavigationBarViewModel(
                s.GetRequiredService<AdminNavigationBarPropertiesStore>(),
                s.GetRequiredService<AdminNavigationBarProServices>()));

            services.AddSingleton<TeacherNavigationBarViewModel>(s => new TeacherNavigationBarViewModel(
                s.GetRequiredService<TeacherNavigationBarPropertiesStore>(),
                s.GetRequiredService<TeacherNavigationBarPropertiesServices>()));

            services.AddTransient<NavigationBarViewModel>(s => new NavigationBarViewModel(
                s.GetRequiredService<NavigationBarPropertiesStore>(),
                s.GetRequiredService<NavigationBarPropertiesServices>()));

            services.AddTransient<MainVM>(s => new MainVM(
                 s.GetRequiredService<NavigationService>(),
                 CreateNavigationService(s)));

            services.AddTransient<HomeVM>(s => new HomeVM(
               s.GetRequiredService<HomeStore>(),
               CreateHomeNavigationService(s)));

            services.AddTransient<ExitVM>(s => new ExitVM(
               s.GetRequiredService<ExitStore>(),
               CreateHomeNavigationService(s)));

            services.AddTransient<MyScoreVM>(s => new MyScoreVM(
               s.GetRequiredService<MyScoreStore>(),
               CreateHomeNavigationService(s)));


            services.AddTransient<CourseSelectionVM>(s => new CourseSelectionVM(
               s.GetRequiredService<CourseSelectionStore>(),
               CreateHomeNavigationService(s)));

            services.AddTransient<SFCourseSelectionVM>(s => new SFCourseSelectionVM(
               s.GetRequiredService<SFCourseSelectionStore>(),
               CreateHomeNavigationService(s)));

            


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
            return new NavigationService<HomeVM>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<HomeVM>());
        }

        private INavigationService CreateExitNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<ExitVM>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<ExitVM>());
        }
        private INavigationService CreateCourseSelectionNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<CourseSelectionVM>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<CourseSelectionVM>());
        }

        private INavigationService CreateMyScoreNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<MyScoreVM>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<MyScoreVM>());
        }
        private INavigationService CreateSFCourseSelectionNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<SFCourseSelectionVM>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<SFCourseSelectionVM>());
        }

    

    }
}
