using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    class TextChatroom : IChatroom
    {
        private String _topic;
        private List<IChatter> chatters;

        public TextChatroom(String t)
        {
            _topic = t;
            chatters = new List<IChatter>();
        }

        public void post(string msg, IChatter c)
        {
            foreach (IChatter chatter in chatters)
                chatter.receiveAMessage(msg, c);
        }

        public void quit(IChatter c)
        {
            if (!chatters.Contains(c))
            {
                chatters.Remove(c);
                Console.WriteLine("> Chatroom " + _topic + ": " + c.getAlias() + " has left the room.");
            }
        }

        public void join(IChatter c)
        {
            if (!chatters.Contains(c))
            {
                chatters.Add(c);
                Console.WriteLine("> Chatroom " + _topic + ": " + c.getAlias() + " has joined the room.");
            }
        }

        public String getTopic()
        {
            return _topic;
        }
    }
}
