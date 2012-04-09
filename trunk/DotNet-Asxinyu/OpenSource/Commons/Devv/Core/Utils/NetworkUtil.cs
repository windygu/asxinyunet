namespace Devv.Core.Utils
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Net.NetworkInformation;

    public class NetworkUtil
    {
        private NetworkUtil()
        {
        }

        public static bool IsConnected()
        {
            return IsConnected("google.com");
        }

        public static bool IsConnected(string ip)
        {
            try
            {
                using (System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping())
                {
                    if (ping.Send(ip, 0xbb8).Status == IPStatus.Success)
                    {
                        return true;
                    }
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                ProjectData.ClearProjectError();
                return false;
            }
            return false;
        }

        public static long Ping(string strHost)
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            return ping.Send(strHost).RoundtripTime;
        }
    }
}
