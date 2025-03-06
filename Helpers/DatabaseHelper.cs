using System;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace UBYS_WPF.Helpers
{
    public static class DatabaseHelper
    {
        // Veritabanı dosyasının yolu
        private static string connectionString = "Data Source=UBYS.db;Version=3;";
        // Veritabanını oluştur
        public static void CreateDatabase()
        {
            string dbPath = "UBYS.db"; // Veritabanı dosya adı
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string createTableQuery = @"
                        CREATE TABLE Users (
                            ID INTEGER PRIMARY KEY AUTOINCREMENT, 
                            Username TEXT NOT NULL, 
                            PasswordHash TEXT NOT NULL, 
                            Role TEXT NOT NULL)";
                    using (var command = new SQLiteCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Database created successfully.");
            }
        }
        // Şifre hash'leme işlemi
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
        // Kullanıcıları veritabanına ekle
        public static void SeedUsers()
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();
                // Kullanıcı sayısını kontrol et
                string checkQuery = "SELECT COUNT(*) FROM Users";
                using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, con))
                {
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count == 0) // Eğer hiç kullanıcı yoksa ekleyelim
                    {
                        // Kullanıcıları ekle
                        string insertQuery = @"
                            INSERT INTO Users (Username, PasswordHash, Role) VALUES 
                            ('admin', @adminPass, 'Admin'),
                            ('teacher1', @teacher1Pass, 'Teacher'),
                            ('teacher2', @teacher2Pass, 'Teacher'),
                            ('student1', @student1Pass, 'Student'),
                            ('student2', @student2Pass, 'Student'),
                            ('student3', @student3Pass, 'Student'),
                            ('student4', @student4Pass, 'Student'),
                            ('student5', @student5Pass, 'Student'),
                            ('student6', @student6Pass, 'Student'),
                            ('student7', @student7Pass, 'Student'),
                            ('student8', @student8Pass, 'Student'),
                            ('student9', @student9Pass, 'Student'),
                            ('student10', @student10Pass, 'Student')";

                        using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, con))
                        {
                            // Şifreleri hash'le
                            insertCmd.Parameters.AddWithValue("@adminPass", HashPassword("adminPass123"));
                            insertCmd.Parameters.AddWithValue("@teacher1Pass", HashPassword("teacher1Pass"));
                            insertCmd.Parameters.AddWithValue("@teacher2Pass", HashPassword("teacher2Pass"));
                            insertCmd.Parameters.AddWithValue("@student1Pass", HashPassword("student1Pass"));
                            insertCmd.Parameters.AddWithValue("@student2Pass", HashPassword("student2Pass"));
                            insertCmd.Parameters.AddWithValue("@student3Pass", HashPassword("student3Pass"));
                            insertCmd.Parameters.AddWithValue("@student4Pass", HashPassword("student4Pass"));
                            insertCmd.Parameters.AddWithValue("@student5Pass", HashPassword("student5Pass"));
                            insertCmd.Parameters.AddWithValue("@student6Pass", HashPassword("student6Pass"));
                            insertCmd.Parameters.AddWithValue("@student7Pass", HashPassword("student7Pass"));
                            insertCmd.Parameters.AddWithValue("@student8Pass", HashPassword("student8Pass"));
                            insertCmd.Parameters.AddWithValue("@student9Pass", HashPassword("student9Pass"));
                            insertCmd.Parameters.AddWithValue("@student10Pass", HashPassword("student10Pass"));
                            // Kullanıcıları ekle
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
    }
}
