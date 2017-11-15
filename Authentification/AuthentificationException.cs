using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    class AuthentificationException : Exception
    {
        public String login;

        public AuthentificationException(String log) : base("Erreur avec l'utilisateur " + log)
        {
            login = log;
        }
    }
}
