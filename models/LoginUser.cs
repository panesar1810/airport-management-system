using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm
{
    public class LoginUser
    {

        public int ID { set; get; }
        public string Username { set; get; }
        public string Password { set; get; }
        public int SuperUser { set; get; }

        public LoginUser() { }

        public LoginUser(int id, string username, string password, int superuser) 
        {
            ID = id;
            Username = username;
            Password = password;
            SuperUser = superuser;
        }

        public static implicit operator string(LoginUser v)
        {
            throw new NotImplementedException();
        }
    }
}
