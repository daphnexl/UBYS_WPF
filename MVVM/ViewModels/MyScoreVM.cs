using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace UBYS_WPF.MVVM.ViewModels
{
    public class MyScoreViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<GradeEntry> Grade { get; set; }

        public MyScoreViewModel()
        {
            Grade = new ObservableCollection<GradeEntry>
            {
                new GradeEntry { CourseName = "Mathematics", Grades = "A", TeacherName = "Dr. AAA", DateReceived = DateTime.Now.ToShortDateString() },
                new GradeEntry { CourseName = "Algorithm", Grades = "B", TeacherName = "Prof. BBB", DateReceived = DateTime.Now.ToShortDateString() }
            };
        }

        public void AddGrade(string course, string grade, string teacher)
        {
            Grade.Add(new GradeEntry { CourseName = course, Grades = grade, TeacherName = teacher, DateReceived = DateTime.Now.ToShortDateString() });
            OnPropertyChanged(nameof(Grade));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
