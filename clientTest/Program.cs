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
            /*TCPClient client = new TCPClient(IPAddress.Loopback, 25565);
            client.connect();

            string input = "";

            Console.Write("> ");

            while ((input = Console.ReadLine()) != "exit")
            {
                Message m = new Message(Message.Header.POST, new List<String>(input.Split(' ')));
                client.sendMessage(m);
                Console.Write("> ");
            }*/

            Chat.Client.ClientGestTopics client = new Chat.Client.ClientGestTopics();

            client.setServer(IPAddress.Loopback, 25565);
            client.connect();

            IChatter bob = new TextChatter("Bob");

            client.createTopic("test");

            Chat.Client.ClientChatRoom cr = (Chat.Client.ClientChatRoom)client.joinTopic("test");

            cr.join(bob);

            string message;

            Console.Write("> ");

            while ((message = Console.ReadLine()) != "exit")
            {
                cr.post(message, bob);
                Console.Write("> ");
            }
        }
    }
}
