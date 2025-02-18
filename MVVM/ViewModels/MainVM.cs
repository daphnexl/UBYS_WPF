using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBYS_WPF.Cores;

namespace UBYS_WPF.MVVM.ViewModels
{
    public class MainVM : ViewModelBase
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

		public MainVM() {
			Data = "Kullanıcı Adı";
		}
    }
}
