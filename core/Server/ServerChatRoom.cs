using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Server
{
    class ServerChatRoom : TCPServer, IChatter
    {
        private string pseudo;
        private TextChatroom concreteCR;

        public TextChatroom ConcreteCR
        {
            get
            {
                return concreteCR;
            }
        }

        public ServerChatRoom(string topic) : base()
        {
            pseudo = "";
            concreteCR = new TextChatroom(topic);
        }

        public override void gereClient(System.Net.Sockets.TcpClient comm)
        {
            Message m = null;

            while ((m = getMessage()) != null)
            {
                switch (m.head)
                {
                    case Message.Header.JOIN_CR:
                        pseudo = m.data[0];
                        concreteCR.join(this);
                        break;
                    case Message.Header.POST:
                        concreteCR.post(m.data[0], this);
                        break;
                    case Message.Header.QUIT_CR:
                        concreteCR.quit(this);
                        break;
                }
            }
        }

        public void receiveAMessage(string msg, IChatter c)
        {
            Console.WriteLine("Message de " + c.getAlias() + " reçu: '" + msg + "'");
            sendMessage(new Message(Message.Header.RECV_MSG, new List<string>{ msg, c.getAlias() }));
        }

        public string getAlias()
        {
            return pseudo;
        }
    }
}
