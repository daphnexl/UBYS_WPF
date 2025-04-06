using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBYS_WPF.MVVM.Models;

namespace UBYS_WPF.Services
{
    public class AuthService
    {
        public User AuthenticateUser(string email, string password)
        {
            var user = DatabaseHelper.GetUserByEmail(email);
            if (user != null && VerifyPassword(password, user.PasswordHash))
            {
                return user;
            }
            return null;
        }

        private bool VerifyPassword(string inputPassword, string storedHash)
        {
            return DatabaseHelper.HashPassword(inputPassword) == storedHash;
        }
    }

}
