using System.Collections;
using System.Collections.Generic;
using System.Management;
using NewLife.WMI.Entities;

namespace NewLife.WMI
{
    /// <summary>WMI工厂类</summary>>
    public class WMIFactory
    {
        /// <summary>根据计算机名获取Win32_PingStatus</summary>>
        /// <param name="computerName">计算机名</param>
        /// <returns></returns>
        public static Win32_PingStatus GetWin32_PingStatus(string computerName)
        {
            string query = "SELECT * FROM " + WMIConst.Win32_PingStatus + " WHERE Address='" + computerName + "'";

            WMIProvider wmiProvider = new WMIProvider(".");
            ManagementObject mo = wmiProvider.GetManagementObject(query)[0];
            Win32_PingStatus pingStatus = new Win32_PingStatus(mo);

            return pingStatus;
        }

        /// <summary>根据计算机名获取NetworkAdapter</summary>>
        /// <param name="computerName">计算机名</param>
        /// <param name="all">获取所有NetworkAdapter</param>
        /// <returns></returns>
        public static Win32_NetworkAdapter[] GetWin32_NetworkAdapters(string computerName, bool allAdapter)
        {
            string query = "SELECT * FROM " + WMIConst.Win32_NetworkAdapter;

            WMIProvider wmiProvider = new WMIProvider(computerName);
            ManagementObject[] mos = wmiProvider.GetManagementObject(query);
            ArrayList arrayList = new ArrayList();

            if (mos.Length > 0)
            {
                for (int i = 0; i < mos.Length; i++)
                {
                    Win32_NetworkAdapter na = new Win32_NetworkAdapter(mos[i]);
                    if (allAdapter == false)
                    {
                        if (na.MACAddress != "" && na.AdapterTypeID == AdapterType.Ethernet8023 && na.NetConnectionID != "")
                        {
                            arrayList.Add(na);
                        }
                    }
                    else
                    {
                        arrayList.Add(na);
                    }
                }
            }

            return (Win32_NetworkAdapter[])arrayList.ToArray(typeof(Win32_NetworkAdapter));
        }

        /// <summary>根据计算机名获取有效NetworkAdapter</summary>>
        /// <param name="computerName">计算机名</param>
        /// <returns></returns>
        public static Win32_NetworkAdapter[] GetWin32_NetworkAdapters(string computerName)
        {
            return GetWin32_NetworkAdapters(computerName, false);
        }

        /// <summary>根据计算机获取Win32_Process</summary>>
        /// <param name="computerName"></param>
        /// <returns></returns>
        public static Win32_Process GetWin32_Process(string computerName)
        {
            WMIProvider wmiProvider = new WMIProvider("devsvr");
            wmiProvider.Connect();
            ManagementClass managementClass = wmiProvider.GetManagementClass("Win32_Process");

            return new Win32_Process(managementClass);
        }
        
        /// <summary>获取远程计算机服务集合</summary>>
        /// <param name="computerName"></param>
        /// <returns></returns>
        public static Win32_Services[] GetWin32_Services(string computerName)
        {
            string query = "SELECT * FROM Win32_Service";

            WMIProvider wmiProvider = new WMIProvider(computerName);
            wmiProvider.Connect();
            ManagementObject[] mo = wmiProvider.GetManagementObject(query);

            return new Win32_Services().GetWin32_Services(mo);
        }

        /// <summary>获取远程计算机共享集合</summary>>
        /// <param name="computerName"></param>
        /// <returns></returns>
        public static Win32_Share[] GetWin32_Share(string computerName)
        {
            string query = "SELECT * FROM Win32_Share";

            WMIProvider wmiProvider = new WMIProvider(computerName);
            wmiProvider.Connect();
            ManagementObject[] mo = wmiProvider.GetManagementObject(query);

            return new Win32_Share().GetWin32_Share(mo);
        }

        /// <summary>获取远程计算机开放的端口</summary>>
        /// <param name="computerName"></param>
        /// <returns></returns>
        public static Win32_NetPort[] GetWin32_NetPort(string computerName)
        {
            return Win32_NetPort.GetWin32_NetPort(computerName);
        }

        /// <summary>扫描远程计算机开放的tcp端口</summary>>
        /// <param name="host"></param>
        /// <param name="startPort"></param>
        /// <param name="endPort"></param>
        /// <returns></returns>
        public static int[] ScanNetPort(string host, int startPort, int endPort)
        {
            List<int> result = new ScanPort().Start(host, startPort, endPort);
            
            return result.ToArray();
        }

        public static uint RemoteExec(string computerName, string currentDirecotry, string commandLine)
        {
            uint processId = (uint)0;

            Win32_Process.RemoteExec(computerName, commandLine, currentDirecotry, ref processId);

            return processId;
        }
    }
}
