using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheVault.Commands;
using TheVault.Data;
using TheVault.Interfaces;
using TheVault.Services;
using TheVault.Views;

namespace TheVault.ViewModels
{
    internal class AppViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly AppDbContextFactory _dbFactory;

        public ICommand? CloseAppCommand { get; }
        public ICommand? NavigateSettingsCommand { get; }

        public AppViewModel(IDataService dataService, AppDbContextFactory dbFactory)
        {
            _dataService = dataService;
            _dbFactory = dbFactory;

            CloseAppCommand = new RelayCommand(CloseApp);
            NavigateSettingsCommand = new RelayCommand<LoginView>(NavigateSettings);

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
