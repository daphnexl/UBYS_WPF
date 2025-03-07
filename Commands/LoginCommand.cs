using System;
using System.Windows;
using System.Windows.Controls;
using UBYS_WPF.Helpers;
using UBYS_WPF.MVVM.Models;
using UBYS_WPF.MVVM.ViewModels;
using UBYS_WPF.MVVM.Views;
using UBYS_WPF.Services;
using UBYS_WPF.Commands;

namespace UBYS_WPF.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly MainVM _viewModel;
        private readonly INavigationService _navigationService;

        public LoginCommand(MainVM viewModel, INavigationService navigationService)
        {
            _viewModel = viewModel;
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            // Kullanıcı adı ile veritabanından kullanıcıyı al
            User user = DatabaseHelper.GetUserByFullName(_viewModel.Username);

            // Kullanıcı bulundu mu ve şifre doğru mu?
            if (user != null && user.PasswordHash == DatabaseHelper.HashPassword(_viewModel.Password))
            {
                UserControl targetView = null;

                // Kullanıcının rolüne göre uygun UserControl'ü seç
                switch (user.Role)
                {
                    case Role.Admin:
                        targetView = new AdminView();
                        break;
                    case Role.Teacher:
                        targetView = new TeacherView();
                        break;
                    case Role.Student:
                        targetView = new StudentView();
                        break;
                }

                // Yönlendirme yap
                if (targetView != null)
                {
                    _navigationService.Navigate(targetView);
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Giriş Başarısız", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
