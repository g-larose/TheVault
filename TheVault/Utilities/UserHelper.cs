using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheVault.Data;
using TheVault.Models;

namespace TheVault.Utilities
{
    public class UserHelper
    {
        private AppDbContextFactory? _dbFactory;

        public UserHelper(AppDbContextFactory? dbFactory)
        {
            _dbFactory = dbFactory;
        }


        /// <summary>
        /// Validate user exists
        /// </summary>
        /// <param name="username"></param>
        /// <returns>true if user exists, false if user does not exist</returns>
        public bool ValidateUser(string? username)
        {
            var db = _dbFactory!.CreateDbContext();
            return db.Users.Any(u => u.Username == username);
        }

        /// <summary>
        /// Get a specific AppUser
        /// </summary>
        /// <param name="username"></param>
        /// <returns>A single AppUser</returns>
        public AppUser GetUser(string? username)
        {
            var db = _dbFactory?.CreateDbContext();
            return db.Users.Where(x => x.Username.Equals(username)).FirstOrDefault();

        }

        /// <summary>
        /// Get All Application Users
        /// </summary>
        /// <returns>List of AppUser</AppUser></returns>
        public List<AppUser> GetAllUsers()
        {
            var db = _dbFactory!.CreateDbContext();
            return db.Users.ToList();
        }

        public bool LoginUser(string? username, string? password)
        {
            var db = _dbFactory!.CreateDbContext();
            var user = db.Users.Where(x => x.Username!.Equals(username)).FirstOrDefault();

            if (user is not null)
            {
                
                var hashHelper = new PasswordHasherHelper();
                var salt = user.Salt;
                var _password = Encoding.ASCII.GetBytes(password!);
                var _saltBytes = Encoding.ASCII.GetBytes(salt!);
                var savedHash = user.PasswordHash;
                var newHash = hashHelper.CreateHash(_password, _saltBytes);

                if (newHash.Equals(savedHash))
                    return true;
            }

            return false;
        }
    }
}
