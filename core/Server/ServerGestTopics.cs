using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Server
{
    class ServerGestTopics : TCPServer
    {
        private TCPGestTopics concreteGT;

        public ServerGestTopics() : base()
        {
            concreteGT = new TCPGestTopics();
        }

        public override void gereClient(System.Net.Sockets.TcpClient comm)
        {
            Message m = null;

            while((m = getMessage()) != null)
            {
                Message response = null;

                switch (m.head)
                {
                    case Message.Header.LIST_TOPICS:
                        response = new Message(Message.Header.LIST_TOPICS_REPLY,
                                               concreteGT.listTopics());
                        break;
                    case Message.Header.CREATE_TOPIC:
                        concreteGT.createTopic(m.data[0]);
                        break;
                    case Message.Header.JOIN_TOPIC:
                        Console.WriteLine("Attempting to join topic " + m.data[0]);
                        IChatroom cr = concreteGT.joinTopic(m.data[0]);
                        response = new Message(Message.Header.JOIN_REPLY,
                                               new List<String>{ this.getPort().ToString() });
                        break;
                }

                if(response != null) sendMessage(response);
            }
        }
    }
}
