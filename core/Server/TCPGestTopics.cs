using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Server
{
    class TCPGestTopics : TextGestTopics
    {
        public static int nextPort = 25566;

        private Dictionary<string, ServerChatRoom> serverCRs;

        public TCPGestTopics()
            : base()
        {
            serverCRs = new Dictionary<string, ServerChatRoom>();
        }

        public new void createTopic(String topic)
        {
            if (topic == null || chatrooms.ContainsKey(topic))
                return;

            ServerChatRoom chatroom = new ServerChatRoom(topic);

            serverCRs.Add(topic, chatroom);

            chatroom.startServer(nextPort++);
            new Thread(chatroom.run).Start();

            chatrooms.Add(topic, chatroom.ConcreteCR);

            Console.WriteLine("Topic "+ topic+" created on port " + chatroom.getPort());
        }

        public new ServerChatRoom joinTopic(string topic)
        {
            ServerChatRoom chatroom;
            serverCRs.TryGetValue(topic, out chatroom);
            return chatroom;
        }
    }
}
