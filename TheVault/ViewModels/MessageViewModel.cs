using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheVault.Models;
using TheVault.Services;

namespace TheVault.ViewModels
{
    public class MessageViewModel : ViewModelBase
    {
		private string? _message;
		public string? Message
		{
			get => _message;
			set => OnPropertyChanged(ref _message, value);
		}

		public MessageViewModel(SystemMessage systemMessage)
		{

		}
	}
}
