using System.Windows.Input;
using UBYS_WPF.Commands;
using System.ComponentModel;
using UBYS_WPF.Helpers;
using UBYS_WPF.MVVM.Models;
using UBYS_WPF.Services;
using System.Windows.Controls;
using UBYS_WPF.MVVM.Views;
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
        //NavigationBarMenuSelectedStore is a class that stores the selected navigation bar menu

        public bool IsLogoutSelected
        {
            get => _navigationBarPropertiesStore.IsLogoutSelected;
            set
            {
                if (_navigationBarPropertiesStore.IsLogoutSelected != value)
                {
                    _navigationBarPropertiesStore.IsLogoutSelected = value;
                    OnPropertyChanged(nameof(IsLogoutSelected));
                }
            }
        }

   

        public bool IsLessonsSelected
        {
            get => _navigationBarPropertiesStore.IsLessonsSelected;
            set
            {
                if (_navigationBarPropertiesStore.IsLessonsSelected != value)
                {
                    _navigationBarPropertiesStore.IsLessonsSelected = value;
                    OnPropertyChanged(nameof(IsLessonsSelected));
                }

            }
        }

        public bool IsNotesSelected
        {
            get => _navigationBarPropertiesStore.IsNotesSelected;
            set
            {
                if (_navigationBarPropertiesStore.IsNotesSelected != value)
                {
                    _navigationBarPropertiesStore.IsNotesSelected = value;
                    OnPropertyChanged(nameof(IsNotesSelected));
                }

            }
        }
        #endregion

        #region Navigation Commands
        public ICommand NavigateNotesCommand { get; }
        public ICommand NavigateLessonsCommand { get; }
        public ICommand LogoutCommand { get; }
        #endregion

        public NavigationBarViewModel(NavigationBarPropertiesStore navigationBarPropertiesStore,
            INavigationService notesNavigationService,
            INavigationService lessonsNavigationService,
            INavigationService logoutNavigationService)
        {
            _navigationBarPropertiesStore = navigationBarPropertiesStore;
            _navigationBarPropertiesStore.NavigationBarVisibilityChanged += _navigationBarPropertiesStore_NavigationBarVisibilityChanged;
            ToggleNavigationBarVisibleCommand = new RelayCommand(_ => ToggleNavigationBarVisibility());
            _navigationBarPropertiesStore.SelectedNavigationBarMenuChanged += NavigationBarPropertiesStore_SelectedNavigationBarMenuChanged;

            NavigateNotesCommand = new NavigateCommand(notesNavigationService);
            NavigateLessonsCommand = new NavigateCommand(lessonsNavigationService);
            LogoutCommand = new NavigateCommand(logoutNavigationService);
        }

        private void _navigationBarPropertiesStore_NavigationBarVisibilityChanged()
        {
            OnPropertyChanged(nameof(IsNavigationBarVisible));
        }

        private void NavigationBarPropertiesStore_SelectedNavigationBarMenuChanged()
        {
            OnPropertyChanged(nameof(IsNotesSelected));
            OnPropertyChanged(nameof(IsLessonsSelected));
            OnPropertyChanged(nameof(IsLogoutSelected));
          
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
