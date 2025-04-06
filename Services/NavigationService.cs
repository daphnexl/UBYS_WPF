using System;
using UBYS_WPF.MVVM.ViewModels;
using UBYS_WPF.MVVM.Models;

namespace UBYS_WPF.Services
{
    public class NavigationService<TViewModel> : INavigationService
        where TViewModel : ViewModelBase
    {
        private readonly Func<TViewModel> _createViewModel;
        private readonly Action<ViewModelBase> _navigateAction;

        public NavigationService(Func<TViewModel> createViewModel, Action<ViewModelBase> navigateAction)
        {
            _createViewModel = createViewModel;
            _navigateAction = navigateAction;
        }

        public void Navigate()
        {
            var viewModel = _createViewModel();
            _navigateAction(viewModel);
        }

        public void NavigateToRoleBasedView(User user)
        {
            // Kullanıcı rolüne göre uygun ViewModel'yi yönlendirin
            switch (user.Role)
            {
                case Role.Admin:
                    NavigateToAdminView();
                    break;
                case Role.Teacher:
                    NavigateToTeacherView();
                    break;
                case Role.Student:
                    NavigateToStudentView();
                    break;
                default:
                    throw new InvalidOperationException("Unknown role");
            }
        }

        private void NavigateToAdminView()
        {
            var adminViewModel = _createViewModel();
            _navigateAction(adminViewModel);
        }

        private void NavigateToTeacherView()
        {
            var teacherViewModel = _createViewModel();
            _navigateAction(teacherViewModel);
        }

        private void NavigateToStudentView()
        {
            var studentViewModel = _createViewModel();
            _navigateAction(studentViewModel);
        }
    }
}
