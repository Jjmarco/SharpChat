using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    class TextChatter : IChatter
    {
        private String _pseudo;

        public TextChatter(String p)
        {
            _pseudo = p;
        }

        public void receiveAMessage(String msg, IChatter c)
        {
            Console.WriteLine("(At " + _pseudo + ") : " + c.getAlias() + " $> " + msg);
        }

        public String getAlias()
        {
            return _pseudo;
        }
    }
}
