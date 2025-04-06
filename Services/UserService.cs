using UBYS_WPF.MVVM.Models;  // User modelini kullanabilmek için gerekli using
using System;

namespace UBYS_WPF.Services
{
    public class UserService
    {
        // Kullanıcıyı e-posta ile doğrulama
        public User AuthenticateUser(string email, string password)
        {
            var user = DatabaseHelper.GetUserByEmail(email);
            if (user != null && VerifyPassword(password, user.PasswordHash))
            {
                return user;  // Kullanıcı doğrulandıysa, kullanıcıyı döndür
            }
            return null;  // Hatalı giriş durumunda null döndür
        }

        // Şifre doğrulama
        private bool VerifyPassword(string inputPassword, string storedHash)
        {
            return DatabaseHelper.HashPassword(inputPassword) == storedHash;
        }

        // Kullanıcıyı Id ile al
        public User GetUserById(int id)
        {
            return DatabaseHelper.GetUserById(id);
        } // DatabaseHelper sınıfını kullanarak veritabanından kullanıcı
    }
}