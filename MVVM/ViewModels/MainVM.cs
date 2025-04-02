using System;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;
using UBYS_WPF.Services;
using UBYS_WPF.Stores;
using UBYS_WPF.Commands;
using UBYS_WPF.Helpers;
using UBYS_WPF.MVVM.Models;


namespace UBYS_WPF.MVVM.ViewModels
{
    public class MainVM : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly INavigationService _navigationService;
        private readonly AdminNavigationBarPropertiesStore _adminPropertiesStore;

        private string _email;
        private string _password;
        private string _errorMessage;
        private string _toggleButtonIcon = "/Assets/Invisible.png";
        private bool _isPasswordVisible;
        private Brush _usernameTextColor;
        private Brush _passwordTextColor;
        private string _username;

        private readonly string _defaultText = "ID Number: XXXXXXXXXXX";
        private readonly string _defaultTextPassword = "Password: ";

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand PasswordGotFocusCommand { get; }
        public ICommand PasswordLostFocusCommand { get; }
        public ICommand UsernameGotFocusCommand { get; }
        public ICommand UsernameLostFocusCommand { get; }
        public ICommand ForgotPasswordCommand { get; }
        public ICommand TogglePasswordCommand { get; }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public Brush UsernameTextColor
        {
            get => _usernameTextColor;
            set
            {
                _usernameTextColor = value;
                OnPropertyChanged(nameof(UsernameTextColor));
            }
        }

        public Brush PasswordTextColor
        {
            get => _passwordTextColor;
            set
            {
                _passwordTextColor = value;
                OnPropertyChanged(nameof(PasswordTextColor));
            }
        }

        public string ToggleButtonIcon
        {
            get => _toggleButtonIcon;
            set
            {
                _toggleButtonIcon = value;
                OnPropertyChanged(nameof(ToggleButtonIcon));
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public bool IsPasswordVisible
        {
            get => _isPasswordVisible;
            set
            {
                _isPasswordVisible = value;
                OnPropertyChanged(nameof(IsPasswordVisible));
                OnPropertyChanged(nameof(PasswordBoxVisibility));
                OnPropertyChanged(nameof(TextBoxVisibility));
            }
        }

        public Visibility PasswordBoxVisibility => _isPasswordVisible ? Visibility.Visible : Visibility.Collapsed;
        public Visibility TextBoxVisibility => _isPasswordVisible ? Visibility.Collapsed : Visibility.Visible;

        public MainVM(NavigationStore navigationStore, INavigationService navigationService)
        {
            _navigationStore = navigationStore;
            _navigationService = navigationService;
            _adminPropertiesStore = new AdminNavigationBarPropertiesStore();

            Username = _defaultText;
            UsernameTextColor = Brushes.Gray;

            Password = _defaultTextPassword;
            PasswordTextColor = Brushes.Gray;

            UsernameGotFocusCommand = new RelayCommand(_ => OnUsernameFocus());
            UsernameLostFocusCommand = new RelayCommand(_ => OnUsernameLostFocus());
            PasswordGotFocusCommand = new RelayCommand(_ => OnPasswordFocus());
            PasswordLostFocusCommand = new RelayCommand(_ => OnPasswordLostFocus());
            TogglePasswordCommand = new RelayCommand(_ => TogglePasswordVisibility());
            ForgotPasswordCommand = new RelayCommand(_ => ShowForgotPasswordMessage());
            LoginCommand = new RelayCommand(_ => Login());
        }

        public void Login()
        {
            var user = DatabaseHelper.GetUserByEmail(Email);

            if (user != null && VerifyPassword(Password, user.PasswordHash))
            {
                OpenViewForRole(user.Role);
            }
            else
            {
                MessageBox.Show("Giriş bilgileri hatalı!", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool VerifyPassword(string inputPassword, string storedHash)
        {
            return DatabaseHelper.HashPassword(inputPassword) == storedHash;
        }

        private void OpenViewForRole(Role role)
        {
            switch (role)
            {
                case Role.Admin:
                    _navigationStore.CurrentViewModel = new AdminNavigationBarViewModel(
                        _adminPropertiesStore,
                        new HomeNavigationService(_navigationStore),
                        new ExitNavigationService(),
                        new CourseSFNavigationService(_navigationStore),
                        new TeacherAppointmentNavigationService(_navigationStore),
                        new AddCourseNavigationService(_navigationStore)
                    );
                    break;
                case Role.Teacher:
                    _navigationStore.CurrentViewModel = new TeacherNavigationBarViewModel();
                    break;
                case Role.Student:
                    _navigationStore.CurrentViewModel = new NavigationBarViewModel(
     new NavigationBarPropertiesStore(),                      // navigationBarPropertiesStore
     new HomeNavigationService(_navigationStore),             // homeNavigationService
     new ExitNavigationService(),                             // exitNavigationService
     new MyScoreNavigationService(_navigationStore),          // myscoreNavigationService
     new CourseSelectionNavigationService(_navigationStore)   // courseselectionNavigationService
 );

                    break;
                default:
                    MessageBox.Show("KAYITLI DEĞİLSİNİZ!", "HATA", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
            }
        }

        public void ShowForgotPasswordMessage()
        {
            MessageBox.Show("Şifreyi yenilemek için sistem yöneticisi ile iletişime geçin.",
                            "Bilgilendirme",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
        }

        public void OnUsernameFocus()
        {
            if (Username == _defaultText)
            {
                Username = "";
                UsernameTextColor = Brushes.White;
            }
        }

        public void OnUsernameLostFocus()
        {
            if (string.IsNullOrWhiteSpace(Username))
            {
                Username = _defaultText;
                UsernameTextColor = Brushes.Gray;
            }
        }

        public void OnPasswordFocus()
        {
            if (Password == _defaultTextPassword)
            {
                Password = "";
                PasswordTextColor = Brushes.White;
            }
        }

        public void OnPasswordLostFocus()
        {
            if (string.IsNullOrWhiteSpace(Password))
            {
                Password = _defaultTextPassword;
                PasswordTextColor = Brushes.Gray;
            }
        }

        private void TogglePasswordVisibility()
        {
            IsPasswordVisible = !IsPasswordVisible;
            ToggleButtonIcon = IsPasswordVisible ? "/Assets/Eye.png" : "/Assets/Invisible.png";
        }
    }
}
