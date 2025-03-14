
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UBYS_WPF.Commands;
using UBYS_WPF.MVVM.ViewModels;
using UBYS_WPF.Services;
using UBYS_WPF.Stores;

namespace UBYS_WPF.MVVM.ViewModels
{
    public class TeacherNavigationBarViewModel : ViewModelBase
    {
        public readonly TeacherNavigationBarPropertiesStore _navigationBarPropertiesStore;

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
        public bool IsStudentsSelected
        {
            get => _navigationBarPropertiesStore.IsStudentsSelected;
            set
            {
                if (_navigationBarPropertiesStore.IsStudentsSelected != value)
                {
                    _navigationBarPropertiesStore.IsStudentsSelected = value;
                    OnPropertyChanged(nameof(IsStudentsSelected));
                }
            }
        }

        public bool IsMyCoursesSelected
        {
            get => _navigationBarPropertiesStore.IsMyCoursesSelected;
            set
            {
                if (_navigationBarPropertiesStore.IsMyCoursesSelected != value)
                {
                    _navigationBarPropertiesStore.IsMyCoursesSelected = value;
                    OnPropertyChanged(nameof(IsMyCoursesSelected));
                }

            }
        }

        public bool IsEditNoteSelected
        {
            get => _navigationBarPropertiesStore.IsEditNoteSelected;
            set
            {
                if (_navigationBarPropertiesStore.IsEditNoteSelected != value)
                {
                    _navigationBarPropertiesStore.IsEditNoteSelected = value;
                    OnPropertyChanged(nameof(IsEditNoteSelected));
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
        public ICommand NavigateMyCoursesCommand { get; }
        public ICommand NavigateStudentsCommand { get; }
        public ICommand NavigateEditNoteCommand { get; }

        #endregion

        public TeacherNavigationBarViewModel(TeacherNavigationBarPropertiesStore navigationBarPropertiesStore,
            INavigationService homeNavigationService,
            INavigationService exitNavigationService,
            INavigationService mycoursesNavigationService,
            INavigationService editnoteNavigationService,
            INavigationService studentsNavigationService)

        {
            _navigationBarPropertiesStore = navigationBarPropertiesStore;
            _navigationBarPropertiesStore.NavigationBarVisibilityChanged += _navigationBarPropertiesStore_NavigationBarVisibilityChanged;
            ToggleNavigationBarVisibleCommand = new RelayCommand(_ => ToggleNavigationBarVisibility());
            _navigationBarPropertiesStore.SelectedNavigationBarMenuChanged += NavigationBarPropertiesStore_SelectedNavigationBarMenuChanged;

            NavigateHomeCommand = new NavigateCommand(homeNavigationService);
            NavigateExitCommand = new NavigateCommand(exitNavigationService);
            NavigateMyCoursesCommand = new NavigateCommand(mycoursesNavigationService);
            NavigateEditNoteCommand = new NavigateCommand(editnoteNavigationService);
            NavigateStudentsCommand = new NavigateCommand(studentsNavigationService);
          

        }

        private void _navigationBarPropertiesStore_NavigationBarVisibilityChanged()
        {
            OnPropertyChanged(nameof(IsNavigationBarVisible));
        }

        private void NavigationBarPropertiesStore_SelectedNavigationBarMenuChanged()
        {
            OnPropertyChanged(nameof(IsHomeSelected));
            OnPropertyChanged(nameof(IsExitSelected));
            OnPropertyChanged(nameof(IsMyCoursesSelected));
            OnPropertyChanged(nameof(IsEditNoteSelected));
            OnPropertyChanged(nameof(IsStudentsSelected));

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
