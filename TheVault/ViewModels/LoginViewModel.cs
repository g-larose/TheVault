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
        public LoginViewModel(AppDbContextFactory dbFactory, LoginView view)
        {
            _dbFactory = dbFactory;
            _view = view;
            CancelCommand = new RelayCommand(CloseLoginWindow);
            LoginCommand = new RelayCommand(Login);
            CreateAccountCommand = new RelayCommand<CreateAccountView>(CreateAccount);
        }

        private void CreateAccount(CreateAccountView view)
        {
           view = new CreateAccountView();
           view.ShowDialog();
        }

        private void Login()
        {
            var buffer = Encoding.UTF8.GetBytes(Password!);

            var passwordHelper = new PasswordHasherHelper();
            var salt = passwordHelper.GenerateSalt();
            var hash = passwordHelper.CreateHash(buffer, salt);
            using var db = _dbFactory.CreateDbContext();
            var user = db.Users.Where(x => x.Username!.Equals(Username)).FirstOrDefault();
            if (user != null)
            {
                if (user!.IsLoggedIn) return;
            }
            
           
        }

        private void CloseLoginWindow()
        {
            _view.Close();
        }
    }
}
