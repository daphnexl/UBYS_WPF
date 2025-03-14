using UBYS_WPF.Components;
using UBYS_WPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UBYS_WPF.Commands;
using UBYS_WPF.MVVM.ViewModels;
using UBYS_WPF.Services;

namespace UBYS_WPF.MVVM.ViewModels
{
    public class HomeVM : ViewModelBase
    {
        private string _data;
        public string Data
        {
            get { return _data; }
            set
            {
                _data = value;
                OnPropertyChanged(nameof(Data));
            }
        }

        public ICommand NavigateHomeCommand { get; }

        public HomeVM(INavigationService HomeNavigationService)
        {
            Data = "Home Page";

            NavigateHomeCommand = new RelayCommand(_ => ExecuteNavigateHomeCommand(HomeNavigationService));
        }

        private void ExecuteNavigateHomeCommand(INavigationService viewModel)
        {
            new NavigateCommand(viewModel).Execute(null);
        }
    }
}
