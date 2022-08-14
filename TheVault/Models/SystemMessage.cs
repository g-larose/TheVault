using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVault.Models
{
    public class SystemMessage
    {
        public string? Message { get; set; }
        public string? IconImagePath { get; set; }
        public SystemMessageType Type { get; set; }
        public bool IsDialog { get; set; }
    }
}
