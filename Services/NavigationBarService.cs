using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBYS_WPF.Stores;

namespace UBYS_WPF.Services
{
    public class NavigationBarService
    {
        public void ShowBar(INavigationBarPropertiesStore navigationBar)
        {
            navigationBar.IsNavigationBarVisible = true;
        }

        public void HideBar(INavigationBarPropertiesStore navigationBar)
        {
            navigationBar.IsNavigationBarVisible = false;
        }
    }

}
