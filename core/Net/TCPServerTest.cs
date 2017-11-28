using System;
using System.Collections.Generic;
using System.IO;
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
            string address = ((IPEndPoint)commSock.Client.RemoteEndPoint).Address + ":" + ((IPEndPoint)commSock.Client.RemoteEndPoint).Port;

            Console.WriteLine("Connexion acceptée: " + address);

            while (commSock.Connected)
            {
                try
                {
                    Console.WriteLine(getMessage().ToString());
                }
                catch(IOException io)
                {
                    Console.WriteLine("Erreur de communication : " + io.Message);
                    break;
                }
            }

            Console.WriteLine("Connexion perdue avec " + address);
        }
    }
}
