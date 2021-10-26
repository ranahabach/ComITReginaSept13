using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple.MusicStore.Web.Models
{
    public class LoginModel
    {
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
