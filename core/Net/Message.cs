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
        public enum Header { CONTROL, INFO, MESSAGE };

        Header head;
        List<String> data;

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
