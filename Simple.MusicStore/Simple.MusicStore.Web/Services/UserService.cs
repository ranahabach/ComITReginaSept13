using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Simple.MusicStore.Tools.Data;
using Simple.MusicStore.Web.Data;
using Simple.MusicStore.Web.Models;

namespace Simple.MusicStore.Web.Services
{
    /*
    It deal with userModel actions 
    - find users 
    - deleting users 
    - adding users 
    - updating users 
    - changing password 
    - checking passwords 
    */
    public class UserService
    {
        private readonly MusicStoreDbContext _context;

        public UserService(MusicStoreDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.User.Add(user);

            _context.SaveChanges();
        }

        public User Find(string emailAddress)
        {
            return _context.User.FirstOrDefault(u => u.Email == emailAddress);
        }
        
        public void Delete(User user)
        {
            _context.User.Remove(user);

            _context.SaveChanges();
        }

        public void Update(User user)
        {
            var dbUser = _context.User.Find(user.UserId);
            if (dbUser == null)
            {
                throw new InvalidOperationException("User is not in the database");
            }

            dbUser.Email = user.Email;
            dbUser.FirstName = user.FirstName;
            dbUser.LastName = user.LastName;

            _context.User.Update(dbUser);

            _context.SaveChanges();
        }

        public void UpdatePassword(int userId, string newPassword)
        {
            var dbUser = _context.User.Find(userId);
            if (dbUser == null)
            {
                throw new InvalidOperationException("User is not in the database");
            }
            
            dbUser.Password = newPassword;

            _context.User.Update(dbUser);

            _context.SaveChanges();
        }

        public User[] GetAll()
        {
            return _context.User.ToArray();
        }

        public ClaimsPrincipal CreateUserPrincipal(User user, string scheme)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.AuthenticationMethod, "Native"),
            };

            if (user.IsAdmin.HasValue && user.IsAdmin == 1)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));
            }
            
            var identity = new ClaimsIdentity(claims, scheme);
            
            var principal =  new ClaimsPrincipal(identity);

            return principal;
        }

        private const string AllCaps = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string AllNumbers = "0123456789";
        public bool IsValidPassword(string password)
        {
            //     /*
            //      The password rules are"
            //         - must contain a capital letter 
            //         - must contain a number 
            //         - must be at least 6 character long 
            //     */

            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            if (password.Length < 6)
            {
                return false;
            }

            var hasCapitalLetter = false;
            var hasNumber = false;
            foreach (var c in password)
            {
                if (AllCaps.Contains(c))
                {
                    hasCapitalLetter = true;
                }

                if (AllNumbers.Contains(c))
                {
                    hasNumber = true;
                }
            }

           
            return hasCapitalLetter && hasNumber;
        }
    }
}
