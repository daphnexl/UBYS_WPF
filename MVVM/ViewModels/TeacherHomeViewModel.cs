using UBYS_WPF.MVVM.Models;
using System.ComponentModel;
using UBYS_WPF.Helpers;
using System.Windows.Media.Imaging;
using System;

using UBYS_WPF.Services; // UserService'i ekleyin

namespace UBYS_WPF.MVVM.ViewModels
{
    public class TeacherHomeViewModel : ViewModelBase
    {
        private readonly DatabaseHelper _databaseHelper; // DatabaseHelper örneği
        private User _currentUser;
        public User CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
                OnPropertyChanged(nameof(FullName));
                OnPropertyChanged(nameof(Email));
                OnPropertyChanged(nameof(Role));
                LoadUserProfileImage(); // Kullanıcı değiştiğinde resmi yükle
            }
        }

        private BitmapImage _currentUserProfileImage;
        public BitmapImage CurrentUserProfileImage
        {
            get { return _currentUserProfileImage; }
            set
            {
                _currentUserProfileImage = value;
                OnPropertyChanged(nameof(CurrentUserProfileImage));
            }
        }

        public string FullName => CurrentUser?.FullName;
        public string Email => CurrentUser?.Email;
        public Role? Role => CurrentUser?.Role; // Nullable yapıldı

        public TeacherHomeViewModel()
        {
            _databaseHelper = new DatabaseHelper(); // DatabaseHelper örneğini oluşturun

            // Veritabanından kullanıcı çekme (örneğin, ID'ye göre)
            CurrentUser = _databaseHelper.GetUserByFullName("Teacher One"); // ID'si 1 olan kullanıcıyı çek
            // Veya giriş yapan kullanıcının emailine göre çek
            // CurrentUser = _databaseHelper.GetUserByEmail("kullanici@example.com");

            if (CurrentUser == null)
            {
                // Eğer kullanıcı bulunamazsa, varsayılan bir kullanıcı oluşturabilirsiniz
                CurrentUser = new User(1, "Varsayılan Kullanıcı", "default@example.com", "123-456-7890", "password", Role.Student, DateTime.Now);
            }

            LoadUserProfileImage();
        }

        public TeacherHomeViewModel(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        private void LoadUserProfileImage()
        {
            if (CurrentUser == null) return;

            string imageName = CurrentUser.FullName?.Replace(" ", "") + ".png";
            string imagePath = $"Assets/Profiles/{imageName}";

            try
            {
                BitmapImage image = new BitmapImage(new Uri($"pack://application:,,,/{imagePath}"));
                CurrentUserProfileImage = image;
            }
            catch (Exception)
            {
                CurrentUserProfileImage = new BitmapImage(new Uri("pack://application:,,,/Assets/Profiles/default_profile.png"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
