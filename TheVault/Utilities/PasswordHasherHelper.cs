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
            using var argon2 = new Argon2id(password);
            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 8;
            argon2.Iterations = 4;
            argon2.MemorySize = 1024 * 128;
            var hash = Encoding.ASCII.GetString(argon2.GetBytes(32));
            return hash;
        }

        public bool VerifyHash(byte[] password, byte[] salt, byte[] hash) =>
            CreateHash(password, salt).Equals(hash);
        

        public byte[] GenerateSalt()
        {
            var buffer = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(buffer);
            return buffer;
        }
    }
}
