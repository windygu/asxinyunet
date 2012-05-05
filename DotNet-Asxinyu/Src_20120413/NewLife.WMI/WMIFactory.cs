using System.Collections;
using System.Collections.Generic;
using System.Management;
using NewLife.WMI.Entities;

namespace NewLife.WMI
{
    /// <summary>WMI������</summary>>
    public class WMIFactory
    {
        /// <summary>���ݼ��������ȡWin32_PingStatus</summary>>
        /// <param name="computerName">�������</param>
        /// <returns></returns>
        public static Win32_PingStatus GetWin32_PingStatus(string computerName)
        {
            string query = "SELECT * FROM " + WMIConst.Win32_PingStatus + " WHERE Address='" + computerName + "'";

            WMIProvider wmiProvider = new WMIProvider(".");
            ManagementObject mo = wmiProvider.GetManagementObject(query)[0];
            Win32_PingStatus pingStatus = new Win32_PingStatus(mo);

            return pingStatus;
        }

        /// <summary>���ݼ��������ȡNetworkAdapter</summary>>
        /// <param name="computerName">�������</param>
        /// <param name="all">��ȡ����NetworkAdapter</param>
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

        /// <summary>���ݼ��������ȡ��ЧNetworkAdapter</summary>>
        /// <param name="computerName">�������</param>
        /// <returns></returns>
        public static Win32_NetworkAdapter[] GetWin32_NetworkAdapters(string computerName)
        {
            return GetWin32_NetworkAdapters(computerName, false);
        }

        /// <summary>���ݼ������ȡWin32_Process</summary>>
        /// <param name="computerName"></param>
        /// <returns></returns>
        public static Win32_Process GetWin32_Process(string computerName)
        {
            WMIProvider wmiProvider = new WMIProvider("devsvr");
            wmiProvider.Connect();
            ManagementClass managementClass = wmiProvider.GetManagementClass("Win32_Process");

            return new Win32_Process(managementClass);
        }
        
        /// <summary>��ȡԶ�̼�������񼯺�</summary>>
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

        /// <summary>��ȡԶ�̼����������</summary>>
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

        /// <summary>��ȡԶ�̼�������ŵĶ˿�</summary>>
        /// <param name="computerName"></param>
        /// <returns></returns>
        public static Win32_NetPort[] GetWin32_NetPort(string computerName)
        {
            return Win32_NetPort.GetWin32_NetPort(computerName);
        }

        /// <summary>ɨ��Զ�̼�������ŵ�tcp�˿�</summary>>
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
