using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBYS_WPF.Stores;
using UBYS_WPF.Helpers;

namespace UBYS_WPF.Commands
{
    public class LogoutCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            // Kullanıcının oturumunu kapat
            DatabaseHelper.LogoutUser();
        }
    }
}
