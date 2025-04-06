using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBYS_WPF.Stores
{

    public class AdminNavigationBarPropertiesStore : BaseNavigationBarPropertiesStore, INavigationBarPropertiesStore
    {
        private bool _isHomeSelected;
        public bool IsHomeSelected
        {
            get => _isHomeSelected;
            set
            {
                _isHomeSelected = value;
                OnSelectedMenuChanged();
            }
        }

        private bool _isAddCourseSelected;
        public bool IsAddCourseSelected
        {
            get => _isAddCourseSelected;
            set
            {
                _isAddCourseSelected = value;
                OnSelectedMenuChanged();
            }
        }

        private bool _isTeacherAppointmentSelected;
        public bool IsTeacherAppointmentSelected
        {
            get => _isTeacherAppointmentSelected;
            set
            {
                _isTeacherAppointmentSelected = value;
                OnSelectedMenuChanged();
            }
        }

        private bool _isCourseSFSelected;
        public bool IsCourseSFSelected
        {
            get => _isCourseSFSelected;
            set
            {
                _isCourseSFSelected = value;
                OnSelectedMenuChanged();
            }
        }

        private bool _isExitSelected;
        public bool IsExitSelected
        {
            get => _isExitSelected;
            set
            {
                _isExitSelected = value;
                OnSelectedMenuChanged();
            }
        }

        public AdminNavigationBarPropertiesStore()
        {
            IsNavigationBarVisible = false;
            IsHomeSelected = true;
            IsAddCourseSelected = false;
            IsTeacherAppointmentSelected = false;
            IsCourseSFSelected = false;
            IsExitSelected = false;
        }

        // INavigationBarPropertiesStore implementasyonu
        public bool IsNavigationBarVisible { get; set; }
    }

}
