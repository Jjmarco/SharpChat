using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Client
{
    public class ClientChatRoom : TCPClient, IChatroom
    {
        private IChatter _clientChatter;
        private string _topic;
        private bool doRun;

        public ClientChatRoom(string topic) : base()
        {
            _topic = topic;
            doRun = false;
        }

        public void run()
        {
            while (doRun)
            {
                Message m = getMessage();

                if (m != null && m.head == Message.Header.RECV_MSG)
                {
                    _clientChatter.receiveAMessage(m.data[0], new TextChatter(m.data[1]));
                }
            }
        }

        public void post(string msg, IChatter c)
        {
            Console.WriteLine(msg);
            sendMessage(new Message(Message.Header.POST,
                                    new List<String> { msg, c.getAlias() }));
        }

        public void quit(IChatter c)
        {
            sendMessage(new Message(Message.Header.QUIT_CR,
                                    null));
            doRun = false;
        }

        public void join(IChatter c)
        {
            sendMessage(new Message(Message.Header.JOIN_CR,
                                    new List<String> { c.getAlias() }));
            _clientChatter = c;

            doRun = true;
            new Thread(new ThreadStart(this.run)).Start();
            
        }

        public string getTopic()
        {
            throw new NotImplementedException();
        }
    }
}
