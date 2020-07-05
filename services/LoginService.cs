using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm.services
{
    public class LoginService
    {
        private IDictionary<string, LoginUser> Logins = new Dictionary<string, LoginUser>();
        private int IdCounter = 0;
        public LoginUser LoggedUser { set; get; }
        public bool IsSuperUser { set; get; }

        public LoginService()
        {
            Logins.Add("sukhpreet", new LoginUser(GetId(), "sukhpreet", "root", 1));
            Logins.Add("prof", new LoginUser(GetId(), "prof", "root", 1));
            Logins.Add("root", new LoginUser(GetId(), "root", "root", 1));
            Logins.Add("robin", new LoginUser(GetId(), "robin", "root", 0));
            Logins.Add("gagan", new LoginUser(GetId(), "gagan", "root", 0));
            Logins.Add("sarbjot", new LoginUser(GetId(), "sarbjot", "root", 0));
            Logins.Add("pavneet", new LoginUser(GetId(), "pavneet", "root", 0));
        }

        public int GetId() { return ++IdCounter; }

        public bool Login(string username, string password)
        {
            if (Logins.ContainsKey(username) && password.Equals(Logins[username].Password))
            {
                LoggedUser = Logins[username];
                if (LoggedUser.SuperUser == 1) IsSuperUser = true;
                else IsSuperUser = false;
                return true;
            }
            return false;
        }

    }
}
