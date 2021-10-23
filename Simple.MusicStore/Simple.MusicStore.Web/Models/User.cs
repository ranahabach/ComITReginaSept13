using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore2.Web.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set;  }
        public string EmailAddress { get; set; }

        /*
         The password rules are"
            - must contain a capital letter 
            - must contain a number 
            - must be at least 6 character long 
        */
        public string Password { get; set; }
    }
}
