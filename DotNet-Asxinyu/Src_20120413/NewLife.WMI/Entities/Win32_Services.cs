using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Management;

namespace NewLife.WMI.Entities
{
    /// <summary>服务启动方式</summary>>
    public enum ServicesStartMode
    {
        None        = -1,
        Auto        = 0,    //自动
        Manual      = 1,    //手动
        Disabled    = 2     //禁用
    }

    /// <summary>服务状态</summary>>
    public enum ServicesState
    {
        None            = -1,
        Running         = 0,    //运行
        Stopped         = 1,    //停止
        Paused          = 2,    //暂停
        PausePending    = 3,   //正在暂停
        StopPending     = 4,   //正在停止
    }

    public class Win32_Services
    {

        public Win32_Services[] GetWin32_Services(ManagementObject[] mo)
        {
            ArrayList result = new ArrayList();
            foreach (ManagementObject item in mo)
            {
                Win32_Services services = new Win32_Services();
                services._AcceptPause = Convert.ToBoolean(item.Properties["AcceptPause"].Value);
                services._AcceptStop = Convert.ToBoolean(item.Properties["AcceptStop"].Value);
                services._Caption = item.Properties["AcceptStop"].Value.ToString();
                services._CheckPoint = Convert.ToInt32(item.Properties["CheckPoint"].Value);
                services._CreationClassName = item.Properties["CreationClassName"].Value.ToString();
                services._Description = Convert.ToString(item.Properties["Description"].Value);
                services._DesktopInteract = Convert.ToBoolean(item.Properties["DesktopInteract"].Value);
                services._DisplayName = Convert.ToString(item.Properties["DisplayName"].Value);
                services._ErrorControl = Convert.ToString(item.Properties["ErrorControl"].Value);
                services._ExitCode = Convert.ToInt32(item.Properties["ExitCode"].Value);
                services._Name = Convert.ToString(item.Properties["Name"].Value);
                services._PathName = Convert.ToString(item.Properties["PathName"].Value);
                services._ProcessId = Convert.ToInt32(item.Properties["ProcessId"].Value);
                services._ServiceSpecificExitCode = Convert.ToInt32(item.Properties["ServiceSpecificExitCode"].Value);
                services._ServiceType = Convert.ToString(item.Properties["ServiceType"].Value);
                services._Started = Convert.ToBoolean(item.Properties["Started"].Value);
                services._StartMode = Convert.ToString(item.Properties["StartMode"].Value);
                services._StartName = Convert.ToString(item.Properties["StartName"].Value);
                services._State = Convert.ToString(item.Properties["State"].Value);
                services._Status = Convert.ToString(item.Properties["Status"].Value);
                services._SystemCreationClassName = Convert.ToString(item.Properties["SystemCreationClassName"].Value);
                services._SystemName = Convert.ToString(item.Properties["SystemName"].Value);
                services._TagId = Convert.ToInt32(item.Properties["TagId"].Value);
                services._WaitHint = Convert.ToInt32(item.Properties["WaitHint"].Value);

                result.Add(services);
            }

            return (Win32_Services[])result.ToArray(typeof(Win32_Services));
        }

        private bool _AcceptPause = false;
        /// <summary>服务是否允许暂停</summary>>
        public bool AcceptPause
        {
            set{_AcceptPause = value;}
            get{return _AcceptPause;}
        }

        private bool _AcceptStop = false;
                /// <summary>服务是否允许停止</summary>>
        public bool AcceptStop
        {
            set{_AcceptStop = value;}
            get{return _AcceptStop;}
        }

        private string _Caption = string.Empty;
        /// <summary>服务标题</summary>>
        public string Caption
        {
            set{_Caption = value;}
            get{return _Caption;}
        }

        private int _CheckPoint = 0;
        /// <summary>检查点</summary>>
        public int CheckPoint
        {
            set{_CheckPoint = value;}
            get{return _CheckPoint;}
        }

        private string _CreationClassName = string.Empty;
        /// <summary>CreationClassName</summary>>
        public string CreationClassName
        {
            set{ _CreationClassName = value; }
            get{ return _CreationClassName; }
        }

        private string _Description = string.Empty;
        /// <summary>描述</summary>>
        public string Description
        {
            set { _Description = value; }
            get { return _Description; }
        }

        private bool _DesktopInteract = false;
        /// <summary>允许服务与桌面交互</summary>>
        public bool DesktopInteract
        {
            set { _DesktopInteract = value; }
            get { return _DesktopInteract; }
        }

        private string _DisplayName = string.Empty;
        /// <summary>显示名称</summary>>
        public string DisplayName
        {
            set { _DisplayName = value; }
            get { return _DisplayName; }
        }

