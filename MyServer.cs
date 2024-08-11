using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatConsole_s
{
    class MyServer
    {
        public MyServer()
        {
            AsyncServerStart();

        }

        private void AsyncServerStart()
        {
            TcpListener listener = new TcpListener(new IPEndPoint(IPAddress.Any, 9999));
            listener.Start();
            Console.WriteLine("서버 구동 / 클라이언트 접속 대기...");

            while (true)
            {
            TcpClient acceptClient = listener.AcceptTcpClient();
            Console.WriteLine("클라이언트 접속 성공");

            ClientData clientData = new ClientData(acceptClient);

            clientData.client.GetStream().BeginRead(clientData.readByteData, 0, clientData.readByteData.Length, new AsyncCallback(DataReceived), clientData);
            }

        }

        private void DataReceived(IAsyncResult ar)
        {
            ClientData callbackClient = ar.AsyncState as ClientData;

            int bytesRead = callbackClient.client.GetStream().EndRead(ar);

            String readString = Encoding.Default.GetString(callbackClient.readByteData, 0, bytesRead);

            Console.WriteLine("{0}번 사용자 : {1}", callbackClient.clientNumber, readString);

            callbackClient.client.GetStream().BeginRead(callbackClient.readByteData, 0, callbackClient.readByteData.Length, new AsyncCallback(DataReceived), callbackClient);
        }
    }
}
