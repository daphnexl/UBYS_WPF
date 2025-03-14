﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBYS_WPF.Stores
{
    public class AdminNavigationBarPropertiesStore
    {
        #region NavigationBarMenuVisibility Property
        private bool _isNavigationBarVisible;
        public bool IsNavigationBarVisible
        {
            get => _isNavigationBarVisible;
            set
            {
                _isNavigationBarVisible = value;
                NavigationBarVisibilityChanged?.Invoke();
            }
        }
        #endregion

        #region NavigationBarMenuSelected Properties
        private bool _isHomeSelected;
        public bool IsHomeSelected
        {
            get => _isHomeSelected;
            set
            {
                _isHomeSelected = value;
                SelectedNavigationBarMenuChanged?.Invoke();
            }
        }

        private bool _isAddCourseSelected;
        public bool IsAddCourseSelected
        {
            get => _isAddCourseSelected;
            set
            {
                _isAddCourseSelected = value;
                SelectedNavigationBarMenuChanged?.Invoke();
            }
        }

        private bool _isTeacherAppointmentSelected;
        public bool IsTeacherAppointmentSelected
        {
            get => _isTeacherAppointmentSelected;
            set
            {
                _isTeacherAppointmentSelected = value;
                SelectedNavigationBarMenuChanged?.Invoke();
            }
        }
        private bool _isCourseSFSelected;
        public bool IsCourseSFSelected
        {
            get => _isCourseSFSelected;
            set
            {
                _isCourseSFSelected = value;
                SelectedNavigationBarMenuChanged?.Invoke();
            }
        }

        private bool _isExitSelected;
        public bool IsExitSelected
        {
            get => _isExitSelected;
            set
            {
                _isExitSelected = value;
                SelectedNavigationBarMenuChanged?.Invoke();
            }
        }


        #endregion

        #region Actions
        public event Action SelectedNavigationBarMenuChanged;
        public event Action NavigationBarVisibilityChanged;
        #endregion

        #region Constructor
        public AdminNavigationBarPropertiesStore()
        {
            // Varsayılan başlangıç değerleri
            _isNavigationBarVisible = false;
            _isHomeSelected = true;
            _isTeacherAppointmentSelected = false;
            _isExitSelected = false;
            _isCourseSFSelected = false;
            _isAddCourseSelected = false;

        }
        #endregion
    }
}
