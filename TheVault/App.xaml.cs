﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using TheVault.Data;
using TheVault.Interfaces;
using TheVault.Services;
using TheVault.ViewModels;

namespace TheVault
{
    public partial class App : Application
    {
       
        private readonly IHost _host;
        public App()
        {
            _host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<AppViewModel>();
                services.AddTransient<AppDbContextFactory>();
                services.AddSingleton<IDataService, DataService>();
                services.AddSingleton<MainWindow>(s => new TheVault.MainWindow()
                {
                    DataContext = s.GetRequiredService<AppViewModel>()
                });
            }).Build();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();
            base.OnExit(e);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
