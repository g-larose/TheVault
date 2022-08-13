using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TheVault.Data;
using TheVault.Services;
using TheVault.ViewModels;

namespace TheVault.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private readonly AppDbContextFactory _dbFactory;
        public LoginView(AppDbContextFactory dbFactory)
        {
            InitializeComponent();
            _dbFactory = dbFactory;
            DataContext = new LoginViewModel(_dbFactory, this);
        }
    }
}
