using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicStore2.Web.Models;

namespace Simple.MusicStore.Web.Services
{
    /*
    It deal with user actions 
    - find users 
    - deleting users 
    - adding users 
    - updating users 
    */
    public class UserService
    {
        private readonly List<User> _users;

        public UserService()
        {
            _users = new List<User>();
        }

        public void Add(User user)
        {
            if (user.Id != 0)
            {
                // error 
                return;

            }

            user.Id = new Random(DateTime.Now.Millisecond).Next();

            _users.Add(user);
        }

        public User[] GetAll()
        {
            return _users.ToArray();
        }
    }
}
