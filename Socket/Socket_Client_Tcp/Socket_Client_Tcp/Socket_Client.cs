using System;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Socket_Client_Tcp
{
    internal class Socket_Client
    {
        //1.创建客户端Socket对象
        public static Socket SocketClient;
        static void Main(string[] args)
        {
            SocketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //EndPoint类为抽象类，无法直接实例化。利用其子类实例化（多态）
            EndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8055);
            //2.绑定IP和端口号，绑定成功之后立马实例化调用服务器端的构造函数
            SocketClient.Connect(endPoint);

            Thread thread = new Thread(ReceiveMessage);
            thread.Start();
            //从控制台输入字符串
            string clientMessage = Console.ReadLine();
            SendMessage(clientMessage);
            
        }

        public static void SendMessage(string message)
        {
            //将输入的字符串转换成数据流发送给服务端
            byte[] data = Encoding.UTF8.GetBytes(message);
            SocketClient.Send(data);
        }
        
        public static byte[] data = new byte[2048];
        //静态方法里启动的线程函数也必须时静态的
        public static void ReceiveMessage() 
        {
            while (true)
            {
                
                int length = SocketClient.Receive(data);
                string message = Encoding.UTF8.GetString(data, 0, length);
                //Socket_Server.BroadcastMessage(message);
                Console.WriteLine("接收到服务器发送的消息：" + message);
                
            }
        }
        

    }
}
