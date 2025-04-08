using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using UBYS_WPF.MVVM.Models;
using UBYS_WPF.MVVM.ViewModels;
public class CourseSelectionViewModel
{
    public ObservableCollection<Course> AvailableCourses { get; set; } = new ObservableCollection<Course>();
    public ObservableCollection<Course> SelectedCourses { get; set; } = new ObservableCollection<Course>();

    public ICommand ToggleCourseCommand { get; set; }
    public ICommand RemoveCourseCommand { get; set; }

    public CourseSelectionViewModel()
    {
        // Admin ya da öğretmen dinamik olarak değiştirebilir
        AvailableCourses.Add(new Course { Name = "Matematik I" });
        AvailableCourses.Add(new Course { Name = "Algoritma" });
        AvailableCourses.Add(new Course { Name = "Fizik I" });

        ToggleCourseCommand = new RelayCommand<Course>(ToggleCourse);
        RemoveCourseCommand = new RelayCommand<Course>(RemoveCourse);
    }

    private void ToggleCourse(Course course)
    {
        if (!SelectedCourses.Contains(course))
            SelectedCourses.Add(course);
    }

    private void RemoveCourse(Course course)
    {
        if (SelectedCourses.Contains(course))
            SelectedCourses.Remove(course);
    }

    public event PropertyChangedEventHandler PropertyChanged;
}
