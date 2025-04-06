using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBYS_WPF.Stores
{
    public class NavigationBarPropertiesStore : BaseNavigationBarPropertiesStore, INavigationBarPropertiesStore
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

        private bool _isMyScoreSelected;
        public bool IsMyScoreSelected
        {
            get => _isMyScoreSelected;
            set
            {
                _isMyScoreSelected = value;
                OnSelectedMenuChanged();
            }
        }

        private bool _isCourseSelectionSelected;
        public bool IsCourseSelectionSelected
        {
            get => _isCourseSelectionSelected;
            set
            {
                _isCourseSelectionSelected = value;
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

        public NavigationBarPropertiesStore()
        {
            IsNavigationBarVisible = false;
            IsHomeSelected = true;
            IsMyScoreSelected = false;
            IsCourseSelectionSelected = false;
            IsExitSelected = false;
        }

        // INavigationBarPropertiesStore implementasyonu
        public bool IsNavigationBarVisible { get; set; }
    }
}
