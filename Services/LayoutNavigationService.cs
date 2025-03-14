using System;
using UBYS_WPF.MVVM.ViewModels;
using UBYS_WPF.Stores;
using System.Windows.Controls;
using UBYS_WPF.Services;

namespace UBYS_WPF.Services
{
    public class LayoutNavigationService<TViewModel> : INavigationService where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;
        private readonly Func<NavigationBarViewModel> _createNavigationBarViewModel;
        private readonly Func<AdminNavigationBarViewModel> _createadminNavigationBarViewModel;
        private readonly Func<TeacherNavigationBarViewModel> _createteacherNavigationBarViewModel;
        private readonly NavigationBarPropertiesStore _navigationBarPropertiesStore;
      


        public LayoutNavigationService(NavigationStore navigationStore,
            Func<TViewModel> createViewModel,
            Func<NavigationBarViewModel> createNavigationBarViewModel,
            Func<TeacherNavigationBarViewModel> createteacherNavigationBarViewModel,
            Func<AdminNavigationBarViewModel> createadminNavigationBarViewModel,
            NavigationBarPropertiesStore navigationBarPropertiesStore)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _createNavigationBarViewModel = createNavigationBarViewModel;
            _createadminNavigationBarViewModel = createadminNavigationBarViewModel;
            _createteacherNavigationBarViewModel = createteacherNavigationBarViewModel;
            _navigationBarPropertiesStore = navigationBarPropertiesStore;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = new LayoutViewModel(_createNavigationBarViewModel(), _createadminNavigationBarViewModel(), _createteacherNavigationBarViewModel(), _createViewModel(), _navigationBarPropertiesStore);
           
        }
    }
}
