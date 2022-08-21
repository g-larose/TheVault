using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TheVault.Commands;
using TheVault.Utilities;

namespace TheVault.ViewModels
{
    public class AddNewPasswordViewModel : ViewModelBase
    {
		private PasswordHasherHelper _pwHelper;
		public ICommand? GenerateNewPasswordCommand { get; }
		public ICommand? CopyToClipboardCommand { get; }

		private string? _newPassword;
		public string? NewPassword
		{
			get => _newPassword;
			set => OnPropertyChanged(ref _newPassword, value);
		}

		private string? _isVisible;
		public string? IsVisible
		{
			get => _isVisible;
			set => OnPropertyChanged(ref _isVisible, value);
		}

		public AddNewPasswordViewModel()
		{
			_pwHelper = new PasswordHasherHelper();
			IsVisible = "Hidden";
			GenerateNewPasswordCommand = new RelayCommand(GeneratePassword);
			CopyToClipboardCommand = new RelayCommand(CopyPassword);
		}

		private void CopyPassword()
		{
			Clipboard.SetText(NewPassword);
		}

		private void GeneratePassword()
		{
			NewPassword = _pwHelper.GenerateRandomPassword(18);
			IsVisible = "Visible";
		}
	}
}
