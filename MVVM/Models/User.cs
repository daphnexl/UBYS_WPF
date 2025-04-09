using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace UBYS_WPF.MVVM.Models
{
    public enum Role
    {
        Admin,
        Student,
        Teacher
    }
    public class User
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }

        public string ImagePath { get; set; } // Örn: "Images/student1.jpg"

        public Role Role { get; set; }
        public DateTime BirthDate { get; set; }

        public User(int id, string fullName, string email, string phone,string imagepath, string passwordHash, Role role, DateTime birthDate)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Phone = phone;
            ImagePath = imagepath;
            PasswordHash = passwordHash;
            Role = role;
            BirthDate = birthDate;
        }
    }
}
