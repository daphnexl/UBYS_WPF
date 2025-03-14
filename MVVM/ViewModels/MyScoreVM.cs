using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class MyScoreViewModel : INotifyPropertyChanged
{
    public ObservableCollection<GradeEntry> Grades { get; set; }

    public MyScoreViewModel()
    {
        Grades = new ObservableCollection<GradeEntry>
            {
                new GradeEntry { CourseName = "Mathematics", Grade = "A", TeacherName = "Dr. AAA", DateReceived = DateTime.Now.ToShortDateString() },
                new GradeEntry { CourseName = "Algorithm", Grade = "B", TeacherName = "Prof. BBB", DateReceived = DateTime.Now.ToShortDateString() }
            };
    }

    public void AddGrade(string course, string grade, string teacher)
    {
        Grades.Add(new GradeEntry { CourseName = course, Grade = grade, TeacherName = teacher, DateReceived = DateTime.Now.ToShortDateString() });
        OnPropertyChanged(nameof(Grades));
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
public class GradeEntry
{
    public string CourseName { get; set; }
    public string Grade { get; set; }
    public string TeacherName { get; set; }
    public string DateReceived { get; set; }
}