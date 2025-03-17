using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Windows.Input;
using UBYS_WPF.Commands;
using UBYS_WPF.MVVM.ViewModels;
using UBYS_WPF.Services;
using UBYS_WPF.Stores;

namespace UBYS_WPF.MVVM.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        public readonly NavigationBarPropertiesStore _navigationBarPropertiesStore;

        #region NavigationBarVisibility Command
        public bool IsNavigationBarVisible
        {
            get => _navigationBarPropertiesStore.IsNavigationBarVisible;
            set
            {
                if (_navigationBarPropertiesStore.IsNavigationBarVisible != value) //Bu kontrol yapılmazsa değer değişmemiş olsa bile UI güncellenir.
                {
                    _navigationBarPropertiesStore.IsNavigationBarVisible = value;
                    OnPropertyChanged(nameof(IsNavigationBarVisible));
                }
            }
        }
        public ICommand ToggleNavigationBarVisibleCommand { get; }
        #endregion

        #region NavigationBarMenuSelectedStore Properties
        public bool IsHomeSelected
        {
            get => _navigationBarPropertiesStore.IsHomeSelected;
            set
            {
                if (_navigationBarPropertiesStore.IsHomeSelected != value)
                {
                    _navigationBarPropertiesStore.IsHomeSelected = value;
                    OnPropertyChanged(nameof(IsHomeSelected));
                }
            }
        }
        public bool IsMyScoreSelected
        {
            get => _navigationBarPropertiesStore.IsMyScoreSelected;
            set
            {
                if (_navigationBarPropertiesStore.IsMyScoreSelected != value)
                {
                    _navigationBarPropertiesStore.IsMyScoreSelected = value;
                    OnPropertyChanged(nameof(IsMyScoreSelected));
                }
            }
        }
        public bool IsCourseSelectionSelected
        {
            get => _navigationBarPropertiesStore.IsCourseSelectionSelected;
            set
            {
                if (_navigationBarPropertiesStore.IsCourseSelectionSelected != value)
                {
                    _navigationBarPropertiesStore.IsCourseSelectionSelected = value;
                    OnPropertyChanged(nameof(IsCourseSelectionSelected));
                }
            }
        }
        public bool IsExitSelected
        {
            get => _navigationBarPropertiesStore.IsExitSelected;
            set
            {
                if (_navigationBarPropertiesStore.IsExitSelected != value)
                {
                    _navigationBarPropertiesStore.IsExitSelected = value;
                    OnPropertyChanged(nameof(IsExitSelected));
                }
            }
        }
        #endregion
        #region Navigation Commands
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateExitCommand { get; }
        public ICommand NavigateCourseSelectionCommand { get; }
        public ICommand NavigateMyScoreCommand { get; }
        #endregion
        public NavigationBarViewModel(NavigationBarPropertiesStore navigationBarPropertiesStore,
            INavigationService homeNavigationService,
            INavigationService exitNavigationService,
            INavigationService myscoreNavigationService,
            INavigationService courseselectionNavigationService)
        {
            _navigationBarPropertiesStore = navigationBarPropertiesStore;
            _navigationBarPropertiesStore.NavigationBarVisibilityChanged += _navigationBarPropertiesStore_NavigationBarVisibilityChanged;
            ToggleNavigationBarVisibleCommand = new RelayCommand(_ => ToggleNavigationBarVisibility());
            _navigationBarPropertiesStore.SelectedNavigationBarMenuChanged += NavigationBarPropertiesStore_SelectedNavigationBarMenuChanged;

            NavigateHomeCommand = new NavigateCommand(homeNavigationService);
            NavigateExitCommand = new NavigateCommand(exitNavigationService);
            NavigateCourseSelectionCommand = new NavigateCommand(courseselectionNavigationService);
            NavigateMyScoreCommand = new NavigateCommand(myscoreNavigationService);
        }
        private void _navigationBarPropertiesStore_NavigationBarVisibilityChanged()
        {
            OnPropertyChanged(nameof(IsNavigationBarVisible));
        }
        private void NavigationBarPropertiesStore_SelectedNavigationBarMenuChanged()
        {
            OnPropertyChanged(nameof(IsHomeSelected));
            OnPropertyChanged(nameof(IsExitSelected));
            OnPropertyChanged(nameof(IsCourseSelectionSelected));
            OnPropertyChanged(nameof(IsMyScoreSelected));
        }
        private void ToggleNavigationBarVisibility()
        {
            _navigationBarPropertiesStore.IsNavigationBarVisible = !_navigationBarPropertiesStore.IsNavigationBarVisible;
        }
        public override void Dispose()
        {
            _navigationBarPropertiesStore.SelectedNavigationBarMenuChanged -= NavigationBarPropertiesStore_SelectedNavigationBarMenuChanged;
            base.Dispose();
        }
    }
}
