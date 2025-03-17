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
        private static User _loggedInUser = null;
        private static string connectionString = "Data Source=UBYS.db;Version=3;";
        public static void CreateDatabase()
        {
            string dbPath = "UBYS.db";
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string createTableQuery = @"
                        CREATE TABLE Users (
                            ID INTEGER PRIMARY KEY AUTOINCREMENT, 
                            FullName TEXT NOT NULL, 
                            Email TEXT NOT NULL,
                            Phone TEXT,
                            PasswordHash TEXT NOT NULL, 
                            Role TEXT NOT NULL,
                            BirthDate TEXT
                        )";
                    using (var command = new SQLiteCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Database created successfully.");
            }
        }
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
        public static void SeedUsers()
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();
                string checkQuery = "SELECT COUNT(*) FROM Users";
                using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, con))
                {
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count == 0)
                    {
                        string insertQuery = @"
                            INSERT INTO Users (FullName, Email, Phone, PasswordHash, Role, BirthDate) VALUES 
                            ('Admin User', 'admin@example.com', '1234567890', @adminPass, 'Admin', '1980-01-01'),
                            ('Teacher One', 'teacher1@example.com', '1234567891', @teacher1Pass, 'Teacher', '1985-05-15'),
                            ('Student One', 'student1@example.com', '1234567892', @student1Pass, 'Student', '2000-09-20')";
                        using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, con))
                        {
                            insertCmd.Parameters.AddWithValue("@adminPass", HashPassword("adminPass123"));
                            insertCmd.Parameters.AddWithValue("@teacher1Pass", HashPassword("teacher1Pass"));
                            insertCmd.Parameters.AddWithValue("@student1Pass", HashPassword("student1Pass"));
                            insertCmd.ExecuteNonQuery();
                        }
                        Console.WriteLine("Users seeded successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Users already exist.");
                    }
                }
            }
        }
        public static User GetLoggedInUser() => _loggedInUser;
        public static void SetLoggedInUser(User user) => _loggedInUser = user;
        public static void LogoutUser() => _loggedInUser = null;
        public static User GetUserByFullName(string fullName)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand("SELECT * FROM Users WHERE FullName = @FullName", connection))
                {
                    command.Parameters.AddWithValue("@FullName", fullName);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                Enum.Parse<Role>(reader.GetString(5)),
                                DateTime.Parse(reader.GetString(6))
                            );
                        }
                    }
                }
            }
            return null;
        }
    }
}
