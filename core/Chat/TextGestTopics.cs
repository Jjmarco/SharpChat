using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    class TextGestTopics : ITopicsManager
    {
        private Dictionary<String, IChatroom> chatrooms;

        public TextGestTopics()
        {
            chatrooms = new Dictionary<string,IChatroom>();
        }

        public List<string> listTopics()
        {
            Console.WriteLine("The currently opened topics are:");
            foreach (String topic in chatrooms.Keys)
                Console.WriteLine(topic);
            return chatrooms.Keys.ToList<String>();

            return null;
        }

        public IChatroom joinTopic(String topic)
        {
            IChatroom chatroom;
            chatrooms.TryGetValue(topic, out chatroom);
            return chatroom;
        }

        public void createTopic(String topic)
        {
            IChatroom chatroom = new TextChatroom(topic);
            if (topic != null && !chatrooms.ContainsKey(topic)) chatrooms.Add(topic, chatroom);
        }
    }
}
