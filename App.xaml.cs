using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using UBYS_WPF.MVVM.ViewModels;
using UBYS_WPF.MVVM.Views;
using UBYS_WPF.Services;
using UBYS_WPF.Stores;

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
        services.AddSingleton<AuthService>();

        // Navigation services
        services.AddSingleton<NavigationService<HomeVM>>(s =>
         new NavigationService<HomeVM>(
             () => s.GetRequiredService<HomeVM>(),
             vm => s.GetRequiredService<NavigationStore>().CurrentViewModel = vm
         ));

        services.AddSingleton<NavigationService<ExitVM>>(s =>
         new NavigationService<ExitVM>(
        () => s.GetRequiredService<ExitVM>(),
        vm => s.GetRequiredService<NavigationStore>().CurrentViewModel = vm
         ));

        services.AddSingleton<NavigationService<MyScoreVM>>(s =>
            new NavigationService<MyScoreVM>(
                () => s.GetRequiredService<MyScoreVM>(),
                vm => s.GetRequiredService<NavigationStore>().CurrentViewModel = vm
            ));

        services.AddSingleton<NavigationService<CourseSelectionVM>>(s =>
            new NavigationService<CourseSelectionVM>(
                () => s.GetRequiredService<CourseSelectionVM>(),
                vm => s.GetRequiredService<NavigationStore>().CurrentViewModel = vm
            ));    
        services.AddSingleton<NavigationService<SFCourseSelectionVM>>(s =>
            new NavigationService<SFCourseSelectionVM>(
                () => s.GetRequiredService<SFCourseSelectionVM>(),
                vm => s.GetRequiredService<NavigationStore>().CurrentViewModel = vm
            ));



        // ViewModels
        services.AddSingleton<MainVM>(s => new MainVM(
            s.GetRequiredService<NavigationStore>(),
            s.GetRequiredService<AuthService>(),
            s.GetRequiredService<NavigationService<ViewModelBase>>()  // dikkat!
        ));

        services.AddTransient<HomeVM>(s => new HomeVM(
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
        var initialNavigationService = _serviceProvider.GetRequiredService<INavigationService>();
        initialNavigationService.Navigate();

        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();

        base.OnStartup(e);
    }

    private INavigationService CreateHomeNavigationService(IServiceProvider serviceProvider)
    {
        return new NavigationService<HomeVM>(
            () => serviceProvider.GetRequiredService<HomeVM>(), // HomeVM'i oluşturmak için Func<HomeVM>
            vm => serviceProvider.GetRequiredService<NavigationStore>().CurrentViewModel = vm // ViewModel'i navigasyona ayarlamak için Action<ViewModelBase>
        );
    }

}
