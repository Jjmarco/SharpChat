using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    [Serializable]
    class User
    {
        private String login;
        private String password;

        public User(String log, String pwd)
        {
            login = log;
            password = pwd;
        }

        public String Login
        {
            get
            {
                return login;
            }
        }

        public String Password
        {
            get
            {
                return password;
            }
        }
    }
}
