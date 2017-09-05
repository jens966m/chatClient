using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ChatClient
{
    public class ServerFacade
    {
        TcpClient client;
        NetworkStream nWS;
        StreamReader sR;
        StreamWriter sW;
        int port;
        string serverName;

        public delegate void ThreadEventType(string message);
        public event ThreadEventType threadEvent;

        public ServerFacade(int port,  string serverName)
        {
            this.port = port;
            this.serverName = serverName;
            client = new TcpClient();
            ConnectToServer();
            nWS = client.GetStream();
            sR = new StreamReader(nWS);
            sW = new StreamWriter(nWS);
        }

        private void ConnectToServer()
        {
            client.Connect(serverName, port);
        }

        private void Close()
        {
            client.GetStream().Close();
        }

        public void Dispose()
        {
            client.Close();
        }

        public void RecieveFromServer()
        {
            string recieveMessage;
            while (true)
            {
             
                    recieveMessage = sR.ReadLine();
                    threadEvent(recieveMessage);

            }
     

        }
        public void SendToServer(string sendMessage)
        {
            sW.WriteLine(sendMessage);
            sW.Flush();
        }


    }
}
