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
		private SystemMessage _systemMessage;
		public SystemMessage SystemMessage
		{
			get => _systemMessage;
			set => OnPropertyChanged(ref _systemMessage, value);
		}

		private string? _message;
		public string? Message
		{
			get => _message;
			set => OnPropertyChanged(ref _message, value);
		}

		private string? _defaultIcon;
		public string? DefaultIcon
		{
			get => _defaultIcon;
			set => OnPropertyChanged(ref _defaultIcon, value);
		}

		public MessageViewModel(SystemMessage systemMessage)
		{
			_systemMessage = systemMessage;
		}
	}
}
