using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UBYS_WPF.Stores;
using System.Threading.Tasks;

namespace UBYS_WPF.Services
{

    public class NavigationBarPropertiesServices
    {
        private readonly NavigationBarPropertiesStore
        _student;

        public NavigationBarPropertiesServices(NavigationBarPropertiesStore student)
        {
            _student = student;
        }

        public void ShowBar()
        {
            _student.IsNavigationBarVisible = true;
        }

        public void HideBar()
        {
            _student.IsNavigationBarVisible = false;
        }
    }
}
