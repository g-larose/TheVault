using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheVault.Models;

namespace TheVault.Interfaces
{
    public interface IMessageService
    {
        public SystemMessage? SystemMessage { get; set; }
        Task<SystemMessage>? SendSystemMessageAsync();
    }
}
