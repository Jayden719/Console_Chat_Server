using ChatConsole_s;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main(string[] args)
    {

        MyServer a = new MyServer();

        /*Console.WriteLine("서버콘솔창 \n\n");
        IPAddress ip = IPAddress.Parse("127.0.0.1");

        TcpListener server = new TcpListener(ip, 9999);

        server.Start();

        TcpClient client = server.AcceptTcpClient();
        Console.WriteLine("클라이언트 접속");      

        while (true)
        {
            byte[] byteData = new byte[1024];
            client.GetStream().Read(byteData, 0, byteData.Length);
            String stringData = Encoding.Default.GetString(byteData);

            int endP = stringData.IndexOf('\0');
            String msg = stringData.Substring(0, endP + 1);

            Console.WriteLine(msg);
        }*/
    }
}
