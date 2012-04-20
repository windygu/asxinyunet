/*
 * XCoder v4.7.4486.37599
 * 作者：Administrator/WIN-7ZX6E2GYT38
 * 时间：2012-04-20 08:40:35
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
    /// <summary>基地序号</summary>
    [Serializable]
    [DataObject]
    [Description("基地序号")]
    [BindIndex("PK_Base_Sequence", true, "Id")]
    [BindTable("Base_Sequence", Description = "基地序号", ConnName = "BusinessDbConnection", DbType = DatabaseType.SqlServer)]
    public partial class Base_Sequence : IBase_Sequence
    {
        #region 属性
        private String _Id;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, false, false, 50)]
        [BindColumn(1, "Id", "编号", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Id
        {
            get { return _Id; }
            set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } }
        }

        private String _FullName;
        /// <summary>会议全称</summary>
        [DisplayName("会议全称")]
        [Description("会议全称")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(2, "FullName", "会议全称", null, "nvarchar(50)", 0, 0, true)]
        public virtual String FullName
        {
            get { return _FullName; }
            set { if (OnPropertyChanging("FullName", value)) { _FullName = value; OnPropertyChanged("FullName"); } }
        }

        private String _Prefix;
        /// <summary>前坠</summary>
        [DisplayName("前坠")]
        [Description("前坠")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "Prefix", "前坠", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Prefix
        {
            get { return _Prefix; }
            set { if (OnPropertyChanging("Prefix", value)) { _Prefix = value; OnPropertyChanged("Prefix"); } }
        }

        private String _Separator;
        /// <summary>编号分隔符</summary>
        [DisplayName("编号分隔符")]
        [Description("编号分隔符")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "Separator", "编号分隔符", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Separator
        {
            get { return _Separator; }
            set { if (OnPropertyChanging("Separator", value)) { _Separator = value; OnPropertyChanged("Separator"); } }
        }

        private Int32 _Sequence;
        /// <summary>序号</summary>
        [DisplayName("序号")]
        [Description("序号")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(5, "Sequence", "序号", "10000000", "int", 10, 0, false)]
        public virtual Int32 Sequence
        {
            get { return _Sequence; }
            set { if (OnPropertyChanging("Sequence", value)) { _Sequence = value; OnPropertyChanged("Sequence"); } }
        }

        private Int32 _Reduction;
        /// <summary>减少</summary>
        [DisplayName("减少")]
        [Description("减少")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(6, "Reduction", "减少", "9999999", "int", 10, 0, false)]
        public virtual Int32 Reduction
        {
            get { return _Reduction; }
            set { if (OnPropertyChanging("Reduction", value)) { _Reduction = value; OnPropertyChanged("Reduction"); } }
        }

        private Int32 _Step;
        /// <summary>步骤</summary>
        [DisplayName("步骤")]
        [Description("步骤")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(7, "Step", "步骤", "1", "int", 10, 0, false)]
        public virtual Int32 Step
        {
            get { return _Step; }
            set { if (OnPropertyChanging("Step", value)) { _Step = value; OnPropertyChanged("Step"); } }
        }

        private String _Description;
        /// <summary>描述</summary>
        [DisplayName("描述")]
        [Description("描述")]
        [DataObjectField(false, false, true, 800)]
        [BindColumn(8, "Description", "描述", null, "nvarchar(800)", 0, 0, true)]
        public virtual String Description
        {
            get { return _Description; }
            set { if (OnPropertyChanging("Description", value)) { _Description = value; OnPropertyChanged("Description"); } }
        }

        private DateTime _CreateOn;
        /// <summary>创建上</summary>
        [DisplayName("创建上")]
        [Description("创建上")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(9, "CreateOn", "创建上", "getdate()", "smalldatetime", 3, 0, false)]
        public virtual DateTime CreateOn
        {
            get { return _CreateOn; }
            set { if (OnPropertyChanging("CreateOn", value)) { _CreateOn = value; OnPropertyChanged("CreateOn"); } }
        }

        private String _CreateUserId;
        /// <summary>创建人ID</summary>
        [DisplayName("创建人ID")]
        [Description("创建人ID")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(10, "CreateUserId", "创建人ID", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CreateUserId
        {
            get { return _CreateUserId; }
            set { if (OnPropertyChanging("CreateUserId", value)) { _CreateUserId = value; OnPropertyChanged("CreateUserId"); } }
        }

        private String _CreateBy;
        /// <summary>创建由</summary>
        [DisplayName("创建由")]
        [Description("创建由")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(11, "CreateBy", "创建由", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CreateBy
        {
            get { return _CreateBy; }
            set { if (OnPropertyChanging("CreateBy", value)) { _CreateBy = value; OnPropertyChanged("CreateBy"); } }
        }

        private DateTime _ModifiedOn;
        /// <summary>修改日期</summary>
        [DisplayName("修改日期")]
        [Description("修改日期")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(12, "ModifiedOn", "修改日期", "getdate()", "smalldatetime", 3, 0, false)]
        public virtual DateTime ModifiedOn
        {
            get { return _ModifiedOn; }
            set { if (OnPropertyChanging("ModifiedOn", value)) { _ModifiedOn = value; OnPropertyChanged("ModifiedOn"); } }
        }

        private String _ModifiedUserId;
        /// <summary>修改标识1修改0没修改Usersandglobalprivileges编号</summary>
        [DisplayName("修改标识1修改0没修改Usersandglobalprivileges编号")]
        [Description("修改标识1修改0没修改Usersandglobalprivileges编号")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(13, "ModifiedUserId", "修改标识1修改0没修改Usersandglobalprivileges编号", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ModifiedUserId
        {
            get { return _ModifiedUserId; }
            set { if (OnPropertyChanging("ModifiedUserId", value)) { _ModifiedUserId = value; OnPropertyChanged("ModifiedUserId"); } }
        }

        private String _ModifiedBy;
        /// <summary>修改者</summary>
        [DisplayName("修改者")]
        [Description("修改者")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(14, "ModifiedBy", "修改者", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ModifiedBy
        {
            get { return _ModifiedBy; }
            set { if (OnPropertyChanging("ModifiedBy", value)) { _ModifiedBy = value; OnPropertyChanged("ModifiedBy"); } }
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
                    case "FullName" : return _FullName;
                    case "Prefix" : return _Prefix;
                    case "Separator" : return _Separator;
                    case "Sequence" : return _Sequence;
                    case "Reduction" : return _Reduction;
                    case "Step" : return _Step;
                    case "Description" : return _Description;
                    case "CreateOn" : return _CreateOn;
                    case "CreateUserId" : return _CreateUserId;
                    case "CreateBy" : return _CreateBy;
                    case "ModifiedOn" : return _ModifiedOn;
                    case "ModifiedUserId" : return _ModifiedUserId;
                    case "ModifiedBy" : return _ModifiedBy;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id" : _Id = Convert.ToString(value); break;
                    case "FullName" : _FullName = Convert.ToString(value); break;
                    case "Prefix" : _Prefix = Convert.ToString(value); break;
                    case "Separator" : _Separator = Convert.ToString(value); break;
                    case "Sequence" : _Sequence = Convert.ToInt32(value); break;
                    case "Reduction" : _Reduction = Convert.ToInt32(value); break;
                    case "Step" : _Step = Convert.ToInt32(value); break;
                    case "Description" : _Description = Convert.ToString(value); break;
                    case "CreateOn" : _CreateOn = Convert.ToDateTime(value); break;
                    case "CreateUserId" : _CreateUserId = Convert.ToString(value); break;
                    case "CreateBy" : _CreateBy = Convert.ToString(value); break;
                    case "ModifiedOn" : _ModifiedOn = Convert.ToDateTime(value); break;
                    case "ModifiedUserId" : _ModifiedUserId = Convert.ToString(value); break;
                    case "ModifiedBy" : _ModifiedBy = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得基地序号字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>编号</summary>
            public static readonly Field Id = FindByName("Id");

            ///<summary>会议全称</summary>
            public static readonly Field FullName = FindByName("FullName");

            ///<summary>前坠</summary>
            public static readonly Field Prefix = FindByName("Prefix");

            ///<summary>编号分隔符</summary>
            public static readonly Field Separator = FindByName("Separator");

            ///<summary>序号</summary>
            public static readonly Field Sequence = FindByName("Sequence");

            ///<summary>减少</summary>
            public static readonly Field Reduction = FindByName("Reduction");

            ///<summary>步骤</summary>
            public static readonly Field Step = FindByName("Step");

            ///<summary>描述</summary>
            public static readonly Field Description = FindByName("Description");

            ///<summary>创建上</summary>
            public static readonly Field CreateOn = FindByName("CreateOn");

            ///<summary>创建人ID</summary>
            public static readonly Field CreateUserId = FindByName("CreateUserId");

            ///<summary>创建由</summary>
            public static readonly Field CreateBy = FindByName("CreateBy");

            ///<summary>修改日期</summary>
            public static readonly Field ModifiedOn = FindByName("ModifiedOn");

            ///<summary>修改标识1修改0没修改Usersandglobalprivileges编号</summary>
            public static readonly Field ModifiedUserId = FindByName("ModifiedUserId");

            ///<summary>修改者</summary>
            public static readonly Field ModifiedBy = FindByName("ModifiedBy");

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }
        #endregion
    }

    /// <summary>基地序号接口</summary>
    public partial interface IBase_Sequence
    {
        #region 属性
        /// <summary>编号</summary>
        String Id { get; set; }

        /// <summary>会议全称</summary>
        String FullName { get; set; }

        /// <summary>前坠</summary>
        String Prefix { get; set; }

        /// <summary>编号分隔符</summary>
        String Separator { get; set; }

        /// <summary>序号</summary>
        Int32 Sequence { get; set; }

        /// <summary>减少</summary>
        Int32 Reduction { get; set; }

        /// <summary>步骤</summary>
        Int32 Step { get; set; }

        /// <summary>描述</summary>
        String Description { get; set; }

        /// <summary>创建上</summary>
        DateTime CreateOn { get; set; }

        /// <summary>创建人ID</summary>
        String CreateUserId { get; set; }

        /// <summary>创建由</summary>
        String CreateBy { get; set; }

        /// <summary>修改日期</summary>
        DateTime ModifiedOn { get; set; }

        /// <summary>修改标识1修改0没修改Usersandglobalprivileges编号</summary>
        String ModifiedUserId { get; set; }

        /// <summary>修改者</summary>
        String ModifiedBy { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}