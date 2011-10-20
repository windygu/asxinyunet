namespace WHC.OrderWater.Commons
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public class NetworkUtil
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public NetworkUtil()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void BindEndPoint(Socket socket, IPEndPoint endPoint)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void BindEndPoint(Socket socket, string ip, int port)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Close(Socket socket)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Connect(Socket socket, string ip, int port)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static IPEndPoint CreateIPEndPoint(string ip, int port)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static TcpListener CreateTcpListener()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static TcpListener CreateTcpListener(string ip, int port)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Socket CreateTcpSocket()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Socket CreateUdpSocket()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetClientIP(Socket clientSocket)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetLocalIP()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static IPEndPoint GetLocalPoint(Socket socket)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static IPEndPoint GetLocalPoint(TcpListener tcpListener)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetLocalPoint_IP(Socket socket)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetLocalPoint_IP(TcpListener tcpListener)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int GetLocalPoint_Port(Socket socket)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int GetLocalPoint_Port(TcpListener tcpListener)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetValidIP(string ip)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int GetValidPort(string port)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsConnectedInternet()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ReceiveMsg(Socket socket)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ReceiveMsg(Socket socket, byte[] buffer)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SendMsg(Socket socket, byte[] msg)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SendMsg(Socket socket, string msg)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void StartListen(Socket socket, int port)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void StartListen(Socket socket, int port, int maxConnection)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void StartListen(Socket socket, string ip, int port, int maxConnection)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static IPAddress StringToIPAddress(string ip)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [DllImport("wininet", EntryPoint="InternetGetConnectedState")]
        private static extern bool t00qRSolC(out int, int);

        public static string LANIP
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        public static string LocalHostName
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        public static string WANIP
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }
    }
}