        private string _ErrorControl = string.Empty;
        /// <summary>错误控制 Normal,Ignore</summary>>
        public string ErrorControl
        {
            set { _ErrorControl = value; }
            get { return _ErrorControl; }
        }

        private int _ExitCode = 0;
        /// <summary>返回码</summary>>
        public int ExitCode
        {
            set { _ExitCode = value; }
            get { return _ExitCode; }
        }

        private string _Name = string.Empty;
        /// <summary>服务名称</summary>>
        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }

        private string _PathName = string.Empty;
        /// <summary>服务程序路径</summary>>
        public string PathName
        {
            set { _PathName = value; }
            get { return _PathName; }
        }

        private int _ProcessId = -1;
        /// <summary>服务进程ID</summary>>
        public int ProcessId
        {
            set { _ProcessId = value; }
            get { return _ProcessId; }
        }

        private int _ServiceSpecificExitCode = 0;
        /// <summary>ServiceSpecificExitCode</summary>>
        public int ServiceSpecificExitCode
        {
            set { _ServiceSpecificExitCode = value; }
            get { return _ServiceSpecificExitCode; }
        }

        private string _ServiceType = string.Empty;
        /// <summary>服务类型</summary>>
        public string ServiceType
        {
            set { _ServiceType = value; }
            get { return _ServiceType; }
        }

        private bool _Started = false;
        /// <summary>服务是否已启动</summary>>
        public bool Started
        {
            set { _Started = value; }
            get { return _Started; }
        }

        private string _StartMode = string.Empty;
        /// <summary>启动方式</summary>>
        public ServicesStartMode StartMod
        {
            set 
            {
                switch (value)
                {
                    case ServicesStartMode.Auto :
                        _StartMode = "Auto";
                        break;
                    case ServicesStartMode.Manual:
                        _StartMode = "Manual";
                        break;
                    case ServicesStartMode.Disabled:
                        _StartMode = "Disabled";
                        break;
                }
            }
            get 
            {
                ServicesStartMode result = ServicesStartMode.None;

                switch (_StartMode)
                {
                    case "Auto":
                        result = ServicesStartMode.Auto;
                        break;
                    case "Manual":
                        result = ServicesStartMode.Manual;
                        break;
                    case "Disabled":
                        result = ServicesStartMode.Disabled;
                        break;
                }

                return result;
            }
        }

        private string _StartName = string.Empty;
        /// <summary>登录为</summary>>
        public string StartName
        {
            set { _StartName = value; }
            get { return _StartName; }
        }

        private string _State = string.Empty;
        /// <summary>服务状态</summary>>
        public ServicesState State
        {
            set
            {
                switch (value)
                {
                    case ServicesState.Paused:
                        _State = "Paused";
                        break;
                    case ServicesState.PausePending:
                        _State = "Pause Pending";
                        break;
                    case ServicesState.Running:
                        _State = "Running";
                        break;
                    case ServicesState.Stopped:
                        _State = "Stopped";
                        break;
                    case ServicesState.StopPending:
                        _State = "Stop Pending";
                        break;
                }
            }
            get
            {
                ServicesState result = ServicesState.None;
                switch (_State)
                {
                    case "Paused":
                        result = ServicesState.Paused;
                        break;
                    case "Pause Pending":
                        result = ServicesState.PausePending;
                        break;
                    case "Running":
                        result = ServicesState.Running;
                        break;
                    case "Stopped":
                        result = ServicesState.Stopped;
                        break;
                    case "Stop Pending":
                        result = ServicesState.StopPending;
                        break;
                }

                return result;
            }
        }

        private string _Status = string.Empty;
        /// <summary>运行状态</summary>>
        public string Status
        {
            set { _Status = value; }
            get { return _Status; }
        }

        private string _SystemCreationClassName = string.Empty;
        /// <summary>SystemCreationClassName</summary>>
        public string SystemCreationClassName
        {
            set { _SystemCreationClassName = value; }
            get { return _SystemCreationClassName; }
        }

        private string _SystemName = string.Empty;
        /// <summary>计算机名</summary>>
        public string SystemName
        {
            set { _SystemName = value; }
            get { return _SystemName; }
        }

        private int _TagId = 0;
        /// <summary>TagId</summary>>
        public int TagId
        {
            set { _TagId = value; }
            get { return _TagId; }
        }
	
        private int _WaitHint = 0;
        /// <summary>WaitHint</summary>>
        public int WaitHint
        {
            set { _WaitHint = value; }
            get { return _WaitHint; }
        }

    }
}
