using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chat
{
    class UserUnknownException : AuthentificationException
    {
        public UserUnknownException(String log)
            : base(log)
        {
        }

        public String Message
        {
            get
            {
                return "L'utilisateur " + login + " n'existe pas.";
            }
        }
    }
}
