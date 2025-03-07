using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBYS_WPF.Cores;

namespace UBYS_WPF.MVVM.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        internal string FullName;
        private string _username;
        private string _password;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
     
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
    }
}