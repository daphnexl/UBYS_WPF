using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBYS_WPF.Stores;
using UBYS_WPF.Helpers;
using UBYS_WPF.Services;

namespace UBYS_WPF.Commands
{

    public class LogoutCommand : CommandBase
    {
        private readonly INavigationService _navigationService;

        public LogoutCommand(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            // Kullanıcı verilerini temizle (varsa)
            // örn: UserSessionStore.CurrentUser = null;

            _navigationService.Navigate();
        }
    }

}

