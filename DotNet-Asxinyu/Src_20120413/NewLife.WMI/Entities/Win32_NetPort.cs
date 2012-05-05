using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace NewLife.WMI.Entities
{
    /// <summary>
    /// 通过客户端netstat获取开放端口
    /// 需要将psexec工具放在服务器系统目录下
    /// </summary>
    public class Win32_NetPort
    {
        public static Win32_NetPort[] GetWin32_NetPort(string serverName)
        {
            ArrayList result = new ArrayList();
            string temp = string.Empty;
            string tcpreg = @"[\s]+TCP[\s]+[\d]+\.[\d]+\.[\d]+\.[\d]+:[\d]+[\s]+[\d]+\.[\d]+\.[\d]+\.[\d]+:[\d]+[\s]+LISTENING";
            string udpreg = @"[\s]+UDP[\s]+[\d]+\.[\d]+\.[\d]+\.[\d]+:[\d]+[\s]+\*:\*";

            string outstr = GetClientCMDOutput(serverName);
            if (outstr.IndexOf("error", StringComparison.OrdinalIgnoreCase) > -1)
            {
                outstr = GetClientCMDOutput(serverName);
            }
            if (string.IsNullOrEmpty(outstr))
            {

            }
            string[] outstrsplit = outstr.Split('\n');

            foreach (string curline in outstrsplit)
            {
                if ((new Regex(tcpreg).Match(curline).Success) || (new Regex(udpreg).Match(curline).Success))
                {
                    result.Add(Win32_NetPort.Parse(curline));
                }
            }

            return (Win32_NetPort[])result.ToArray(typeof(Win32_NetPort));
        }

        private static Win32_NetPort Parse(string str)
        {
            Win32_NetPort result = new Win32_NetPort();

            if (str.IndexOf("TCP", StringComparison.OrdinalIgnoreCase) > -1)
            {
                result.porttype = PortType.TCP;
            }
            if (str.IndexOf("UDP", StringComparison.OrdinalIgnoreCase) > -1)
            {
                result.porttype = PortType.UDP;
            }

            str = str.Trim();
            while (str.IndexOf("  ") > -1)
            {
                str = str.Replace("  ", " ");
            }

            result.ipaddress = str.Split(' ')[1].Split(':')[0];
            result.port = Convert.ToInt32(str.Split(' ')[1].Split(':')[1]);

            return result;
        }

        /// <summary>获取客户端netstat命令数据</summary>>
        /// <param name="serverName"></param>
        /// <returns></returns>
        //private static string GetClientCMDOutput(string serverName)
        //{
        //    Process process = new Process();
        //    Process process1 = new Process();
        //    string outstr = string.Empty;

        //    if (System.Net.Dns.GetHostByName(serverName).AddressList[0].ToString() == System.Net.Dns.GetHostAddresses(Environment.MachineName)[0].ToString())
        //    {
        //        process.StartInfo.FileName = "netstat";
        //        process.StartInfo.Arguments = "-an";
        //        process.StartInfo.UseShellExecute = false;
        //        process.StartInfo.RedirectStandardOutput = true;
        //        process.Start();
        //        outstr = process.StandardOutput.ReadToEnd();
        //    }
        //    else
        //    {
        //        process.StartInfo.FileName = "psexec";
        //        process.StartInfo.Arguments = "\\\\" + serverName + " -n 5 netstat -an";
        //        process.StartInfo.RedirectStandardOutput = true;
        //        process.StartInfo.RedirectStandardInput = false;
        //        process.StartInfo.RedirectStandardError = false;
        //        process.StartInfo.UseShellExecute = false;

        //        process.Start();
        //        outstr = process.StandardOutput.ReadToEnd();

        //        process.Close();
        //    }

        //    return outstr;
        //}

        private static string GetClientCMDOutput(string serverName)
        {
            Process process = new Process();
            Process process1 = new Process();
            string outstr = string.Empty;

            //if (System.Net.Dns.GetHostByName(serverName).AddressList[0].ToString() == System.Net.Dns.GetHostAddresses(Environment.MachineName)[0].ToString())
            if (System.Net.Dns.GetHostEntry(serverName).AddressList[0].ToString() == System.Net.Dns.GetHostAddresses(Environment.MachineName)[0].ToString())
            {
                process.StartInfo.FileName = "netstat";
                process.StartInfo.Arguments = "-an";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();
                outstr = process.StandardOutput.ReadToEnd();
            }
            else
            {
                process.StartInfo.FileName = "psexec";
                process.StartInfo.Arguments = "\\\\" + serverName + " -f -c " + GetToolsPath() + "remote.exe -s \"cmd\" psajt";
                process.Start();
                System.Threading.Thread.Sleep(3000);

                process1.StartInfo.FileName = "remote";
                process1.StartInfo.Arguments = "-c " + serverName + " psajt";
                process1.StartInfo.RedirectStandardOutput = true;
                process1.StartInfo.RedirectStandardInput = true;
                process1.StartInfo.RedirectStandardError = false;
                process1.StartInfo.UseShellExecute = false;
                process1.Start();
                process1.StandardInput.WriteLine("netstat -an -p TCP | find /i \"LISTENING\"");
                process1.StandardInput.WriteLine("netstat -an -p UDP");
                process1.StandardInput.WriteLine("exit");
                outstr = process1.StandardOutput.ReadToEnd();

                process1.Close();
                process.Close();
            }

            return outstr;
        }

        /// <summary>获取工具软件存放的目录</summary>>
        /// <returns></returns>
        private static string GetToolsPath()
        {
            //string result = new Page().Page.Server.MapPath(".") + "\\..\\..\\Tools\\";
            string result = "\\..\\..\\Tools\\";

            return result;
        }

        /// <summary>通过端口号获取端口对应服务名</summary>>
        /// <param name="port"></param>
        /// <returns></returns>
        public static string GetPortName(int port, PortType portType)
        {
            string result = string.Empty;
            string findport = port.ToString();
            int rowcount = 0;

            switch (portType)
            {
                case PortType.TCP:
                    {
                        rowcount = WMIConst.TcpPortName.GetLength(0);
                        for (int i = 0; i < rowcount; i++)
                        {
                            if (WMIConst.TcpPortName[i, 0] == findport)
                            {
                                result = WMIConst.TcpPortName[i, 1];
                                break;
                            }
                        }
                    }
                    break;
                case PortType.UDP:
                    {
                        rowcount = WMIConst.UdpPortName.GetLength(0);
                        for (int i = 0; i < rowcount; i++)
                        {
                            if (WMIConst.UdpPortName[i, 0] == findport)
                            {
                                result = WMIConst.UdpPortName[i, 1];
                                break;
                            }
                        }
                    }
                    break;
            }


            return result;
        }

        private PortType _porttype = PortType.NONE;
        /// <summary>端口类型</summary>>
        public PortType porttype
        {
            set { _porttype = value; }
            get { return _porttype; }
        }

        private string _ipaddress = string.Empty;
        /// <summary>端口所属ip</summary>>
        public string ipaddress
        {
            set { _ipaddress = value; }
            get { return _ipaddress; }
        }

        private int _port = -1;
        /// <summary>端口号</summary>>
        public int port
        {
            set { _port = value; }
            get { return _port; }
        }

        private string _servername = string.Empty;
        /// <summary>端口默认服务</summary>>
        public string servername
        {
            get
            {
                if ((_port > 0) && (_porttype != PortType.NONE))
                {
                    return GetPortName(_port, _porttype);
                }
                else
                {
                    return null;
                }
            }
        }
    }


    /// <summary>主机TCP端口扫描类</summary>>
    public class ScanPort
    {
        //最大工作线程数
        public int maxThread = 500;

        public List<int> Start(string host, int startPort, int endPort)
        {
            List<Scanner> Scanners = new List<Scanner>();
            List<int> result = new List<int>();
            for (int port = startPort; port <= endPort; port++)
            {
                Scanner scanner = new Scanner(host, port);
                Thread thread = new Thread(new ThreadStart(scanner.Scan));
                thread.Name = port.ToString();
                thread.IsBackground = true;
                thread.Start();

                Scanners.Add(scanner);

                Thread.Sleep(10);

                while (GetRunning(Scanners) >= maxThread)
                {
                    Thread.Sleep(1000);
                }
            }

            for (int i = 0; i < Scanners.Count; i++)
            {
                if (Scanners[i].tcpStatus == 1)
                {
                    result.Add(Scanners[i].portName);
                }
            }

            return result;
        }

        int GetRunning(List<Scanner> scanners)
        {
            int running = 0;
            foreach (Scanner item in scanners)
            {
                if (!item.stop)
                {
                    running++;
                }
            }

            return running;
        }
    }

    class Scanner
    {
        string m_host;
        int m_port;
        public int tcpStatus = 0;
        public bool stop = false;
        public int portName = 0;

        public Scanner(string host, int port)
        {
            m_host = host; m_port = port;
            portName = port;
        }

        public void Scan()
        {
            TcpClient tc = new TcpClient();
            tc.ReceiveTimeout = 2000;
            tc.SendTimeout = tc.ReceiveTimeout;
            try
            {
                tc.Connect(m_host, m_port);
                if (tc.Connected)
                {
                    tcpStatus = 1;
                }
            }
            catch
            {
            }
            finally
            {
                tc.Close();
                tc = null;
                stop = true;
            }
        }
    }

    public class Port
    {
        private PortType _type = PortType.NONE;
        /// <summary>端口类型</summary>>
        public PortType type
        {
            get { return _type; }
            set { _type = value; }
        }

        private int _name = 0;
        /// <summary>端口号</summary>>
        public int name
        {
            get { return _name; }
            set { _name = value; }
        }
    }

    /// <summary>端口类型枚举</summary>>
    public enum PortType
    {
        NONE = 0,
        TCP = 1,
        UDP = 2
    }
}
