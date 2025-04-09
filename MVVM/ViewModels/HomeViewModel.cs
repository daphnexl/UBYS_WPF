using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UBYS_WPF.Commands;
using UBYS_WPF.Services;
using System.Threading.Tasks;

using UBYS_WPF.MVVM.Models;
using System.Windows.Input;

namespace UBYS_WPF.MVVM.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private User _user;

        public User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }
      /*  private string _data;
        public string Data
        {
            get => _data;
            set
            {
                _data = value;
                OnPropertyChanged(nameof(Data));
            }
        }*/
        public ICommand NavigateHomeCommand { get; }
      
        public HomeViewModel(INavigationService homeNavigationService,User user)
        {
            NavigateHomeCommand = new NavigateCommand(homeNavigationService);
            User = user;
        }
    }

}
