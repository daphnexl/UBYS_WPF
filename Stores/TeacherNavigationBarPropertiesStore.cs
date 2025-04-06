using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBYS_WPF.Stores
{
    public class TeacherNavigationBarPropertiesStore : BaseNavigationBarPropertiesStore, INavigationBarPropertiesStore
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

        private bool _isEditNoteSelected;
        public bool IsEditNoteSelected
        {
            get => _isEditNoteSelected;
            set
            {
                _isEditNoteSelected = value;
                OnSelectedMenuChanged();
            }
        }

        private bool _isStudentsSelected;
        public bool IsStudentsSelected
        {
            get => _isStudentsSelected;
            set
            {
                _isStudentsSelected = value;
                OnSelectedMenuChanged();
            }
        }

        private bool _isMyCoursesSelected;
        public bool IsMyCoursesSelected
        {
            get => _isMyCoursesSelected;
            set
            {
                _isMyCoursesSelected = value;
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

        public TeacherNavigationBarPropertiesStore()
        {
            IsNavigationBarVisible = false;
            IsHomeSelected = true;
            IsEditNoteSelected = false;
            IsStudentsSelected = false;
            IsMyCoursesSelected = false;
            IsExitSelected = false;
        }

        // INavigationBarPropertiesStore implementasyonu
        public bool IsNavigationBarVisible { get; set; }
    }
}
