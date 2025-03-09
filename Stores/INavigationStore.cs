using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBYS_WPF.MVVM.ViewModels;

namespace UBYS_WPF.Stores
{
    public interface INavigationStore
    {
        ViewModelBase CurrentViewModel { set; }
    }
}
