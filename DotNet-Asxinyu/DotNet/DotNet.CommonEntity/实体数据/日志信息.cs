﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace DotNet.CommonEntity
{
    /// <summary>日志信息</summary>
    [Serializable]
    [DataObject]
    [Description("日志信息")]
    [BindIndex("PRIMARY", true, "Id")]
    [BindIndex("UserId", false, "UserId")]
    [BindIndex("SystemDbId", false, "SystemDbId")]
    [BindIndex("UserSystem", false, "SystemDbId,UserId")]
    [BindRelation("SystemDbId", false, "SystemDb", "Id")]
    [BindRelation("UserId", false, "User", "Id")]
    [BindTable("Log", Description = "日志信息", ConnName = "DotNetCommon", DbType = DatabaseType.MySql)]
    public partial class Log<TEntity> : ILog
    {
        #region 属性
        private Int32 _Id;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "Id", "编号", null, "int(11)", 10, 0, false)]
        public virtual Int32 Id
        {
            get { return _Id; }
            set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } }
        }

        private Int32 _SystemDbId;
        /// <summary>表编号</summary>
        [DisplayName("表编号")]
        [Description("表编号")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(2, "SystemDbId", "表编号", null, "int(11)", 10, 0, false)]
        public virtual Int32 SystemDbId
        {
            get { return _SystemDbId; }
            set { if (OnPropertyChanging("SystemDbId", value)) { _SystemDbId = value; OnPropertyChanged("SystemDbId"); } }
        }

        private Int32 _UserId;
        /// <summary>用户编号</summary>
        [DisplayName("用户编号")]
        [Description("用户编号")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(3, "UserId", "用户编号", null, "int(11)", 10, 0, false)]
        public virtual Int32 UserId
        {
            get { return _UserId; }
            set { if (OnPropertyChanging("UserId", value)) { _UserId = value; OnPropertyChanged("UserId"); } }
        }

        private String _Category;
        /// <summary>日志类别</summary>
        [DisplayName("日志类别")]
        [Description("日志类别")]
        [DataObjectField(false, false, false, 30)]
        [BindColumn(4, "Category", "日志类别", null, "varchar(30)", 0, 0, false)]
        public virtual String Category
        {
            get { return _Category; }
            set { if (OnPropertyChanging("Category", value)) { _Category = value; OnPropertyChanged("Category"); } }
        }

        private String _Action;
        /// <summary>操作行为</summary>
        [DisplayName("操作行为")]
        [Description("操作行为")]
        [DataObjectField(false, false, true, 80)]
        [BindColumn(5, "Action", "操作行为", null, "varchar(80)", 0, 0, false)]
        public virtual String Action
        {
            get { return _Action; }
            set { if (OnPropertyChanging("Action", value)) { _Action = value; OnPropertyChanged("Action"); } }
        }

        private String _Content;
        /// <summary>操作内容</summary>
        [DisplayName("操作内容")]
        [Description("操作内容")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(6, "Content", "操作内容", null, "varchar(200)", 0, 0, false)]
        public virtual String Content
        {
            get { return _Content; }
            set { if (OnPropertyChanging("Content", value)) { _Content = value; OnPropertyChanged("Content"); } }
        }

        private DateTime _OccurTime;
        /// <summary>发生时间</summary>
        [DisplayName("发生时间")]
        [Description("发生时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn(7, "OccurTime", "发生时间", null, "datetime", 0, 0, false)]
        public virtual DateTime OccurTime
        {
            get { return _OccurTime; }
            set { if (OnPropertyChanging("OccurTime", value)) { _OccurTime = value; OnPropertyChanged("OccurTime"); } }
        }

        private SByte _DeletionStatusCode;
        /// <summary>删除标志</summary>
        [DisplayName("删除标志")]
        [Description("删除标志")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(8, "DeletionStatusCode", "删除标志", "0", "tinyint(4)", 3, 0, false)]
        public virtual SByte DeletionStatusCode
        {
            get { return _DeletionStatusCode; }
            set { if (OnPropertyChanging("DeletionStatusCode", value)) { _DeletionStatusCode = value; OnPropertyChanged("DeletionStatusCode"); } }
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
                    case "Id" : return _Id;
                    case "SystemDbId" : return _SystemDbId;
                    case "UserId" : return _UserId;
                    case "Category" : return _Category;
                    case "Action" : return _Action;
                    case "Content" : return _Content;
                    case "OccurTime" : return _OccurTime;
                    case "DeletionStatusCode" : return _DeletionStatusCode;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id" : _Id = Convert.ToInt32(value); break;
                    case "SystemDbId" : _SystemDbId = Convert.ToInt32(value); break;
                    case "UserId" : _UserId = Convert.ToInt32(value); break;
                    case "Category" : _Category = Convert.ToString(value); break;
                    case "Action" : _Action = Convert.ToString(value); break;
                    case "Content" : _Content = Convert.ToString(value); break;
                    case "OccurTime" : _OccurTime = Convert.ToDateTime(value); break;
                    case "DeletionStatusCode" : _DeletionStatusCode = Convert.ToSByte(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得日志信息字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>编号</summary>
            public static readonly Field Id = FindByName("Id");

            ///<summary>表编号</summary>
            public static readonly Field SystemDbId = FindByName("SystemDbId");

            ///<summary>用户编号</summary>
            public static readonly Field UserId = FindByName("UserId");

            ///<summary>日志类别</summary>
            public static readonly Field Category = FindByName("Category");

            ///<summary>操作行为</summary>
            public static readonly Field Action = FindByName("Action");

            ///<summary>操作内容</summary>
            public static readonly Field Content = FindByName("Content");

            ///<summary>发生时间</summary>
            public static readonly Field OccurTime = FindByName("OccurTime");

            ///<summary>删除标志</summary>
            public static readonly Field DeletionStatusCode = FindByName("DeletionStatusCode");

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }
        #endregion
    }

    /// <summary>日志信息接口</summary>
    public partial interface ILog
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 Id { get; set; }

        /// <summary>表编号</summary>
        Int32 SystemDbId { get; set; }

        /// <summary>用户编号</summary>
        Int32 UserId { get; set; }

        /// <summary>日志类别</summary>
        String Category { get; set; }

        /// <summary>操作行为</summary>
        String Action { get; set; }

        /// <summary>操作内容</summary>
        String Content { get; set; }

        /// <summary>发生时间</summary>
        DateTime OccurTime { get; set; }

        /// <summary>删除标志</summary>
        SByte DeletionStatusCode { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>
        /// 获取/设置 字段值。
        /// </summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}