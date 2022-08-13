using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheVault.Interfaces;
using TheVault.Services;

namespace TheVault.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[]? args = null)
        {
            var _dataService = new DataService();
            var connectionString = _dataService.GetConnectionString();
            var options = new DbContextOptionsBuilder();

            options.UseNpgsql(connectionString);
            
            return new AppDbContext(options.Options);
        }
    }
}
