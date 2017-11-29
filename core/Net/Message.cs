using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    [Serializable]
    public class Message
    {
        public enum Header {LIST_TOPICS,
                            LIST_TOPICS_REPLY,
                            CREATE_TOPIC,
                            JOIN_TOPIC,
                            JOIN_REPLY,
                            JOIN_CR,
                            POST,
                            QUIT_CR,
                            RECV_MSG};

        public readonly Header head;
        public readonly List<String> data;

        public Message(Header h, List<String> d)
        {
            head = h;
            data = d;
        }

        public new String ToString()
        {
            StringBuilder sb = new StringBuilder("Message\n  Header:\n    " + head + "\n  Data:\n");
            foreach (String s in data)
                sb.Append("    " + s + "\n");
            return sb.ToString();
        }
    }
}
