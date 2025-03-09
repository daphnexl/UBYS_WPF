using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBYS_WPF.Components;
using UBYS_WPF.MVVM.ViewModels;
using UBYS_WPF.Stores;

namespace UBYS_WPF.Services
{
    public class DistinctNavigationService<TViewModel> : INavigationService where TViewModel : ViewModelBase
    {
        private readonly NavigationMonitorStore _navigationMonitorStore;
        private readonly NavigationStore _navigationTouchScreenStore;
        private readonly Func<TViewModel> _createTSWViewModel;
        private readonly Func<TViewModel> _createMWViewModel;
        private readonly Func<NavigationBarViewModel> _createNavigationBarViewModel;
        private readonly NavigationBarPropertiesStore _navigationBarPropertiesStore;

        public DistinctNavigationService(NavigationMonitorStore navigationMonitorStore,
            NavigationStore navigationTouchScreenStore,
            Func<TViewModel> createTSWViewModel,
            Func<TViewModel> createMWViewModel,
            Func<NavigationBarViewModel> createNavigationBarViewModel,
            NavigationBarPropertiesStore navigationBarPropertiesStore)
        {
            _navigationMonitorStore = navigationMonitorStore;
            _navigationTouchScreenStore = navigationTouchScreenStore;
            _createTSWViewModel = createTSWViewModel;
            _createMWViewModel = createMWViewModel;
            _createNavigationBarViewModel = createNavigationBarViewModel;
            _navigationBarPropertiesStore = navigationBarPropertiesStore;
        }
        public void Navigate()
        {
            _navigationTouchScreenStore.CurrentViewModel = new LayoutViewModel(_createNavigationBarViewModel(), _createTSWViewModel(), _navigationBarPropertiesStore);
            _navigationMonitorStore.CurrentViewModel = _createMWViewModel();
        }
    }
}
