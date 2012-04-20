/*
 * XCoder v4.7.4486.37599
 * 作者：Administrator/WIN-7ZX6E2GYT38
 * 时间：2012-04-20 08:38:02
 * 版权：版权所有 (C) 新生命开发团队 2012
*/
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace DotNet.Entites
{
    /// <summary></summary>
    [Serializable]
    [DataObject]
    [Description("")]
    [BindIndex("PK_Base_Exception", true, "LogId")]
    [BindTable("BaseException", Description = "", ConnName = "UserCenterDbConnection", DbType = DatabaseType.SqlServer)]
    public partial class BaseException : IBaseException
    {
        #region 属性
        private String _LogId;
        /// <summary></summary>
        [DisplayName("LogId")]
        [Description("")]
        [DataObjectField(true, false, false, 40)]
        [BindColumn(1, "LogId", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String LogId
        {
            get { return _LogId; }
            set { if (OnPropertyChanging("LogId", value)) { _LogId = value; OnPropertyChanged("LogId"); } }
        }

        private Int32 _EventId;
        /// <summary></summary>
        [DisplayName("EventId")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(2, "EventId", "", null, "int", 10, 0, false)]
        public virtual Int32 EventId
        {
            get { return _EventId; }
            set { if (OnPropertyChanging("EventId", value)) { _EventId = value; OnPropertyChanged("EventId"); } }
        }

        private String _Category;
        /// <summary></summary>
        [DisplayName("Category")]
        [Description("")]
        [DataObjectField(false, false, true, 64)]
        [BindColumn(3, "Category", "", null, "nvarchar(64)", 0, 0, true)]
        public virtual String Category
        {
            get { return _Category; }
            set { if (OnPropertyChanging("Category", value)) { _Category = value; OnPropertyChanged("Category"); } }
        }

        private Int32 _Priority;
        /// <summary></summary>
        [DisplayName("Priority")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(4, "Priority", "", null, "int", 10, 0, false)]
        public virtual Int32 Priority
        {
            get { return _Priority; }
            set { if (OnPropertyChanging("Priority", value)) { _Priority = value; OnPropertyChanged("Priority"); } }
        }

        private String _Severity;
        /// <summary></summary>
        [DisplayName("Severity")]
        [Description("")]
        [DataObjectField(false, false, true, 32)]
        [BindColumn(5, "Severity", "", null, "nvarchar(32)", 0, 0, true)]
        public virtual String Severity
        {
            get { return _Severity; }
            set { if (OnPropertyChanging("Severity", value)) { _Severity = value; OnPropertyChanged("Severity"); } }
        }

        private String _Title;
        /// <summary></summary>
        [DisplayName("Title")]
        [Description("")]
        [DataObjectField(false, false, true, 256)]
        [BindColumn(6, "Title", "", null, "nvarchar(256)", 0, 0, true)]
        public virtual String Title
        {
            get { return _Title; }
            set { if (OnPropertyChanging("Title", value)) { _Title = value; OnPropertyChanged("Title"); } }
        }

        private DateTime _Timestamp;
        /// <summary></summary>
        [DisplayName("Timestamp")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(7, "Timestamp", "", null, "datetime", 3, 0, false)]
        public virtual DateTime Timestamp
        {
            get { return _Timestamp; }
            set { if (OnPropertyChanging("Timestamp", value)) { _Timestamp = value; OnPropertyChanged("Timestamp"); } }
        }

        private String _MachineName;
        /// <summary></summary>
        [DisplayName("MachineName")]
        [Description("")]
        [DataObjectField(false, false, true, 32)]
        [BindColumn(8, "MachineName", "", null, "nvarchar(32)", 0, 0, true)]
        public virtual String MachineName
        {
            get { return _MachineName; }
            set { if (OnPropertyChanging("MachineName", value)) { _MachineName = value; OnPropertyChanged("MachineName"); } }
        }

        private String _IPAddress;
        /// <summary></summary>
        [DisplayName("IPAddress")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(9, "IPAddress", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String IPAddress
        {
            get { return _IPAddress; }
            set { if (OnPropertyChanging("IPAddress", value)) { _IPAddress = value; OnPropertyChanged("IPAddress"); } }
        }

        private String _AppDomainName;
        /// <summary></summary>
        [DisplayName("AppDomainName")]
        [Description("")]
        [DataObjectField(false, false, true, 2000)]
        [BindColumn(10, "AppDomainName", "", null, "nvarchar(2000)", 0, 0, true)]
        public virtual String AppDomainName
        {
            get { return _AppDomainName; }
            set { if (OnPropertyChanging("AppDomainName", value)) { _AppDomainName = value; OnPropertyChanged("AppDomainName"); } }
        }

        private String _ProcessID;
        /// <summary></summary>
        [DisplayName("ProcessID")]
        [Description("")]
        [DataObjectField(false, false, true, 256)]
        [BindColumn(11, "ProcessID", "", null, "nvarchar(256)", 0, 0, true)]
        public virtual String ProcessID
        {
            get { return _ProcessID; }
            set { if (OnPropertyChanging("ProcessID", value)) { _ProcessID = value; OnPropertyChanged("ProcessID"); } }
        }

        private String _ProcessName;
        /// <summary></summary>
        [DisplayName("ProcessName")]
        [Description("")]
        [DataObjectField(false, false, true, 2000)]
        [BindColumn(12, "ProcessName", "", null, "nvarchar(2000)", 0, 0, true)]
        public virtual String ProcessName
        {
            get { return _ProcessName; }
            set { if (OnPropertyChanging("ProcessName", value)) { _ProcessName = value; OnPropertyChanged("ProcessName"); } }
        }

        private String _ThreadName;
        /// <summary></summary>
        [DisplayName("ThreadName")]
        [Description("")]
        [DataObjectField(false, false, true, 2000)]
        [BindColumn(13, "ThreadName", "", null, "nvarchar(2000)", 0, 0, true)]
        public virtual String ThreadName
        {
            get { return _ThreadName; }
            set { if (OnPropertyChanging("ThreadName", value)) { _ThreadName = value; OnPropertyChanged("ThreadName"); } }
        }

        private String _Win32ThreadId;
        /// <summary></summary>
        [DisplayName("Win32ThreadId")]
        [Description("")]
        [DataObjectField(false, false, true, 128)]
        [BindColumn(14, "Win32ThreadId", "", null, "nvarchar(128)", 0, 0, true)]
        public virtual String Win32ThreadId
        {
            get { return _Win32ThreadId; }
            set { if (OnPropertyChanging("Win32ThreadId", value)) { _Win32ThreadId = value; OnPropertyChanged("Win32ThreadId"); } }
        }

        private String _Message;
        /// <summary></summary>
        [DisplayName("Message")]
        [Description("")]
        [DataObjectField(false, false, true, 2000)]
        [BindColumn(15, "Message", "", null, "nvarchar(2000)", 0, 0, true)]
        public virtual String Message
        {
            get { return _Message; }
            set { if (OnPropertyChanging("Message", value)) { _Message = value; OnPropertyChanged("Message"); } }
        }

        private String _FormattedMessage;
        /// <summary></summary>
        [DisplayName("FormattedMessage")]
        [Description("")]
        [DataObjectField(false, false, true, 1073741823)]
        [BindColumn(16, "FormattedMessage", "", null, "ntext", 0, 0, true)]
        public virtual String FormattedMessage
        {
            get { return _FormattedMessage; }
            set { if (OnPropertyChanging("FormattedMessage", value)) { _FormattedMessage = value; OnPropertyChanged("FormattedMessage"); } }
        }

        private String _CreateUserID;
        /// <summary></summary>
        [DisplayName("CreateUserID")]
        [Description("")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(17, "CreateUserID", "", null, "nvarchar(20)", 0, 0, true)]
        public virtual String CreateUserID
        {
            get { return _CreateUserID; }
            set { if (OnPropertyChanging("CreateUserID", value)) { _CreateUserID = value; OnPropertyChanged("CreateUserID"); } }
        }

        private String _CreateBy;
        /// <summary></summary>
        [DisplayName("CreateBy")]
        [Description("")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(18, "CreateBy", "", null, "nvarchar(20)", 0, 0, true)]
        public virtual String CreateBy
        {
            get { return _CreateBy; }
            set { if (OnPropertyChanging("CreateBy", value)) { _CreateBy = value; OnPropertyChanged("CreateBy"); } }
        }

        private DateTime _CreateOn;
        /// <summary></summary>
        [DisplayName("CreateOn")]
        [Description("")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(19, "CreateOn", "", "getdate()", "smalldatetime", 3, 0, false)]
        public virtual DateTime CreateOn
        {
            get { return _CreateOn; }
            set { if (OnPropertyChanging("CreateOn", value)) { _CreateOn = value; OnPropertyChanged("CreateOn"); } }
        }
		#endregion

        #region 获取/设置 字段值
        /// <summary>
        /// 获取/设置 字段值。
        /// 一个索引，基类使用反射实现。
        /// 派生实体类可重写该索引，以避免反射带来的性能损耗
        /// </summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                switch (name)
                {
                    case "LogId" : return _LogId;
                    case "EventId" : return _EventId;
                    case "Category" : return _Category;
                    case "Priority" : return _Priority;
                    case "Severity" : return _Severity;
                    case "Title" : return _Title;
                    case "Timestamp" : return _Timestamp;
                    case "MachineName" : return _MachineName;
                    case "IPAddress" : return _IPAddress;
                    case "AppDomainName" : return _AppDomainName;
                    case "ProcessID" : return _ProcessID;
                    case "ProcessName" : return _ProcessName;
                    case "ThreadName" : return _ThreadName;
                    case "Win32ThreadId" : return _Win32ThreadId;
                    case "Message" : return _Message;
                    case "FormattedMessage" : return _FormattedMessage;
                    case "CreateUserID" : return _CreateUserID;
                    case "CreateBy" : return _CreateBy;
                    case "CreateOn" : return _CreateOn;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "LogId" : _LogId = Convert.ToString(value); break;
                    case "EventId" : _EventId = Convert.ToInt32(value); break;
                    case "Category" : _Category = Convert.ToString(value); break;
                    case "Priority" : _Priority = Convert.ToInt32(value); break;
                    case "Severity" : _Severity = Convert.ToString(value); break;
                    case "Title" : _Title = Convert.ToString(value); break;
                    case "Timestamp" : _Timestamp = Convert.ToDateTime(value); break;
                    case "MachineName" : _MachineName = Convert.ToString(value); break;
                    case "IPAddress" : _IPAddress = Convert.ToString(value); break;
                    case "AppDomainName" : _AppDomainName = Convert.ToString(value); break;
                    case "ProcessID" : _ProcessID = Convert.ToString(value); break;
                    case "ProcessName" : _ProcessName = Convert.ToString(value); break;
                    case "ThreadName" : _ThreadName = Convert.ToString(value); break;
                    case "Win32ThreadId" : _Win32ThreadId = Convert.ToString(value); break;
                    case "Message" : _Message = Convert.ToString(value); break;
                    case "FormattedMessage" : _FormattedMessage = Convert.ToString(value); break;
                    case "CreateUserID" : _CreateUserID = Convert.ToString(value); break;
                    case "CreateBy" : _CreateBy = Convert.ToString(value); break;
                    case "CreateOn" : _CreateOn = Convert.ToDateTime(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得字段信息的快捷方式</summary>
        public class _
        {
            ///<summary></summary>
            public static readonly Field LogId = FindByName("LogId");

            ///<summary></summary>
            public static readonly Field EventId = FindByName("EventId");

            ///<summary></summary>
            public static readonly Field Category = FindByName("Category");

            ///<summary></summary>
            public static readonly Field Priority = FindByName("Priority");

            ///<summary></summary>
            public static readonly Field Severity = FindByName("Severity");

            ///<summary></summary>
            public static readonly Field Title = FindByName("Title");

            ///<summary></summary>
            public static readonly Field Timestamp = FindByName("Timestamp");

            ///<summary></summary>
            public static readonly Field MachineName = FindByName("MachineName");

            ///<summary></summary>
            public static readonly Field IPAddress = FindByName("IPAddress");

            ///<summary></summary>
            public static readonly Field AppDomainName = FindByName("AppDomainName");

            ///<summary></summary>
            public static readonly Field ProcessID = FindByName("ProcessID");

            ///<summary></summary>
            public static readonly Field ProcessName = FindByName("ProcessName");

            ///<summary></summary>
            public static readonly Field ThreadName = FindByName("ThreadName");

            ///<summary></summary>
            public static readonly Field Win32ThreadId = FindByName("Win32ThreadId");

            ///<summary></summary>
            public static readonly Field Message = FindByName("Message");

            ///<summary></summary>
            public static readonly Field FormattedMessage = FindByName("FormattedMessage");

            ///<summary></summary>
            public static readonly Field CreateUserID = FindByName("CreateUserID");

            ///<summary></summary>
            public static readonly Field CreateBy = FindByName("CreateBy");

            ///<summary></summary>
            public static readonly Field CreateOn = FindByName("CreateOn");

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IBaseException
    {
        #region 属性
        /// <summary></summary>
        String LogId { get; set; }

        /// <summary></summary>
        Int32 EventId { get; set; }

        /// <summary></summary>
        String Category { get; set; }

        /// <summary></summary>
        Int32 Priority { get; set; }

        /// <summary></summary>
        String Severity { get; set; }

        /// <summary></summary>
        String Title { get; set; }

        /// <summary></summary>
        DateTime Timestamp { get; set; }

        /// <summary></summary>
        String MachineName { get; set; }

        /// <summary></summary>
        String IPAddress { get; set; }

        /// <summary></summary>
        String AppDomainName { get; set; }

        /// <summary></summary>
        String ProcessID { get; set; }

        /// <summary></summary>
        String ProcessName { get; set; }

        /// <summary></summary>
        String ThreadName { get; set; }

        /// <summary></summary>
        String Win32ThreadId { get; set; }

        /// <summary></summary>
        String Message { get; set; }

        /// <summary></summary>
        String FormattedMessage { get; set; }

        /// <summary></summary>
        String CreateUserID { get; set; }

        /// <summary></summary>
        String CreateBy { get; set; }

        /// <summary></summary>
        DateTime CreateOn { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}