using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TheVault.Interfaces;
using TheVault.Models;

namespace TheVault.Services
{
    public class MessageService: IMessageService, IDisposable
    {
        public SystemMessage? SystemMessage { get; set; }

        public void Dispose()
        {
            this.Dispose();
        }

        public async Task<SystemMessage>? SendSystemMessageAsync()
        {
            throw new NotImplementedException();
        }
    }
}
