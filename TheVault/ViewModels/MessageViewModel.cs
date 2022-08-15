using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheVault.Commands;
using TheVault.Models;
using TheVault.Services;
using TheVault.Views;

namespace TheVault.ViewModels
{
    public class MessageViewModel : ViewModelBase
    {
		public ICommand? OKCommand { get; }

		private SystemMessage _systemMessage;
		private MessageView _mesView;
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

		public MessageViewModel(SystemMessage systemMessage, MessageView mesView)
		{
			_systemMessage = systemMessage;
			_mesView = mesView;
			OKCommand = new RelayCommand(HandleOk);
			
		}

		private void HandleOk()
		{
			_mesView.Close();
		}
	}
}
