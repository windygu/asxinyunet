using System;
using System.Collections.Generic;
using System.Text;
using NewLife.WMI;
using NewLife.WMI.Entities;

namespace NewLife.WMI
{
    public static class WMIHelper
    {
        /// <summary>判断计算机是否处于联机状态</summary>>
        /// <param name="computerName">计算机名或IP地址</param>
        /// <returns></returns>
        public static bool IsComputerOnline(string computerName)
        {
            bool pingSucced = false;

            Win32_PingStatus pingStatus = WMIFactory.GetWin32_PingStatus(computerName);

            if (pingStatus.StatusCode == StatusCodeType.Success)
            {
                pingSucced = true;
            }

            return pingSucced;
        }
    }
}
