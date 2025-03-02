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
using Windows.Media.Audio;
using UBYS_WPF.MVVM.Views;
using System.ComponentModel;

namespace UBYS_WPF.MVVM.ViewModels
{
    public class MainVM : ViewModelBase
    {
        public string KullaniciTipi { get; set; } // Kullanıcı tipini saklamak için
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
       

        public ICommand Login {  get; }


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

        public MainVM()
        {
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
            



            Login = new RelayCommand(ExecuteLogin);
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
        private void ExecuteLogin(object obj)
        {
            Window window = null;

            if (Username == "admin" && Password == "1234")
            {
                window = new UBYS_WPF.MVVM.Views.AdminView(); // Eğer AdminView Window ise
            }
            else if (Username == "ogretmen" && Password == "1234")
            {
                window = new UBYS_WPF.MVVM.Views.TeacherView();
            }
            else if (Username == "ogrenci" && Password == "1234")
            {
                window = new UBYS_WPF.MVVM.Views.StudentView();
            }
            else
            {
                MessageBox.Show("Hatalı giriş!");
                return;
            }

            if (window != null)
            {
                window.Show();
                Application.Current.MainWindow.Close();
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

