using System;
using UBYS_WPF.MVVM.ViewModels;
using UBYS_WPF.Stores;
using System.Windows.Controls;
using UBYS_WPF.Services;

namespace UBYS_WPF.Services
{
    public class LayoutNavigationService<TViewModel> : INavigationService where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;
        private readonly Func<NavigationBarViewModel> _createNavigationBarViewModel;
        private readonly NavigationBarPropertiesStore _navigationBarPropertiesStore;
        private readonly NavigationMonitorStore _navigationMonitorStore;


        public LayoutNavigationService(NavigationStore navigationStore,
            Func<TViewModel> createViewModel,
            Func<NavigationBarViewModel> createNavigationBarViewModel,
            NavigationBarPropertiesStore navigationBarPropertiesStore)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _createNavigationBarViewModel = createNavigationBarViewModel;
            _navigationBarPropertiesStore = navigationBarPropertiesStore;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = new LayoutViewModel(_createNavigationBarViewModel(), _createViewModel(), _navigationBarPropertiesStore);
            _navigationMonitorStore.CurrentViewModel = _createViewModel();
        }
    }
}
