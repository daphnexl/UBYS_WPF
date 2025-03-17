using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UBYS_WPF.Commands;
using UBYS_WPF.Services;
using UBYS_WPF.Stores;

namespace UBYS_WPF.MVVM.ViewModels
{
   public class AdminNavigationBarViewModel : ViewModelBase
    {
        public readonly AdminNavigationBarPropertiesStore _navigationBarPropertiesStore;

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
        public bool IsAddCourseSelected
        {
            get => _navigationBarPropertiesStore.IsAddCourseSelected;
            set
            {
                if (_navigationBarPropertiesStore.IsAddCourseSelected != value)
                {
                    _navigationBarPropertiesStore.IsAddCourseSelected = value;
                    OnPropertyChanged(nameof(IsAddCourseSelected));
                }
            }
        }

        public bool IsTeacherAppointmentSelected
        {
            get => _navigationBarPropertiesStore.IsTeacherAppointmentSelected;
            set
            {
                if (_navigationBarPropertiesStore.IsTeacherAppointmentSelected != value)
                {
                    _navigationBarPropertiesStore.IsTeacherAppointmentSelected = value;
                    OnPropertyChanged(nameof(IsTeacherAppointmentSelected));
                }

            }
        }

        public bool IsCourseSFSelected
        {
            get => _navigationBarPropertiesStore.IsCourseSFSelected;
            set
            {
                if (_navigationBarPropertiesStore.IsCourseSFSelected != value)
                {
                    _navigationBarPropertiesStore.IsCourseSFSelected = value;
                    OnPropertyChanged(nameof(IsCourseSFSelected));
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
        public ICommand NavigateAddCourseCommand { get; }
        public ICommand NavigateCourseSFCommand { get; }
        public ICommand NavigateTeacherAppointmentCommand { get; }
        public ICommand NavigateExitCommand { get; }

        #endregion

        public AdminNavigationBarViewModel(AdminNavigationBarPropertiesStore navigationBarPropertiesStore,
            INavigationService homeNavigationService,
            INavigationService exitNavigationService,
            INavigationService coursesfNavigationService,
            INavigationService teacherappointmentNavigationService,
            INavigationService addcourseNavigationService)
        {
            _navigationBarPropertiesStore = navigationBarPropertiesStore;
            _navigationBarPropertiesStore.NavigationBarVisibilityChanged += _navigationBarPropertiesStore_NavigationBarVisibilityChanged;
            ToggleNavigationBarVisibleCommand = new RelayCommand(_ => ToggleNavigationBarVisibility());
            _navigationBarPropertiesStore.SelectedNavigationBarMenuChanged += NavigationBarPropertiesStore_SelectedNavigationBarMenuChanged;

            NavigateHomeCommand = new NavigateCommand(homeNavigationService);
            NavigateExitCommand = new NavigateCommand(exitNavigationService);
            NavigateTeacherAppointmentCommand = new NavigateCommand(teacherappointmentNavigationService);
            NavigateAddCourseCommand = new NavigateCommand(addcourseNavigationService);
            NavigateCourseSFCommand = new NavigateCommand(coursesfNavigationService);
        }
        private void _navigationBarPropertiesStore_NavigationBarVisibilityChanged()
        {
            OnPropertyChanged(nameof(IsNavigationBarVisible));
        }
        private void NavigationBarPropertiesStore_SelectedNavigationBarMenuChanged()
        {
            OnPropertyChanged(nameof(IsHomeSelected));
            OnPropertyChanged(nameof(IsExitSelected));
            OnPropertyChanged(nameof(IsTeacherAppointmentSelected));
            OnPropertyChanged(nameof(IsCourseSFSelected));
            OnPropertyChanged(nameof(IsAddCourseSelected));

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


