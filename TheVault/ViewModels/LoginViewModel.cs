using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TheVault.Commands;
using TheVault.Data;
using TheVault.Interfaces;
using TheVault.Services;
using TheVault.Utilities;
using TheVault.Views;

namespace TheVault.ViewModels
{
    internal class LoginViewModel : ViewModelBase
    {
        private readonly AppDbContextFactory _dbFactory;
        public LoginView _view;
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
            IsCreateAcctEnabled = false;
            CreateAccountCommand = new RelayCommand<CreateAccountView>(CreateAccount);
        }

        private void CreateAccount(CreateAccountView view)
        {
           view = new CreateAccountView();
           _view.Hide();
           view.ShowDialog();
        }

        private void Login()
        {
            using var db = _dbFactory.CreateDbContext();
            var user = db.Users.Where(x => x.Username!.Equals(Username)).FirstOrDefault();

            var buffer = Encoding.UTF8.GetBytes(Password!);
            var passwordHelper = new PasswordHasherHelper();
            var salt = Encoding.UTF8.GetBytes(user!.Salt!);
            var hash = passwordHelper.CreateHash(buffer, salt);
           
            if (user == null)
            {
                IsCreateAcctEnabled = true;
                //TODO: show system message telling the user that they don't have an acct, and to create a new acct!
            }
            else
            {
                var savedHash = user.PasswordHash;
                if (hash.Equals(savedHash))
                {
                    IsCreateAcctEnabled = false;
                    _view.Close();
                }
            }
            
           
        }

        private void CloseLoginWindow()
        {
            _view.Close();
        }
    }
}
