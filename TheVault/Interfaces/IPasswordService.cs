using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVault.Interfaces
{
    public interface IPasswordService
    {
        public string CreateHash(byte[] password, byte[] salt);
        public bool VerifyHash(byte[] password, byte[] salt, byte[] hash);
        public string GenerateRandomPassword(int length);
        public byte[] GenerateSalt();
    }
}
