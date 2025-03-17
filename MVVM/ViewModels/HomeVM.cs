using System.Windows.Input;
using UBYS_WPF.Commands;
using UBYS_WPF.Services;

namespace UBYS_WPF.MVVM.ViewModels
{
    public class HomeVM : ViewModelBase
    {
        private string _data;
        public string Data
        {
            get => _data;
            set
            {
                _data = value;
                OnPropertyChanged(nameof(Data));
            }
        }
        public ICommand NavigateHomeCommand { get; }
        public HomeVM(INavigationService homeNavigationService)
        {
            Data = "Home Page";
            NavigateHomeCommand = new NavigateCommand(homeNavigationService);
        }
    }
}
