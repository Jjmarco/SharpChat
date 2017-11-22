using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Chat
{
    public class TCPClient : MessageConnection
    {
        private TcpClient _sock;
        private IPAddress _IP;
        private int _port;

        public TCPClient(IPAddress adr, int port)
        {
            _sock = new TcpClient();
            setServer(adr, port);
        }

        public void setServer(IPAddress adr, int port)
        {
            _IP = adr;
            _port = port;
        }

        public void connect()
        {
            _sock.Connect(_IP, _port);
        }

        public Message getMessage()
        {
            Message m = null;
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                m = (Message)bf.Deserialize(_sock.GetStream());
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

            bf.Serialize(_sock.GetStream(), m);
        }
    }
}
