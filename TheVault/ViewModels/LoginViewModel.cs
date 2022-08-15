using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TheVault.Commands;
using TheVault.Data;
using TheVault.Interfaces;
using TheVault.Models;
using TheVault.Services;
using TheVault.Utilities;
using TheVault.Views;

namespace TheVault.ViewModels
{
    internal class LoginViewModel : ViewModelBase
    {
        private readonly AppDbContextFactory _dbFactory;
        private UserHelper _userHelper;
        private LoginView _view;
        public ICommand? CancelCommand { get; }
        public ICommand? LoginCommand { get; }
        public ICommand? CreateAccountCommand { get; }

        private string? _username;
        public string? Username
        {
            get => _username;
            set => OnPropertyChanged(ref _username, value);
        }

        private string? _password;
        public string? Password
        {
            get => _password;
            set => OnPropertyChanged(ref _password, value);
        }

        private bool _isCreateAcctEnabled;
        public bool IsCreateAcctEnabled
        {
            get => _isCreateAcctEnabled;
            set => OnPropertyChanged(ref _isCreateAcctEnabled, value);
        }
        public LoginViewModel(AppDbContextFactory dbFactory, LoginView view)
        {
            _dbFactory = dbFactory;
            _view = view;
            CancelCommand = new RelayCommand(CloseLoginWindow);
            LoginCommand = new RelayCommand(Login);
            _userHelper = new UserHelper(_dbFactory);
            IsCreateAcctEnabled = false;
            CreateAccountCommand = new RelayCommand(CreateAccount);
        }

        private void CreateAccount()
        {
            //TODO: handle creating user account.
        }

        #region LOGIN USER
        private void Login()
        {
            var user = _userHelper.GetUser(Username);

            if (user == null)
            {
                IsCreateAcctEnabled = true;
                var sysMessage = new SystemMessage()
                {
                    Message = "User does not Exist",
                    IconImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "error.png"),
                    Type = SystemMessageType.INFORMATION,
                    IsDialog = true
                };
                var mesView = new MessageView(sysMessage);
                mesView.ShowDialog();  
            }
            else
            {
                
                if (_userHelper.LoginUser(Username!, Password!))
                {
                    IsCreateAcctEnabled = false;
                    _view.Close();
                }
            }
            
           
        }
        #endregion

        private void CloseLoginWindow()
        {
            _view.Close();
        }
    }
}
