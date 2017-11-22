using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chat
{
    class WrongPasswordException : AuthentificationException
    {
        public WrongPasswordException(String log)
            : base(log)
        {
        }

        public new String Message
        {
            get
            {
                return "Mot de passe incorrect pour l'utilisateur " + login + ".";
            }
        }
    }
}
