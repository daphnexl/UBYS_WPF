using System.Windows.Input;
using UBYS_WPF.Commands;
using UBYS_WPF.Cores;
using UBYS_WPF.Helpers;
using UBYS_WPF.MVVM.Models;
using UBYS_WPF.Services;
using System.Windows.Controls;
using UBYS_WPF.MVVM.Views;

namespace UBYS_WPF.MVVM.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        private User _currentUser;
        private readonly INavigationService _loginNavigationService; // Giriş ekranına gitmek için

        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateAccountCommand { get; }
        public ICommand NavigatePeopleListingCommand { get; }
        public ICommand LogoutCommand { get; }

        public bool IsLoggedIn => _currentUser != null;

        public NavigationBarViewModel(
            INavigationService homeNavigationService,
            INavigationService loginNavigationService,
            INavigationService peopleListingNavigationService)
        {
            NavigateHomeCommand = new NavigateCommand(homeNavigationService);
            _loginNavigationService = loginNavigationService;
            NavigatePeopleListingCommand = new NavigateCommand(peopleListingNavigationService);
            LogoutCommand = new RelayCommand(Logout);

            // Kullanıcı bilgisini yükle
            LoadCurrentUser();
        }

        private void LoadCurrentUser()
        {
            _currentUser = DatabaseHelper.GetLoggedInUser();
            OnPropertyChanged(nameof(IsLoggedIn));
        }

        private void Logout(object parameter)
        {
            DatabaseHelper.LogoutUser();
            _currentUser = null;
            OnPropertyChanged(nameof(IsLoggedIn));

            // Giriş ekranına yönlendir
            _loginNavigationService.Navigate(new MainWindow());
        }
    }
}
