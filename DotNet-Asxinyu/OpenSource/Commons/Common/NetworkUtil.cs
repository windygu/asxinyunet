namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public class NetworkUtil
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void BindEndPoint(Socket socket, IPEndPoint endPoint)
        {
            if (!socket.IsBound)
            {
                socket.Bind(endPoint);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void BindEndPoint(Socket socket, string ip, int port)
        {
            IPEndPoint localEP = CreateIPEndPoint(ip, port);
            if (!socket.IsBound)
            {
                socket.Bind(localEP);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Close(Socket socket)
        {
            try
            {
                socket.Shutdown(SocketShutdown.Both);
            }
            catch (SocketException exception)
            {
                throw exception;
            }
            finally
            {
                socket.Close();
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Connect(Socket socket, string ip, int port)
        {
            socket.Connect(ip, port);
            return socket.Poll(-1, SelectMode.SelectWrite);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static IPEndPoint CreateIPEndPoint(string ip, int port)
        {
            return new IPEndPoint(StringToIPAddress(ip), port);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static TcpListener CreateTcpListener()
        {
            return new TcpListener(new IPEndPoint(IPAddress.Any, 0));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static TcpListener CreateTcpListener(string ip, int port)
        {
            return new TcpListener(new IPEndPoint(StringToIPAddress(ip), port));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Socket CreateTcpSocket()
        {
            return new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Socket CreateUdpSocket()
        {
            return new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetClientIP(Socket clientSocket)
        {
            IPEndPoint remoteEndPoint = (IPEndPoint) clientSocket.RemoteEndPoint;
            return remoteEndPoint.Address.ToString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetLocalIP()
        {
            string str = string.Empty;
            IPHostEntry hostEntry = Dns.GetHostEntry(Environment.MachineName);
            if (hostEntry.AddressList.Length > 0)
            {
                str = hostEntry.AddressList[0].ToString();
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static IPEndPoint GetLocalPoint(Socket socket)
        {
            return (IPEndPoint) socket.LocalEndPoint;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static IPEndPoint GetLocalPoint(TcpListener tcpListener)
        {
            return (IPEndPoint) tcpListener.LocalEndpoint;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetLocalPoint_IP(Socket socket)
        {
            IPEndPoint localEndPoint = (IPEndPoint) socket.LocalEndPoint;
            return localEndPoint.Address.ToString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetLocalPoint_IP(TcpListener tcpListener)
        {
            IPEndPoint localEndpoint = (IPEndPoint) tcpListener.LocalEndpoint;
            return localEndpoint.Address.ToString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int GetLocalPoint_Port(Socket socket)
        {
            IPEndPoint localEndPoint = (IPEndPoint) socket.LocalEndPoint;
            return localEndPoint.Port;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int GetLocalPoint_Port(TcpListener tcpListener)
        {
            IPEndPoint localEndpoint = (IPEndPoint) tcpListener.LocalEndpoint;
            return localEndpoint.Port;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetValidIP(string ip)
        {
            if (ValidateUtil.IsValidIP(ip))
            {
                return ip;
            }
            return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4e10);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int GetValidPort(string port)
        {
            int num = -1;
            num = ConvertHelper.ConvertTo<int>(port);
            if ((num <= 0) || (num > 0xffff))
            {
                throw new ArgumentException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4e18));
            }
            return num;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsConnectedInternet()
        {
            int num = 0;
            return t00qRSolC(out num, 0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ReceiveMsg(Socket socket)
        {
            byte[] buffer = new byte[0x1388];
            int count = socket.Receive(buffer);
            byte[] dst = new byte[count];
            Buffer.BlockCopy(buffer, 0, dst, 0, count);
            return ConvertHelper.BytesToString(dst);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ReceiveMsg(Socket socket, byte[] buffer)
        {
            socket.Receive(buffer);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SendMsg(Socket socket, byte[] msg)
        {
            socket.Send(msg, msg.Length, SocketFlags.None);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SendMsg(Socket socket, string msg)
        {
            byte[] buffer = ConvertHelper.StringToBytes(msg);
            socket.Send(buffer, buffer.Length, SocketFlags.None);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void StartListen(Socket socket, int port)
        {
            IPEndPoint endPoint = CreateIPEndPoint(LocalHostName, port);
            BindEndPoint(socket, endPoint);
            socket.Listen(100);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void StartListen(Socket socket, int port, int maxConnection)
        {
            IPEndPoint endPoint = CreateIPEndPoint(LocalHostName, port);
            BindEndPoint(socket, endPoint);
            socket.Listen(maxConnection);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void StartListen(Socket socket, string ip, int port, int maxConnection)
        {
            BindEndPoint(socket, ip, port);
            socket.Listen(maxConnection);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static IPAddress StringToIPAddress(string ip)
        {
            return IPAddress.Parse(ip);
        }

        [DllImport("wininet", EntryPoint="InternetGetConnectedState")]
        private static extern bool t00qRSolC(out int, int);

        public static string LANIP
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
                if (addressList.Length < 1)
                {
                    return "";
                }
                return addressList[0].ToString();
            }
        }

        public static string LocalHostName
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return Dns.GetHostName();
            }
        }

        public static string WANIP
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
                if (addressList.Length < 2)
                {
                    return "";
                }
                return addressList[1].ToString();
            }
        }
    }
}

