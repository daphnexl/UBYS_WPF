using System.Windows;
using System.Windows.Controls;

namespace UBYS_WPF.Helpers
{
    public static class PasswordHelper
    {
        public static readonly DependencyProperty BoundPasswordProperty =
            DependencyProperty.RegisterAttached(
                "BoundPassword",
                typeof(string),
                typeof(PasswordHelper),
                new PropertyMetadata(string.Empty, OnBoundPasswordChanged)
            );

        public static string GetBoundPassword(DependencyObject obj)
            => (string)obj.GetValue(BoundPasswordProperty);

        public static void SetBoundPassword(DependencyObject obj, string value)
            => obj.SetValue(BoundPasswordProperty, value);

        private static void OnBoundPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PasswordBox passwordBox)
            {
                passwordBox.PasswordChanged -= PasswordChangedHandler;
                passwordBox.Password = (string)e.NewValue;
                passwordBox.PasswordChanged += PasswordChangedHandler;
            }
        }

        private static void PasswordChangedHandler(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
                SetBoundPassword(passwordBox, passwordBox.Password);
        }
    }

}
