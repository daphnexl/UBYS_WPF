﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBYS_WPF.Stores
{
    public class NavigationBarPropertiesStore
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

        private bool _isMyScoreSelected;
        public bool IsMyScoreSelected
        {
            get => _isMyScoreSelected;
            set
            {
                _isMyScoreSelected = value;
                SelectedNavigationBarMenuChanged?.Invoke();
            }
        }

        private bool _isCourseSelectionSelected;
        public bool IsCourseSelectionSelected
        {
            get => _isCourseSelectionSelected;
            set
            {
                _isCourseSelectionSelected = value;
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
        public NavigationBarPropertiesStore()
        {
            // Varsayılan başlangıç değerleri
            _isNavigationBarVisible = false;
            _isHomeSelected = true;
            _isMyScoreSelected = false;
            _isExitSelected = false;
            _isCourseSelectionSelected = false;
          
        }
        #endregion
    }
}
