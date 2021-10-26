using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
