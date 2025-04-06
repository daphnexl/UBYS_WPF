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
        private readonly AuthService _authService;
        private readonly NavigationService<ViewModelBase> _navigationService;

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

        public MainVM(NavigationStore navigationStore, AuthService authService, NavigationService<ViewModelBase> navigationService)
        {
            _navigationStore = navigationStore;
            _authService = authService;
            _navigationService = navigationService;

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
            var user = _authService.AuthenticateUser(Email, Password);

            if (user != null)
            {
                _navigationService.NavigateToRoleBasedView(user);
            }
            else
            {
                MessageBox.Show("Giriş bilgileri hatalı!", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TogglePasswordVisibility()
        {
            IsPasswordVisible = !IsPasswordVisible;
            ToggleButtonIcon = IsPasswordVisible ? "/Assets/Eye.png" : "/Assets/Invisible.png";
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
    }
}