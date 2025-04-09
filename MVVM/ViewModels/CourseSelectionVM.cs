using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using UBYS_WPF.MVVM.Models;
using UBYS_WPF.MVVM.ViewModels;

    public class CourseSelectionViewModel : ViewModelBase
    {
        private ObservableCollection<Course> _availableCourses;
        public ObservableCollection<Course> AvailableCourses
        {
            get => _availableCourses;
            set
            {
                _availableCourses = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Course> _selectedCourses;
        public ObservableCollection<Course> SelectedCourses
        {
            get => _selectedCourses;
            set
            {
                _selectedCourses = value;
                OnPropertyChanged();
            }
        }

        public ICommand ToggleCourseCommand { get; set; }
        public ICommand RemoveCourseCommand { get; set; }

        public CourseSelectionViewModel()
        {
            AvailableCourses = new ObservableCollection<Course>();
            SelectedCourses = new ObservableCollection<Course>();

            // Admin ya da öğretmen dinamik olarak değiştirebilir
            AvailableCourses.Add(new Course { Name = "Matematik I" });
            AvailableCourses.Add(new Course { Name = "Algoritma" });
            AvailableCourses.Add(new Course { Name = "Fizik I" });

            ToggleCourseCommand = new RelayCommand<Course>(ToggleCourse);
            RemoveCourseCommand = new RelayCommand<Course>(RemoveCourse);
        }

        private void ToggleCourse(Course course)
        {
            if (course == null) return;

            if (!SelectedCourses.Contains(course))
                SelectedCourses.Add(course);
        }

        private void RemoveCourse(Course course)
        {
            if (course == null) return;

            if (SelectedCourses.Contains(course))
                SelectedCourses.Remove(course);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
