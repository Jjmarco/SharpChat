using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Server
{
    class TCPGestTopics : TextGestTopics
    {
        public static int nextPort = 25566;

        public new void createTopic(String topic)
        {
            if (topic == null || chatrooms.ContainsKey(topic))
                return;

            ServerChatRoom chatroom = new ServerChatRoom(topic);

            chatroom.startServer(nextPort++);

            chatrooms.Add(topic, chatroom.ConcreteCR);

            Console.WriteLine("Topic "+ topic+" created");
        }
    }
}
