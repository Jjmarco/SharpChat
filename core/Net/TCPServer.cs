using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Chat
{
    public abstract class TCPServer : MessageConnection
    {
        private TcpListener waitSock;
        private TcpClient commSocket;

        bool doRun, treatClient;

        public TCPServer()
        {
            doRun = false;
            treatClient = false;
        }

        public void startServer(int port)
        {
            waitSock = new TcpListener(IPAddress.Loopback, port);
            waitSock.Start();
            doRun = true;
        }

        public void stopServer()
        {
            waitSock.Stop();
            doRun = false;
        }

        public int getPort()
        {
            return ((IPEndPoint)waitSock.LocalEndpoint).Port;
        }

        public abstract void gereClient(TcpClient comm);

        public void run()
        {
            // thread handling incoming connections
            if (!treatClient)
            {
                while (doRun)
                {
                    try
                    {
                        // listen for new connections
                        commSocket = waitSock.AcceptTcpClient();

                        // clone server into new thread for handling newly created connection
                        TCPServer newClone = (TCPServer)MemberwiseClone();
                        newClone.treatClient = true;
                        new Thread(newClone.run).Start();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }
                }
            }
            // thread handling communication between established conenctions
            else gereClient(commSocket);
        }

        public Message getMessage()
        {
            Message m = null;
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                m = (Message)bf.Deserialize(commSocket.GetStream());
            }
            catch (SerializationException se)
            {
                Console.WriteLine("Erreur: message invalide: " + se.Message);
            }

            return m;
        }

        public void sendMessage(Message m)
        {
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(commSocket.GetStream(), m);
        }
    }
}
