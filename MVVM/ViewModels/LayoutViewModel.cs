using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UBYS_WPF.Commands;
using UBYS_WPF.Components;
using UBYS_WPF.Stores;

namespace UBYS_WPF.MVVM.ViewModels
{
    public class LayoutViewModel : ViewModelBase
    {
        public NavigationBarViewModel NavigationBarViewModel { get; }
        public ViewModelBase ContentViewModel { get; }

        public readonly NavigationBarPropertiesStore _navigationBarPropertiesStore;

        public ICommand ToggleNavigationBarVisibleCommand { get; }

        public LayoutViewModel(NavigationBarViewModel navigationBarVM,
            ViewModelBase contentViewModel,
            NavigationBarPropertiesStore navigationBarPropertiesStore)
        {
            NavigationBarViewModel = navigationBarVM;
            ContentViewModel = contentViewModel;

            _navigationBarPropertiesStore = navigationBarPropertiesStore;
            _navigationBarPropertiesStore.NavigationBarVisibilityChanged += _navigationBarPropertiesStore_NavigationBarVisibilityChanged;
            ToggleNavigationBarVisibleCommand = new RelayCommand(_ => ToggleNavigationBarVisibility());
        }

        private void _navigationBarPropertiesStore_NavigationBarVisibilityChanged()
        {
            OnPropertyChanged(nameof(_navigationBarPropertiesStore.IsNavigationBarVisible));
        }

        private void ToggleNavigationBarVisibility()
        {
            _navigationBarPropertiesStore.IsNavigationBarVisible = !_navigationBarPropertiesStore.IsNavigationBarVisible;
        }

        public override void Dispose()
        {
            NavigationBarViewModel.Dispose();
            ContentViewModel.Dispose();
            base.Dispose();
        }
    }
}