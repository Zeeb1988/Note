using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;


 namespace Socket_Server_Tcp
{
    internal class Tele_Socket
    {
       
        private Socket TeleSocket;
       
        //设置属性，检测是否连接成功
        public bool isConnection
        {
            get { return TeleSocket.Connected; }
        }


        public Tele_Socket(Socket newSocket)
        {
            TeleSocket = newSocket;
            Thread thread = new Thread(ReceiveMessage);
            thread.Start();

        }

        //通过构造函数启动，负责等待接收客户端的数据
        //作为接收字符串转换成数据流的容器
        public byte[] data = new byte[2048];
        void ReceiveMessage()
        {
            while (true)
            {
                //检测客户端是否存在，不存在则返回true
                if (TeleSocket.Poll(10, SelectMode.SelectRead))
                {
                    TeleSocket.Close();
                    break;
                }
                int length = TeleSocket.Receive(data);
                string message = Encoding.UTF8.GetString(data, 0, length);
                //将收到的data数据转换成字符串并广播出去
                Socket_Server.BroadcastMessage(message);
                Console.WriteLine("接收到客户端发送的消息：" + message);

            }
        }

        public void SendMessage(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            TeleSocket.Send(data);

        }
       
    }
}
