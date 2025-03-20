using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UBYS_WPF.Stores;
using System.Threading.Tasks;

namespace UBYS_WPF.Services
{

    public class TeacherNavigationBarPropertiesServices
    {
        private readonly TeacherNavigationBarPropertiesStore
        _teacher;

    public TeacherNavigationBarPropertiesServices(TeacherNavigationBarPropertiesStore teacher)
        {
            _teacher = teacher;
        }

        public void ShowBar()
        {
            _teacher.IsNavigationBarVisible = true;
        }

        public void HideBar()
        {
            _teacher.IsNavigationBarVisible = false;
        }
    }
}
