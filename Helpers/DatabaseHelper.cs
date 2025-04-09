using System;
using System.Data;
using System.Data.Entity;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using UBYS_WPF.MVVM.Models;

namespace UBYS_WPF.Services
{
    public class DatabaseHelper
    {
        private static readonly string connectionString = $"Data Source={System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ubys.db")};Version=3;";
        private static  readonly SQLiteConnection _database = new SQLiteConnection(connectionString);
        public static void Initialize()
        {
            if (!File.Exists(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ubys.db")))
            {
                SQLiteConnection.CreateFile(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ubys.db"));
            }
            _database.Open();
        }
        public static void Shutdown()
        {
            if (_database != null && _database.State == ConnectionState.Open)
            {
                _database.Close();
                _database.Dispose();
            }
        }
        public static SQLiteConnection GetConnection()
        {
            return _database;
        }

        // Kullanıcı ekleme
        public static void CreateUser(string fullName, string email, string phone, string imagepath, string password, string role, DateTime birthdate)
        {
            try
            {

                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Users (FullName, Email,Phone,ImagePath, PasswordHash, Role,BirthDate) VALUES (@FullName, @Email, @Phone,@ImagePath, @PasswordHash, @Role, @BirthDate)";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FullName", fullName);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Phone", phone);
                        command.Parameters.AddWithValue("@ImagePath", imagepath);
                        command.Parameters.AddWithValue("@PasswordHash", HashPassword(password));
                        command.Parameters.AddWithValue("@Role", role);
                        command.Parameters.AddWithValue("@BirthDate", birthdate);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("HATA OLUŞTU:" + ex.Message);
                System.Windows.MessageBox.Show("Kullanıcı eklenirken bir hata oluştu.\nDetay: " + ex.Message, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // E-posta ile kullanıcıyı alma
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
                                reader.GetString(4),                     // P
                                reader.GetString(5),                     // PasswordHash
                                Enum.Parse<Role>(reader.GetString(5)),   // Role (Enum)
                                reader.GetDateTime(6)                    // BirthDate
                            );
                        }
                    }
                }
            }
            return null;
        }

        // Ad ile kullanıcıyı alma
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
                                reader.GetString(4),                     // ImagePath
                                reader.GetString(5),                     // PasswordHash
                                Enum.Parse<Role>(reader.GetString(6)),   // Role (Enum)
                                reader.GetDateTime(7)                    // BirthDate
                            );
                        }
                    }
                }
            }
            return null;
        }

        // ID ile kullanıcıyı alma
        public static User GetUserById(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Users WHERE Id = @Id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User(
                                reader.GetInt32(0),                      // Id
                                reader.GetString(1),                     // FullName
                                reader.GetString(2),                     // Email
                                reader.GetString(3),                     // Phone
                                reader.GetString(4),                     // ImagePath
                                reader.GetString(5),                     // PasswordHash
                                Enum.Parse<Role>(reader.GetString(6)),   // Role (Enum)
                                reader.GetDateTime(7)                    // BirthDate
                            );
                        }
                    }
                }
            }
            return null;
        }

        // Şifreyi hashlemek
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
