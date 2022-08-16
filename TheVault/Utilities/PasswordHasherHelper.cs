using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheVault.Interfaces;
using System.Security.Cryptography;
using Konscious.Security.Cryptography;

namespace TheVault.Utilities
{
    public class PasswordHasherHelper : IPasswordService
    {
        public string GenerateRandomPassword(int length)
        {
            var chars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890<>/?!@#$%^&*()_-";
            var rnd = new Random();
            var builder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                var index = rnd.Next(chars.Length);
                builder.Append(chars[index]);
            };
            return builder.ToString();
        }

        public string CreateHash(byte[] password, byte[] salt)
        {
            var saltedPass = Combine(password, salt);
            using var md5 = MD5.Create();
            var tempHash = md5.ComputeHash(saltedPass);
            var hash = ByteArrayToString(tempHash);
            return hash;
        }

        public bool VerifyHash(byte[] password, byte[] salt, byte[] hash) =>
            CreateHash(password, salt).Equals(hash);
        

        public string GenerateSalt()
        {
            string? buffer = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890";
            var saltBuilder = new StringBuilder();
            var rnd = new Random();
            for (int i = 0; i < 28; i++)
            {
                var index = rnd.Next(1, buffer.Length);
                saltBuilder.Append(buffer[index]);
            }
            return saltBuilder.ToString();
        }

        private string ByteArrayToString(byte[] args)
        {
            return Convert.ToBase64String(args);
        }

        private byte[] Combine(byte[] ar1, byte[] ar2)
        {
            byte[] ret = new byte[ar1.Length + ar2.Length];
            Buffer.BlockCopy(ar1, 0, ret, 0, ar1.Length);
            Buffer.BlockCopy(ar2, 0, ret, ar1.Length, ar2.Length);
            return ret;
        }
    }
}
