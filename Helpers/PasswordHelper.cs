using System.Windows;
using System.Windows.Controls;

namespace UBYS_WPF.Helpers
{
    /// <summary>
    /// PasswordBox için iki yönlü veri bağlama (Two-Way Binding) desteği .
    /// </summary>
    public static class PasswordHelper
    {
        /// <summary>
        /// PasswordBox'ın şifre alanını bağlamak için kullanılan Attached Property.
        /// </summary>
        public static readonly DependencyProperty BoundPassword =
            DependencyProperty.RegisterAttached(
                "BoundPassword",
                typeof(string),
                typeof(PasswordHelper),
                new FrameworkPropertyMetadata(string.Empty,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    OnBoundPasswordChanged));

        // ********** Public API ********** //

        public static string GetBoundPassword(DependencyObject obj) =>
            (string)obj.GetValue(BoundPassword);

        public static void SetBoundPassword(DependencyObject obj, string value) =>
            obj.SetValue(BoundPassword, value);

        // ********** Private Methods ********** //

        /// <summary>
        /// BoundPassword değiştiğinde çağrılır, PasswordBox içeriğini günceller.
        /// </summary>
        private static void OnBoundPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PasswordBox passwordBox)
            {
                string newPassword = (string)e.NewValue;

                // Mevcut şifre ile yeni şifre aynı değilse güncelle
                if (passwordBox.Password != newPassword)
                {
                    passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;
                    passwordBox.Password = newPassword;
                    passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
                }
            }
        }

        /// <summary>
        /// PasswordBox içindeki şifre değiştiğinde bağlanan nesneyi günceller.
        /// </summary>
        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                SetBoundPassword(passwordBox, passwordBox.Password);

                // Binding'i manuel olarak güncelle
                passwordBox.GetBindingExpression(BoundPassword)?.UpdateSource();
            }
        }
    }
}
