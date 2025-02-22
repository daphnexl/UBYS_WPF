using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using UBYS_WPF.Cores;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace UBYS_WPF.MVVM.ViewModels
{
    public class MainVM : ViewModelBase
    {

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        private Brush _usernameTextColor;
        public Brush UsernameTextColor
        {
            get => _usernameTextColor;
            set
            {
                _usernameTextColor = value;
                OnPropertyChanged(nameof(UsernameTextColor));
            }
        }
        private readonly string _defaultText = "ID Number: XXXXXXXXXXX";

        public ICommand UsernameGotFocusCommand { get; }
        public ICommand UsernameLostFocusCommand { get; }
        public MainVM()
        {
            Username = _defaultText;
            UsernameTextColor = Brushes.Gray;

            UsernameGotFocusCommand = new RelayCommand(_ => OnUsernameFocus());
            UsernameLostFocusCommand = new RelayCommand(_ => OnUsernameLostFocus());


            Password = _defaultTextPassword;
            PasswordTextColor = Brushes.Gray;

            PasswordGotFocusCommand = new RelayCommand(_ => OnPasswordFocus());
            PasswordLostFocusCommand = new RelayCommand(_ => OnPasswordLostFocus());

            TogglePasswordCommand = new RelayCommand(_ => TogglePasswordVisibility());
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
    
    private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        private Brush _passwordTextColor;
        public Brush PasswordTextColor
        {
            get => _passwordTextColor;
            set
            {
                _passwordTextColor = value;
                OnPropertyChanged(nameof(UsernameTextColor));
            }
        }
        private readonly string _defaultTextPassword = "Password: ";

        public ICommand PasswordGotFocusCommand { get; }
        public ICommand PasswordLostFocusCommand { get; }
       
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
        private bool _isPasswordVisible;
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
        public Visibility PasswordBoxVisibility => IsPasswordVisible ? Visibility.Visible : Visibility.Collapsed;
        public Visibility TextBoxVisibility => IsPasswordVisible ? Visibility.Collapsed : Visibility.Visible;

        private string _toggleButtonIcon = "/Assets/Invisible.png";
        public string ToggleButtonIcon
        {
            get => _toggleButtonIcon;
            set
            {
                _toggleButtonIcon = value;
                OnPropertyChanged(nameof(ToggleButtonIcon));
            }
        }
        public ICommand TogglePasswordCommand { get; }

        private void TogglePasswordVisibility()
        {
            IsPasswordVisible = !IsPasswordVisible;
            ToggleButtonIcon = IsPasswordVisible ? "/Assets/Eye.png" : "/Assets/Invisible.png";
        }
       
    }


    }

