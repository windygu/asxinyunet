using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using NewLife.WMI.Entities;

namespace NewLife.WMI
{
    /// <summary>事务日志管理类</summary>>
    public class EventLogManager
    {
        //打印事务日志Code，默认为10
        private const int PrintEventCode = 10;
        private const int FileEventCode = 560;

        private string _serverName;
        private string _userName;
        private string _userPassword;
        private WMIProvider _wmiProvider;

        #region 构造函数
        /// <summary>构造函数</summary>>
        /// <param name="serverName">服务器名称</param>
        public EventLogManager(string serverName)
        {
            this._serverName = serverName;
            this.EventLogManager_Init();
        }

        /// <summary>构造函数</summary>>
        /// <param name="serverName">服务器名称</param>
        /// <param name="userName">用户名</param>
        /// <param name="userPassword">用户密码</param>
        public EventLogManager(string serverName,string userName,string userPassword)
        {
            this._serverName = serverName;
            this._userName = userName;
            this._userPassword = userPassword;
            this.EventLogManager_Init();
        }

        private void EventLogManager_Init()
        {
            if (String.IsNullOrEmpty(_userName) && String.IsNullOrEmpty(_userPassword))
            {
                _wmiProvider = new WMIProvider(_serverName);
            }
            else
            {
                _wmiProvider = new WMIProvider(_serverName, _userName, _userPassword);
            }

            //WMI连接
            _wmiProvider.Connect();
        }
        #endregion

        #region 根据查询语句获取事务日志对象
        /// <summary>根据查询语句获取事务日志对象</summary>>
        /// <param name="condClause">查询语句</param>
        /// <remarks>比如：Logfile = 'System' AND EventCode='7035'</remarks>
        /// <returns></returns>
        public Win32_NTLogEvent[] GetWin32_NTLogEvents(string condClause)
        {
            string sql = "SELECT * FROM " + WMIConst.Win32_NTLogEvent;

            if (condClause.Length > 0)
            {
                sql += " WHERE " + condClause;
            }

            ManagementObject[] mos = _wmiProvider.GetManagementObject(sql);
            
            Win32_NTLogEvent[] logEvents = new Win32_NTLogEvent[mos.Length];
            int index = 0;
            for (int i = mos.Length-1; i >= 0; i--)
            {
                logEvents[index] = new Win32_NTLogEvent(mos[i]);
                index++;
            }

            return logEvents;
        }
        #endregion

        #region 获取打印日志对象
        /// <summary>获取打印日志对象</summary>>
        /// <returns></returns>
        public Win32_NTLogEvent[] GetPrintLogEvents(DateTime dateTime)
        {
            string condClause = "Logfile = 'System' AND EventCode='" + PrintEventCode + "'";
            condClause += " AND TimeWritten>='" + dateTime.ToString() + "'";

            return GetWin32_NTLogEvents(condClause);
        }

        public Win32_NTLogEvent[] GetPrintLogEvents()
        {
            string condClause = "Logfile = 'System' AND EventCode='" + PrintEventCode + "'";
            //condClause += " ORDER BY TimeWritten ASC";

            return GetWin32_NTLogEvents(condClause);
        }
        #endregion

