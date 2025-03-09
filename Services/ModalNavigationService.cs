using System;
using UBYS_WPF.Stores;
using UBYS_WPF.MVVM.ViewModels;
using System.Windows.Controls;

namespace UBYS_WPF.Services
{
    public class ModalNavigationService<TViewModel> : INavigationService
          where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public ModalNavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
