using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVault.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public string? Salt { get; set; }
        public DateTimeOffset Created { get; set; }
        public bool IsLoggedIn { get; set; }
        public bool  IsAdmin { get; set; }
    }
}
