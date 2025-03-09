using System;
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

        private bool _isConnectSelected;
        public bool IsConnectSelected
        {
            get => _isConnectSelected;
            set
            {
                _isConnectSelected = value;
                SelectedNavigationBarMenuChanged?.Invoke();
            }
        }

        private bool _isScanSelected;
        public bool IsScanSelected
        {
            get => _isScanSelected;
            set
            {
                _isScanSelected = value;
                SelectedNavigationBarMenuChanged?.Invoke();
            }
        }

        private bool _isTestSelected;
        public bool IsTestSelected
        {
            get => _isTestSelected;
            set
            {
                _isTestSelected = value;
                SelectedNavigationBarMenuChanged?.Invoke();
            }
        }

        private bool _isImagingSelected;
        public bool IsImagingSelected
        {
            get => _isImagingSelected;
            set
            {
                _isImagingSelected = value;
                SelectedNavigationBarMenuChanged?.Invoke();
            }
        }

        public bool IsLogoutSelected { get; internal set; }
        public bool IsLessonsSelected { get; internal set; }
        public bool IsNotesSelected { get; internal set; }
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
            _isConnectSelected = false;
            _isScanSelected = false;
            _isTestSelected = false;
            _isImagingSelected = false;
        }
        #endregion
    }
}
