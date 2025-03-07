using System;
using UBYS_WPF.Cores;
using UBYS_WPF.Stores;
using UBYS_WPF.MVVM.ViewModels;
using System.Windows.Controls;

namespace UBYS_WPF.Services
{
    public class ModalNavigationService<TViewModel> : INavigationService
          where TViewModel : ViewModelBase
    {
        private readonly ModalNavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public ModalNavigationService(ModalNavigationStore navigationStore, Func<TViewModel> createViewModel)
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
