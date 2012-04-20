/*
 * XCoder v4.7.4486.37599
 * 作者：Administrator/WIN-7ZX6E2GYT38
 * 时间：2012-04-20 09:19:21
 * 版权：版权所有 (C) 新生命开发团队 2012
*/
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace DotNet.Entites.WorkFlow
{
    /// <summary></summary>
    [Serializable]
    [DataObject]
    [Description("")]
    [BindIndex("PK_Base_Log_ID", true, "LogId")]
    [BindTable("BaseLog", Description = "", ConnName = "WorkFlowDbConnection", DbType = DatabaseType.SqlServer)]
    public partial class BaseLog : IBaseLog
    {
        #region 属性
        private Int32 _LogId;
        /// <summary></summary>
        [DisplayName("LogId")]
        [Description("")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "LogId", "", null, "int", 10, 0, false)]
        public virtual Int32 LogId
        {
            get { return _LogId; }
            set { if (OnPropertyChanging("LogId", value)) { _LogId = value; OnPropertyChanged("LogId"); } }
        }

        private String _ProcessId;
        /// <summary></summary>
        [DisplayName("ProcessId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(2, "ProcessId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ProcessId
        {
            get { return _ProcessId; }
            set { if (OnPropertyChanging("ProcessId", value)) { _ProcessId = value; OnPropertyChanged("ProcessId"); } }
        }

        private String _ProcessName;
        /// <summary></summary>
        [DisplayName("ProcessName")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "ProcessName", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ProcessName
        {
            get { return _ProcessName; }
            set { if (OnPropertyChanging("ProcessName", value)) { _ProcessName = value; OnPropertyChanged("ProcessName"); } }
        }

        private String _MethodId;
        /// <summary></summary>
        [DisplayName("MethodId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "MethodId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String MethodId
        {
            get { return _MethodId; }
            set { if (OnPropertyChanging("MethodId", value)) { _MethodId = value; OnPropertyChanged("MethodId"); } }
        }

        private String _MethodName;
        /// <summary></summary>
        [DisplayName("MethodName")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "MethodName", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String MethodName
        {
            get { return _MethodName; }
            set { if (OnPropertyChanging("MethodName", value)) { _MethodName = value; OnPropertyChanged("MethodName"); } }
        }

        private String _Parameters;
        /// <summary></summary>
        [DisplayName("Parameters")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(6, "Parameters", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String Parameters
        {
            get { return _Parameters; }
            set { if (OnPropertyChanging("Parameters", value)) { _Parameters = value; OnPropertyChanged("Parameters"); } }
        }

        private String _UserId;
        /// <summary></summary>
        [DisplayName("UserId")]
        [Description("")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(7, "UserId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String UserId
        {
            get { return _UserId; }
            set { if (OnPropertyChanging("UserId", value)) { _UserId = value; OnPropertyChanged("UserId"); } }
        }

        private String _UserRealName;
        /// <summary></summary>
        [DisplayName("UserRealName")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(8, "UserRealName", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String UserRealName
        {
            get { return _UserRealName; }
            set { if (OnPropertyChanging("UserRealName", value)) { _UserRealName = value; OnPropertyChanged("UserRealName"); } }
        }

        private String _IPAddress;
        /// <summary></summary>
        [DisplayName("IPAddress")]
        [Description("")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(9, "IPAddress", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String IPAddress
        {
            get { return _IPAddress; }
            set { if (OnPropertyChanging("IPAddress", value)) { _IPAddress = value; OnPropertyChanged("IPAddress"); } }
        }

        private String _UrlReferrer;
        /// <summary></summary>
        [DisplayName("UrlReferrer")]
        [Description("")]
        [DataObjectField(false, false, true, 800)]
        [BindColumn(10, "UrlReferrer", "", null, "nvarchar(800)", 0, 0, true)]
        public virtual String UrlReferrer
        {
            get { return _UrlReferrer; }
            set { if (OnPropertyChanging("UrlReferrer", value)) { _UrlReferrer = value; OnPropertyChanged("UrlReferrer"); } }
        }

        private String _WebUrl;
        /// <summary></summary>
        [DisplayName("WebUrl")]
        [Description("")]
        [DataObjectField(false, false, true, 800)]
        [BindColumn(11, "WebUrl", "", null, "nvarchar(800)", 0, 0, true)]
        public virtual String WebUrl
        {
            get { return _WebUrl; }
            set { if (OnPropertyChanging("WebUrl", value)) { _WebUrl = value; OnPropertyChanged("WebUrl"); } }
        }

        private String _Description;
        /// <summary></summary>
        [DisplayName("Description")]
        [Description("")]
        [DataObjectField(false, false, true, 800)]
        [BindColumn(12, "Description", "", null, "nvarchar(800)", 0, 0, true)]
        public virtual String Description
        {
            get { return _Description; }
            set { if (OnPropertyChanging("Description", value)) { _Description = value; OnPropertyChanged("Description"); } }
        }

        private DateTime _CreateOn;
        /// <summary></summary>
        [DisplayName("CreateOn")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(13, "CreateOn", "", "getdate()", "smalldatetime", 3, 0, false)]
        public virtual DateTime CreateOn
        {
            get { return _CreateOn; }
            set { if (OnPropertyChanging("CreateOn", value)) { _CreateOn = value; OnPropertyChanged("CreateOn"); } }
        }

        private DateTime _ModifiedOn;
        /// <summary></summary>
        [DisplayName("ModifiedOn")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(14, "ModifiedOn", "", null, "smalldatetime", 3, 0, false)]
        public virtual DateTime ModifiedOn
        {
            get { return _ModifiedOn; }
            set { if (OnPropertyChanging("ModifiedOn", value)) { _ModifiedOn = value; OnPropertyChanged("ModifiedOn"); } }
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
                    case "ProcessId" : return _ProcessId;
                    case "ProcessName" : return _ProcessName;
                    case "MethodId" : return _MethodId;
                    case "MethodName" : return _MethodName;
                    case "Parameters" : return _Parameters;
                    case "UserId" : return _UserId;
                    case "UserRealName" : return _UserRealName;
                    case "IPAddress" : return _IPAddress;
                    case "UrlReferrer" : return _UrlReferrer;
                    case "WebUrl" : return _WebUrl;
                    case "Description" : return _Description;
                    case "CreateOn" : return _CreateOn;
                    case "ModifiedOn" : return _ModifiedOn;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "LogId" : _LogId = Convert.ToInt32(value); break;
                    case "ProcessId" : _ProcessId = Convert.ToString(value); break;
                    case "ProcessName" : _ProcessName = Convert.ToString(value); break;
                    case "MethodId" : _MethodId = Convert.ToString(value); break;
                    case "MethodName" : _MethodName = Convert.ToString(value); break;
                    case "Parameters" : _Parameters = Convert.ToString(value); break;
                    case "UserId" : _UserId = Convert.ToString(value); break;
                    case "UserRealName" : _UserRealName = Convert.ToString(value); break;
                    case "IPAddress" : _IPAddress = Convert.ToString(value); break;
                    case "UrlReferrer" : _UrlReferrer = Convert.ToString(value); break;
                    case "WebUrl" : _WebUrl = Convert.ToString(value); break;
                    case "Description" : _Description = Convert.ToString(value); break;
                    case "CreateOn" : _CreateOn = Convert.ToDateTime(value); break;
                    case "ModifiedOn" : _ModifiedOn = Convert.ToDateTime(value); break;
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
            public static readonly Field ProcessId = FindByName("ProcessId");

            ///<summary></summary>
            public static readonly Field ProcessName = FindByName("ProcessName");

            ///<summary></summary>
            public static readonly Field MethodId = FindByName("MethodId");

            ///<summary></summary>
            public static readonly Field MethodName = FindByName("MethodName");

            ///<summary></summary>
            public static readonly Field Parameters = FindByName("Parameters");

            ///<summary></summary>
            public static readonly Field UserId = FindByName("UserId");

            ///<summary></summary>
            public static readonly Field UserRealName = FindByName("UserRealName");

            ///<summary></summary>
            public static readonly Field IPAddress = FindByName("IPAddress");

            ///<summary></summary>
            public static readonly Field UrlReferrer = FindByName("UrlReferrer");

            ///<summary></summary>
            public static readonly Field WebUrl = FindByName("WebUrl");

            ///<summary></summary>
            public static readonly Field Description = FindByName("Description");

            ///<summary></summary>
            public static readonly Field CreateOn = FindByName("CreateOn");

            ///<summary></summary>
            public static readonly Field ModifiedOn = FindByName("ModifiedOn");

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IBaseLog
    {
        #region 属性
        /// <summary></summary>
        Int32 LogId { get; set; }

        /// <summary></summary>
        String ProcessId { get; set; }

        /// <summary></summary>
        String ProcessName { get; set; }

        /// <summary></summary>
        String MethodId { get; set; }

        /// <summary></summary>
        String MethodName { get; set; }

        /// <summary></summary>
        String Parameters { get; set; }

        /// <summary></summary>
        String UserId { get; set; }

        /// <summary></summary>
        String UserRealName { get; set; }

        /// <summary></summary>
        String IPAddress { get; set; }

        /// <summary></summary>
        String UrlReferrer { get; set; }

        /// <summary></summary>
        String WebUrl { get; set; }

        /// <summary></summary>
        String Description { get; set; }

        /// <summary></summary>
        DateTime CreateOn { get; set; }

        /// <summary></summary>
        DateTime ModifiedOn { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}