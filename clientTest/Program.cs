using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Chat;
using System.Net;

namespace ChatClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                TCPClient client = new TCPClient(IPAddress.Loopback, 25565);
                client.connect();

                Message m = new Message(Message.Header.INFO, new List<String> { "lol " + i });

                client.sendMessage(m);
            }

            Console.Read();
        }
    }
}
