using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Chat
{
    [Serializable]
    class User
    {
        public static readonly SHA512 hash = SHA512.Create();

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
