using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MusicStore2.Web.Models;

namespace Simple.MusicStore.Web.Services
{
    /*
    It deal with userModel actions 
    - find users 
    - deleting users 
    - adding users 
    - updating users 
    */
    public class UserService
    {
        private readonly List<UserModel> _users;

        public UserService()
        {
            _users = new List<UserModel>();

            _users.Add(new UserModel()
            {
                EmailAddress = "admin@musicstore.com",
                FirstName = "Lolo",
                LastName = "Perez",
                Id = 1,
                Password = "password"
            });
        }

        public void Add(UserModel userModel)
        {
            if (userModel.Id != 0)
            {
                // error 
                return;

            }

            userModel.Id = new Random(DateTime.Now.Millisecond).Next();

            _users.Add(userModel);
        }

        public UserModel Find(string emailAddress)
        {
            for (var i = 0; i < _users.Count; i++)
            {
                if (_users[i].EmailAddress == emailAddress)
                {
                    return _users[i];
                }
            }

            return null;
        }

        public UserModel[] GetAll()
        {
            return _users.ToArray();
        }

        public ClaimsPrincipal CreateUserPrincipal(UserModel user, string scheme)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Email,user.EmailAddress),
                new Claim(ClaimTypes.AuthenticationMethod, "Native"),
            };

            var identity = new ClaimsIdentity(claims, scheme);

            return new ClaimsPrincipal(identity);
        }
    }
}
