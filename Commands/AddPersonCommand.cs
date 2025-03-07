using UBYS_WPF.MVVM.ViewModels;
using UBYS_WPF.Services;
using UBYS_WPF.Stores;
using System.Windows.Controls;

namespace UBYS_WPF.Commands
{
    public class AddPersonCommand : CommandBase
    {
        private readonly AddPersonViewModel _addPersonViewModel;
        private readonly PeopleStore _peopleStore;
        private readonly INavigationService _navigationService;

        public AddPersonCommand(AddPersonViewModel addPersonViewModel, PeopleStore peopleStore, INavigationService navigationService)
        {
            _addPersonViewModel = addPersonViewModel;
            _peopleStore = peopleStore;
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            string name = _addPersonViewModel.Name;
            _peopleStore.AddPerson(name);
            // Navigate metoduna parametre olarak bir UserControl vermeniz gerekiyor.
            // Hangi UserControl'e gitmek istediğinizi burada belirtin.
            // Örnek: _navigationService.Navigate(new PeopleView());
            // Eğer bir PeopleView'iniz yoksa veya farklı bir yere gitmek istiyorsanız, ilgili UserControl'ü oluşturun ve buraya ekleyin.
            _navigationService.Navigate(new UserControl()); // Geçici çözüm, gerçek UserControl'ü belirtin.
        }
    }
}
