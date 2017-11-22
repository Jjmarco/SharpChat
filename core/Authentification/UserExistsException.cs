using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chat
{
    class UserExistsException : AuthentificationException
    {
        public UserExistsException(String log)
            : base(log)
        {
        }

        public new String Message
        {
            get
            {
                return "L'utilisateur " + login + " existe déjà";
            }
        }
    }
}
