using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheVault.Models;

namespace TheVault.ViewModels
{
    public class PasswordListViewModel : ViewModelBase
    {
		private ObservableCollection<AccountData>? _passwordList;
		public ObservableCollection<AccountData>? PasswordList
		{
			get => _passwordList;
			set => OnPropertyChanged(ref _passwordList, value);
		}

		public PasswordListViewModel()
		{
			PasswordList = LoadPasswordList();
		}

		private ObservableCollection<AccountData>? LoadPasswordList()
		{
			var passwordList = new ObservableCollection<AccountData>();
			for (int i = 0; i < 10; i++)
			{
				var passwordAcct = new AccountData()
				{
					AcctName = "BestBuy",
					PasswordHash = "123456",
					Url = "https://www.bestbuy.com"
				};
				passwordList!.Add(passwordAcct);
		    }
			return passwordList;
		}
			
	}
}
