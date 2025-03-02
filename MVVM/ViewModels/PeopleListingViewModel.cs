using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UBYS_WPF.Commands;
using UBYS_WPF.Services;
using UBYS_WPF.Stores;

namespace UBYS_WPF.MVVM.ViewModels
{
    public class PeopleListingViewModel : ViewModelBase
    {
        private readonly PeopleStore _peopleStore;

        private readonly ObservableCollection<PersonViewModel> _people;

        public IEnumerable<PersonViewModel> People => _people;

        public ICommand AddPersonCommand { get; }

        public PeopleListingViewModel(PeopleStore peopleStore, INavigationService addPersonNavigationService)
        {
            _peopleStore = peopleStore;

            AddPersonCommand = new NavigateCommand(addPersonNavigationService);
            _people = new ObservableCollection<PersonViewModel>();

            _people.Add(new PersonViewModel("SingletonSean"));
            _people.Add(new PersonViewModel("Mary"));
            _people.Add(new PersonViewModel("Joe"));

            _peopleStore.PersonAdded += OnPersonAdded;
        }

        private void OnPersonAdded(string name)
        {
            _people.Add(new PersonViewModel(name));
        }
    }
}
