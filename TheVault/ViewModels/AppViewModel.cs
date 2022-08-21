using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheVault.Commands;
using TheVault.Data;
using TheVault.Interfaces;
using TheVault.Navigation;
using TheVault.Services;
using TheVault.Views;

namespace TheVault.ViewModels
{
    internal class AppViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly AppDbContextFactory _dbFactory;
        private readonly INavigator _navigator;
        public ViewModelBase? CurrentViewModel => _navigator.CurrentViewModel;
        public ICommand? CloseAppCommand { get; }
        public ICommand? NavigateSettingsCommand { get; }
        public ICommand? NavigatePasswordListCommand { get; }
        public ICommand? NavigateNewPasswordViewCommand { get; }

        private bool _isLoggedIn;
        public bool IsLoggedIn
        {
            get => _isLoggedIn;
            set => OnPropertyChanged(ref _isLoggedIn, value);
        }

        public AppViewModel(IDataService dataService, AppDbContextFactory dbFactory, INavigator navigator)
        {
            _dataService = dataService;
            _dbFactory = dbFactory;
            _navigator = navigator;
            if (!IsLoggedIn)
            {
                var logView = new LoginView(_dbFactory);
                logView.ShowDialog();
                IsLoggedIn = true;
            }
            _navigator.CurrentViewModelChanged += OnViewModelChanged;
            CloseAppCommand = new RelayCommand(CloseApp);
            NavigateSettingsCommand = new RelayCommand<LoginView>(NavigateSettings);
            NavigatePasswordListCommand = new NavigateCommand<PasswordListViewModel>(_navigator, () => new PasswordListViewModel());
            NavigateNewPasswordViewCommand = new NavigateCommand<AddNewPasswordViewModel>(_navigator, () => new AddNewPasswordViewModel());
            
        }

        private void OnViewModelChanged()
        {
            if (!_isLoggedIn) return;
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private void NavigateSettings(LoginView view)
        {
            view = new LoginView(_dbFactory);
            view.ShowDialog();
        }

        private void CloseApp()
        {
            Environment.Exit(0);
        }
    }
}
