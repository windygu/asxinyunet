using System;
using System.Collections;
using System.Management;

namespace NewLife.WMI
{
    /// <summary>WMI操作类</summary>>
    public class WMIProvider
    {
        private string _serverName;
        private string _userName;
        private string _userPassword;
        private string _path;
        private string _wmiClassName;
        private ConnectionOptions _connOptions;
        private ManagementScope _mngScope;

        /// <summary>构造函数</summary>>
        /// <param name="serverName">服务器名称</param>
        public WMIProvider(string serverName)
        {
            this._serverName = serverName;
        }

        /// <summary>构造函数</summary>>
        /// <param name="serverName">服务器名称</param>
        /// <param name="userName">用户名</param>
        /// <param name="userPassword">用户密码</param>
        public WMIProvider(string serverName, string userName, string userPassword)
        {
            this._serverName = serverName;
            this._userName = userName;
            this._userPassword = userPassword;
        }

        /// <summary>WMI连接</summary>>
        public void Connect()
        {
            _connOptions = new ConnectionOptions();

            if (String.IsNullOrEmpty(this._userName) && String.IsNullOrEmpty(this._userPassword))
            {
                _connOptions.Impersonation = ImpersonationLevel.Impersonate;
                _connOptions.Authentication = AuthenticationLevel.Packet;
            }
            else
            {
                _connOptions.Username = _userName;
                _connOptions.Password = _userPassword;
            }

            _path = @"\\" + _serverName + @"\" + WMIConst.WMIROOT + @"\" + this.WMIClassName;
            _mngScope = new ManagementScope(_path, _connOptions);

            try
            {
                _mngScope.Connect();
            }
            catch (Exception e)
            {
                throw new Exception("[WMI]连接" + _serverName + "错误：" + e.Message, e);
            }
        }

        /// <summary>根据查询条件获取ManagementObject集合</summary>>
        /// <param name="query">查询语句</param>
        /// <returns></returns>
        public ManagementObject[] GetManagementObject(string query)
        {
            //WMI连接
            this.Connect();

            ManagementObjectSearcher moSearcher = new ManagementObjectSearcher(query);
            moSearcher.Scope = _mngScope;

            ManagementObjectCollection moc = moSearcher.Get();
            ArrayList arrayList = new ArrayList();
            foreach (ManagementObject mo in moc)
            {
                arrayList.Add(mo);
            }

            return (ManagementObject[])arrayList.ToArray(typeof(ManagementObject));
        }

        /// <summary>根据WMI名称以及条件获取ManagementObject集合</summary>>
        /// <param name="wmiName"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public ManagementObject[] GetManagementObject(string wmiName,string filter)
        {
            string query = "SELECT * FROM " + wmiName;
            if (String.IsNullOrEmpty(filter) == false)
            {
                query += " WHERE " + filter;
            }

            return this.GetManagementObject(query);
        }

        /// <summary>根据WMI名称获取ManagementObject集合</summary>>
        /// <param name="wmiName"></param>
        /// <returns></returns>
        public ManagementObject[] GetManagementObjectByName(string wmiName)
        {
            return this.GetManagementObject(wmiName,String.Empty);
        }

        /// <summary>获取GetManagementClass</summary>>
        /// <param name="className">className</param>
        /// <returns></returns>
        public ManagementClass GetManagementClass(string className)
        {
            this.Connect();

            ManagementPath managementPath = new ManagementPath(className);
            ManagementClass managementClass = new ManagementClass(this._mngScope, managementPath, null);

            return managementClass;
        }

        /// <summary>根据查询条件获取ManagementObject</summary>>
        /// <param name="query"></param>
        /// <returns></returns>
        public ManagementObject GetManagementObjectByQuery(string query)
        {
            this.Connect();

            ManagementObject classInstance =
                    new ManagementObject(this._mngScope,
                    new ManagementPath(query),
                    null);

            return classInstance;
        }

        /// <summary>服务器名称</summary>>
        public string ServerName
        {
            get { return this._serverName; }
        }

        /// <summary>连接用户</summary>>
        public string UserName
        {
            get { return this._userName; }
        }

        /// <summary>连接用户密码</summary>>
        public string UserPassword
        {
            get { return this._userPassword; }
        }

        /// <summary>WMI类名称</summary>>
        public string WMIClassName
        {
            get
            {
                if (this._wmiClassName == null)
                {
                    this._wmiClassName = WMIConst.CIMV2;
                }

                return this._wmiClassName;
            }

            set { this._wmiClassName = value; }
        }

        /// <summary>WMI对象路径</summary>>
        public string Path
        {
            get { return this._path; }
        }
    }
}