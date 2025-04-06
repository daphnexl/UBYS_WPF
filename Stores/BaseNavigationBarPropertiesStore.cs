using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBYS_WPF.Stores
{
    public abstract class BaseNavigationBarPropertiesStore
    {
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

        public event Action SelectedNavigationBarMenuChanged;
        public event Action NavigationBarVisibilityChanged;

        protected void OnSelectedMenuChanged() => SelectedNavigationBarMenuChanged?.Invoke();
    }

}
