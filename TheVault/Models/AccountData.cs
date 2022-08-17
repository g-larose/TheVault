using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVault.Models
{
    public class AccountData
    {
        [Key]
        public Guid AccountId { get; set; }
        public string? AcctName { get; set; }
        public string? PasswordHash { get; set; }
        public string? Url { get; set; }
    }
}
