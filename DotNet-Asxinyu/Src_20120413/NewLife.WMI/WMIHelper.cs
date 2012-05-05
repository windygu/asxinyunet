using System;
using System.Collections.Generic;
using System.Text;
using NewLife.WMI;
using NewLife.WMI.Entities;

namespace NewLife.WMI
{
    public static class WMIHelper
    {
        /// <summary>�жϼ�����Ƿ�������״̬</summary>>
        /// <param name="computerName">���������IP��ַ</param>
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
