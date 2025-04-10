﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using UBYS_WPF.MVVM.Models;

namespace UBYS_WPF.MVVM.ViewModels
{
    public class MyScoreVM : ViewModelBase
    {
        public ObservableCollection<GradeEntry> Grades { get; set; }

        public MyScoreVM()
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
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
