using System;
using System.Windows.Controls;
using UBYS_WPF.Cores;
using UBYS_WPF.Stores;
using UBYS_WPF.MVVM.ViewModels;

namespace UBYS_WPF.Services
{
    public class ParameterNavigationService<TViewModel> : INavigationService where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public ParameterNavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate(UserControl view)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
