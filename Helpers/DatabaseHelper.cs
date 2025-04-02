using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using UBYS_WPF.Helpers;
using UBYS_WPF.MVVM.Models;
using UBYS_WPF.MVVM.ViewModels;
using UBYS_WPF.MVVM.Views;
using UBYS_WPF.Services;

namespace UBYS_WPF
{
    // Database Helper


    public static class DatabaseHelper
    {
        private static string connectionString = "Data Source=your_database.db;Version=3;";

        public static void CreateUser(string fullName, string email, string password, string role)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Users (FullName, Email, PasswordHash, Role) VALUES (@FullName, @Email, @PasswordHash, @Role)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FullName", fullName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PasswordHash", HashPassword(password));
                    command.Parameters.AddWithValue("@Role", role);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static User GetUserByEmail(string email)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Users WHERE Email = @Email";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User(
                                 
                        reader.GetInt32(0),                      // Id
                        reader.GetString(1),                     // FullName
                        reader.GetString(2),                     // Email
                        reader.GetString(3),                     // Phone
                        reader.GetString(4),                     // PasswordHash
                        Enum.Parse<Role>(reader.GetString(5)),   // Role (Enum)
                        reader.GetDateTime(6)                    // BirthDate
                            );
                        }
                    }
                }
            }
            return null;
        }
        public static User GetUserByFullName(string fullName)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Users WHERE FullName = @FullName";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FullName", fullName);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User(
                                reader.GetInt32(0),                      // Id
                                reader.GetString(1),                     // FullName
                                reader.GetString(2),                     // Email
                                reader.GetString(3),                     // Phone
                                reader.GetString(4),                     // PasswordHash
                                Enum.Parse<Role>(reader.GetString(5)),   // Role (Enum)
                                reader.GetDateTime(6)                    // BirthDate
                            );
                        }
                    }
                }
            }
            return null;
        }


        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
    }

}