        #region 获取文件访问日志
        /// <summary>获取文件访问日志</summary>>
        /// <param name="path">路径</param>
        /// <param name="date">起始时间</param>
        /// <returns></returns>
        public Win32_NTLogEvent[] GetEvents(string path, DateTime dateTime)
        {
            path = path.Replace(@"\", @"\\");

            string where = string.Format(" Logfile = 'Security' and EventCode='{0}' and Message like '%{1}%' and TimeWritten > '{2}'"
                , FileEventCode
                , path
                , dateTime.ToUniversalTime());
            Win32_NTLogEvent[] events = GetWin32_NTLogEvents(where);

            return events;
        }

        #endregion

        #region 日志处理

        /// <summary>备份事务日志</summary>>
        /// <param name="logFileName">日志文件名，</param>
        /// <param name="path">备份路径，如：d:\back</param>
        public void BackupEventlog(EventLogFileType eventLogFileType, string path)
        {
            #region 注释代码
            /*
            if (path.Length == 0) path = new ITServiceConfig.PrintConfig().PrintBackupEventLogFilePath;
            if (path.EndsWith(@"\")) path = path.Substring(0, path.Length - 1);

            ManagementObject mngObject = GetWin32_NTEventlogFile();
            //object[] methodArgs = new object[] { @"c:\eventlog.evt" };
            ManagementClass mngClass = _wmiProvider.GetManagementClass("Win32_NTEventlogFile");
            ManagementBaseObject inParams = mngClass.GetMethodParameters("BackupEventlog");
            inParams["ArchiveFileName"] = path + @"\" + this.BackupLogFileName() + "(System).evt";

            try
            {
                //mngObject.InvokeMethod("BackupEventlog", methodArgs);
                mngObject.InvokeMethod("BackupEventlog",inParams,null);
            }
            catch (Exception e)
            {
                throw new ITServiceException(ErrorNumber.EventLogError, "备份事务日志错误：" + e.Message, e);
            }
            */
            #endregion

            if (path.EndsWith(@"\"))
            {
                path = path.Substring(0, path.Length - 1);
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string backFileName = path + @"\" + this.BackupLogFileName() + "(" + eventLogFileType.ToString() + ").evt";

            int eventHandle = OpenEventLogA(this._serverName, eventLogFileType.ToString());
            BackupEventLogA(eventHandle, backFileName);
        }

        /// <summary>清除事务日志</summary>>
        public void ClearEventLog(EventLogFileType eventLogFileType)
        {
            ManagementObject mngObject = GetWin32_NTEventlogFile(eventLogFileType);

            try
            {
                mngObject.InvokeMethod("ClearEventLog", null);
            }
            catch (Exception e)
            {
                throw new System.ApplicationException("清除事务日志错误:" + e.Message);
            }
        }

        #endregion

        #region 私有函数

        private ManagementObject GetWin32_NTEventlogFile(EventLogFileType eventLogFileType)
        {
            string sql = string.Format("SELECT * FROM {0} WHERE LogFileName='{1}'", WMIConst.Win32_NTEventlogFile, eventLogFileType.ToString());
            ManagementObject mngObject = _wmiProvider.GetManagementObject(sql)[0];

            return mngObject;
        }

        /// <summary>获取备份日志的文件名</summary>>
        /// <returns></returns>
        private string BackupLogFileName()
        {
            DateTime nowTime = DateTime.Now;

            string year, month, day, hour, minute, second;
            year = nowTime.Year.ToString();
            month = nowTime.Month >= 10 ? nowTime.Month.ToString() : "0" + nowTime.Month.ToString();
            day = nowTime.Day >= 10 ? nowTime.Day.ToString() : "0" + nowTime.Day.ToString();
            hour = nowTime.Hour >= 10 ? nowTime.Hour.ToString() : "0" + nowTime.Hour.ToString();
            minute = nowTime.Minute >= 10 ? nowTime.Minute.ToString() : "0" + nowTime.Minute.ToString();
            second = nowTime.Second >= 10 ? nowTime.Second.ToString() : "0" + nowTime.Second.ToString();

            return year + month + day + hour + minute + second;
        }


        #endregion

        #region 备份日志 DLL引入
        /// <summary>事务日志备份</summary>>
        /// <param name="hEventLog"></param>
        /// <param name="lpBackupFileName"></param>
        /// <returns></returns>
        [DllImport("advapi32.dll", EntryPoint = "BackupEventLog")]
        public static extern int BackupEventLogA(int hEventLog, string lpBackupFileName);

        /// <summary>打开事务日志</summary>>
        /// <param name="lpUNCServerName"></param>
        /// <param name="lpSourceName"></param>
        /// <returns></returns>
        [DllImport("advapi32.dll", EntryPoint = "OpenEventLog")]
        public static extern int OpenEventLogA(string lpUNCServerName, string lpSourceName);

        #endregion
    }
}
