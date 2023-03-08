using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;

namespace Socket_Server_Tcp
{
    internal class Socket_Server
    {
        
        static void Main(string[] args)
        {
            //1.创建服务器对象Socket
            Socket SocketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
            EndPoint endPoint = new IPEndPoint(iPAddress, 8055);
            //Program program = new Program();
            //2.绑定IP和端口号
            SocketServer.Bind(endPoint);
            Console.WriteLine("服务器绑定成功！！！");
            //3.设置监听队列
            SocketServer.Listen(10);
            Console.WriteLine("开始监听.....");

            while (true)
            {
                //4.等待客户端连接,客户端连接之后立马实例化通讯Socket，以及利用构造函数启动线程
                Socket newSocket = SocketServer.Accept();
                //byte[] data = new byte[1024];

                Tele_Socket teleSocket = new Tele_Socket(newSocket);

                Console.WriteLine("连接到一个客户端：" + newSocket.RemoteEndPoint);
                //将实例化的客户端对象放进列表中便于操作管理
                teleSockets.Add(teleSocket);

            }
        }
        public static List<Tele_Socket> teleSockets = new List<Tele_Socket>();
        public static void BroadcastMessage(string message)
        {
            List<Tele_Socket> unSockets = new List<Tele_Socket>();

            for (int i = 0; i < teleSockets.Count; i++)
            {
                if (teleSockets[i].isConnection)
                {
                    teleSockets[i].SendMessage(message);
                }
                else
                {
                    unSockets.Add(teleSockets[i]);
                }
            }

            for (int i = 0; i < unSockets.Count; i++)
            {
                teleSockets.Remove(unSockets[i]);

            }
        }


    }
}
