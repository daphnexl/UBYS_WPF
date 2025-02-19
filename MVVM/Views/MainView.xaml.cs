using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace UBYS_WPF.MVVM.Views
{
    public partial class MainView : Window
    {
        private bool isDefaultText = true; // Flag to track if placeholder is active

        public MainView()
        {
            InitializeComponent();
        }
    }
}
