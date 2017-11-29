using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Client
{
    public class ClientGestTopics : TCPClient, ITopicsManager
    {

        public List<string> listTopics()
        {
            sendMessage(new Message(Message.Header.LIST_TOPICS, null));
            return getMessage().data;
        }

        public IChatroom joinTopic(string topic)
        {
            sendMessage(new Message(Message.Header.JOIN_TOPIC,
                                    new List<String>{ topic }));

            ClientChatRoom proxyCR = new ClientChatRoom(topic);
            int portCR = int.Parse(getMessage().data[0]);
            proxyCR.setServer(IPAddress.Loopback, portCR);
            proxyCR.connect();
            return proxyCR;
        }

        public void createTopic(string topic)
        {
            sendMessage(new Message(Message.Header.CREATE_TOPIC,
                                    new List<String> { topic }));
        }
    }
}
