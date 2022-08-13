using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVault.Utilities
{
    public class PasswordHasherHelper
    {
        /// <summary>
        /// Hashing password
        /// </summary>
        /// <param name="input"></param>
        /// <returns>base64 string</returns>
        public static string HashPassword(string input)
        {
            return string.Empty;
        }

        public static string GenerateRandomPassword(int length)
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
    }
}
