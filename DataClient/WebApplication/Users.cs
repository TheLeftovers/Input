using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;

namespace WebApplication
{
    public class Users
    {
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }

        public Users()
        {

        }

        public Users(string Email, string Password)
        {
            this.Email = Email;
            this.Password = Password;
        }

    }
}