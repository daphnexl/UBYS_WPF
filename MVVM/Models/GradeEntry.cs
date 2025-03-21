﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBYS_WPF.MVVM.Models;

namespace UBYS_WPF.MVVM.Models
{
    public class GradeEntry
    {
        public string CourseName { get; set; }
        public string Grade { get; set; }
        public string TeacherName { get; set; }
        public string DateReceived { get; set; }
    }
}
