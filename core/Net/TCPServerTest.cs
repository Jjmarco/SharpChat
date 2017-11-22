using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    class TCPServerTest : TCPServer
    {
        public override void gereClient(TcpClient commSock)
        {
            Console.WriteLine("Connexion acceptée: " + ((IPEndPoint)commSock.Client.RemoteEndPoint).Address + ":" + ((IPEndPoint)commSock.Client.RemoteEndPoint).Port);
            Console.WriteLine(getMessage().ToString());
        }
    }
}
