using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBYS_WPF.Stores;

namespace UBYS_WPF.Services
{
   
        public class AdminNavigationBarProServices
    {
            private readonly AdminNavigationBarPropertiesStore _admin;

        public AdminNavigationBarProServices(AdminNavigationBarPropertiesStore admin)
            {
                _admin = admin;
            }

            public void ShowBar()
            {
                _admin.IsNavigationBarVisible = true;
            }

            public void HideBar()
            {
                _admin.IsNavigationBarVisible = false;
            }
        }

    }
