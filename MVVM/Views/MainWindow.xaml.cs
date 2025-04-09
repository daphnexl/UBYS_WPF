using System.Windows;

namespace CourseSelection
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Ders Seçimi Butonuna Tıklama Olayı
        private void DersSecimiButton_Click(object sender, RoutedEventArgs e)
        {
            // CourseSelection sayfasını MainFrame'e yükle
            MainFrame.Content = new MVVM.Views.CourseSelection();
        }
    }
}
