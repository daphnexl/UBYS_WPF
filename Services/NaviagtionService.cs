using System;
using System.Windows.Controls;
using UBYS_WPF.Stores;

namespace UBYS_WPF.Services
{
    public class NavigationService : INavigationService
    {
        private readonly NavigationStore _navigationStore;

        public NavigationService(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public void Navigate(UserControl view)
        {
            _navigationStore.CurrentView = view;
        }
    }
}
