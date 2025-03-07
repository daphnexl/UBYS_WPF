using System;
using System.Windows.Controls;
using UBYS_WPF.Stores;

namespace UBYS_WPF.Services
{
    public class CloseModalNavigationService : INavigationService
    {
        private readonly ModalNavigationStore _navigationStore;

        public CloseModalNavigationService(ModalNavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public void Navigate(UserControl view)
        {
            _navigationStore.Close();
        }
    }
}
