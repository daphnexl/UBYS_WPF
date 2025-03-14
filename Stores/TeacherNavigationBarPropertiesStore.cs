using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBYS_WPF.Stores
{
    public class TeacherNavigationBarPropertiesStore
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

        private bool _isEditNoteSelected;
        public bool IsEditNoteSelected
        {
            get => _isEditNoteSelected;
            set
            {
                _isEditNoteSelected = value;
                SelectedNavigationBarMenuChanged?.Invoke();
            }
        }

        private bool _isStudentsSelected;
        public bool IsStudentsSelected
        {
            get => _isStudentsSelected;
            set
            {
                _isStudentsSelected = value;
                SelectedNavigationBarMenuChanged?.Invoke();
            }
        }
        private bool _isMyCoursesSelected;
        public bool IsMyCoursesSelected
        {
            get => _isMyCoursesSelected;
            set
            {
                _isMyCoursesSelected = value;
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
        public TeacherNavigationBarPropertiesStore()
        {
            // Varsayılan başlangıç değerleri
            _isNavigationBarVisible = false;
            _isHomeSelected = true;
            _isEditNoteSelected = false;
            _isExitSelected = false;
            _isMyCoursesSelected = false;
            _isStudentsSelected = false;

        }
        #endregion
    }
}
