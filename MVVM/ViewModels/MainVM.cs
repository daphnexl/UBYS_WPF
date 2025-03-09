using System;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using UBYS_WPF.MVVM.Views;
using System.ComponentModel;
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
        public ViewModelBase _currentViewModel => _navigationStore.CurrentViewModel;
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(_currentViewModel));
        }
        public string Role { get; set; } // Kullanıcı tipini saklamak için
        private string _username;
        private string _password;


        private Brush _usernameTextColor;
        private Brush _passwordTextColor;

        private readonly string _defaultText = "ID Number: XXXXXXXXXXX";
        private readonly string _defaultTextPassword = "Password: ";
        private string _toggleButtonIcon = "/Assets/Invisible.png";

        private bool _isPasswordVisible;

        public ICommand PasswordGotFocusCommand { get; }
        public ICommand PasswordLostFocusCommand { get; }
        public ICommand UsernameGotFocusCommand { get; }
        public ICommand UsernameLostFocusCommand { get; }
        public ICommand ForgotPasswordCommand { get; }
        public ICommand TogglePasswordCommand { get; }


        public ICommand LoginCommand { get; }


        public Visibility PasswordBoxVisibility => IsPasswordVisible ? Visibility.Visible : Visibility.Collapsed;
        public Visibility TextBoxVisibility => IsPasswordVisible ? Visibility.Collapsed : Visibility.Visible;

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

        public MainVM(NavigationStore navigationStore, INavigationService navigationService)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            // Username
            _username = Username = _defaultText;
            _usernameTextColor = UsernameTextColor = Brushes.Gray;

            UsernameGotFocusCommand = new RelayCommand(_ => OnUsernameFocus());
            UsernameLostFocusCommand = new RelayCommand(_ => OnUsernameLostFocus());

            // Password
            _password = Password = _defaultTextPassword;
            _passwordTextColor = PasswordTextColor = Brushes.Gray;

            PasswordGotFocusCommand = new RelayCommand(_ => OnPasswordFocus());
            PasswordLostFocusCommand = new RelayCommand(_ => OnPasswordLostFocus());
            TogglePasswordCommand = new RelayCommand(_ => TogglePasswordVisibility());
            ForgotPasswordCommand = new RelayCommand(_ => ShowForgotPasswordMessage());

            LoginCommand = new Commands.LoginCommand(this, navigationService);

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

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
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

        public string ToggleButtonIcon
        {
            get => _toggleButtonIcon;
            set
            {
                _toggleButtonIcon = value;
                OnPropertyChanged(nameof(ToggleButtonIcon));
            }
        }

        private void TogglePasswordVisibility()
        {
            IsPasswordVisible = !IsPasswordVisible;
            ToggleButtonIcon = IsPasswordVisible ? "/Assets/Eye.png" : "/Assets/Invisible.png";
        }
    }
}
