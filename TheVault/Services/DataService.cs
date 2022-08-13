using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TheVault.Interfaces;
using TheVault.Models;

namespace TheVault.Services
{
    internal class DataService : IDataService
    {
        public string GetConnectionString()
        {
            var jsonFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
            var json = File.ReadAllText(jsonFile);
            var connectionString = JsonConvert.DeserializeObject<ConfigJson>(json);
            return connectionString!.ConnectionString!;
        }

    }
}
