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
            TCPClient client = new TCPClient(IPAddress.Loopback, 25565);
            client.connect();

            string input = "";

            Console.Write("> ");

            while ((input = Console.ReadLine()) != "exit")
            {
                Message m = new Message(Message.Header.INFO, new List<String>(input.Split(' ')));
                client.sendMessage(m);
                Console.Write("> ");
            }
        }
    }
}
