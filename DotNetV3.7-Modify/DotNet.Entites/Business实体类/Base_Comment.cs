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
    /// <summary>基地InnoDBfree:29696kB;(`post_id`)REFER`wbtoolkit/tbl_post`(`id`)ONDELETECA</summary>
    [Serializable]
    [DataObject]
    [Description("基地InnoDBfree:29696kB;(`post_id`)REFER`wbtoolkit/tbl_post`(`id`)ONDELETECA")]
    [BindIndex("PK_Base_Comment", true, "Id")]
    [BindTable("Base_Comment", Description = "基地InnoDBfree:29696kB;(`post_id`)REFER`wbtoolkit/tbl_post`(`id`)ONDELETECA", ConnName = "BusinessDbConnection", DbType = DatabaseType.SqlServer)]
    public partial class Base_Comment : IBase_Comment
    {
        #region 属性
        private String _Id;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, false, false, 50)]
        [BindColumn(1, "Id", "编号", "newid()", "nvarchar(50)", 0, 0, true)]
        public virtual String Id
        {
            get { return _Id; }
            set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } }
        }

        private String _ParentId;
        /// <summary>父编号</summary>
        [DisplayName("父编号")]
        [Description("父编号")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(2, "ParentId", "父编号", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ParentId
        {
            get { return _ParentId; }
            set { if (OnPropertyChanging("ParentId", value)) { _ParentId = value; OnPropertyChanged("ParentId"); } }
        }

        private String _CategoryCode;
        /// <summary>分类栏目代码</summary>
        [DisplayName("分类栏目代码")]
        [Description("分类栏目代码")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "CategoryCode", "分类栏目代码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CategoryCode
        {
            get { return _CategoryCode; }
            set { if (OnPropertyChanging("CategoryCode", value)) { _CategoryCode = value; OnPropertyChanged("CategoryCode"); } }
        }

        private String _ObjectId;
        /// <summary>费用对象ID</summary>
        [DisplayName("费用对象ID")]
        [Description("费用对象ID")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "ObjectId", "费用对象ID", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ObjectId
        {
            get { return _ObjectId; }
            set { if (OnPropertyChanging("ObjectId", value)) { _ObjectId = value; OnPropertyChanged("ObjectId"); } }
        }

        private String _Title;
        /// <summary>分类名称</summary>
        [DisplayName("分类名称")]
        [Description("分类名称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "Title", "分类名称", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Title
        {
            get { return _Title; }
            set { if (OnPropertyChanging("Title", value)) { _Title = value; OnPropertyChanged("Title"); } }
        }

        private Int32 _Worked;
        /// <summary>工作</summary>
        [DisplayName("工作")]
        [Description("工作")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(6, "Worked", "工作", null, "int", 10, 0, false)]
        public virtual Int32 Worked
        {
            get { return _Worked; }
            set { if (OnPropertyChanging("Worked", value)) { _Worked = value; OnPropertyChanged("Worked"); } }
        }

        private String _Contents;
        /// <summary>内容</summary>
        [DisplayName("内容")]
        [Description("内容")]
        [DataObjectField(false, false, true, 1073741823)]
        [BindColumn(7, "Contents", "内容", null, "ntext", 0, 0, true)]
        public virtual String Contents
        {
            get { return _Contents; }
            set { if (OnPropertyChanging("Contents", value)) { _Contents = value; OnPropertyChanged("Contents"); } }
        }

        private Int32 _Important;
        /// <summary>重要</summary>
        [DisplayName("重要")]
        [Description("重要")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(8, "Important", "重要", "0", "int", 10, 0, false)]
        public virtual Int32 Important
        {
            get { return _Important; }
            set { if (OnPropertyChanging("Important", value)) { _Important = value; OnPropertyChanged("Important"); } }
        }

        private String _PriorityId;
        /// <summary>优先级编号</summary>
        [DisplayName("优先级编号")]
        [Description("优先级编号")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(9, "PriorityId", "优先级编号", null, "varchar(20)", 0, 0, false)]
        public virtual String PriorityId
        {
            get { return _PriorityId; }
            set { if (OnPropertyChanging("PriorityId", value)) { _PriorityId = value; OnPropertyChanged("PriorityId"); } }
        }

        private String _IPAddress;
        /// <summary>地址地址</summary>
        [DisplayName("地址地址")]
        [Description("地址地址")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(10, "IPAddress", "地址地址", null, "varchar(50)", 0, 0, false)]
        public virtual String IPAddress
        {
            get { return _IPAddress; }
            set { if (OnPropertyChanging("IPAddress", value)) { _IPAddress = value; OnPropertyChanged("IPAddress"); } }
        }

        private String _TargetURL;
        /// <summary>目标链接</summary>
        [DisplayName("目标链接")]
        [Description("目标链接")]
        [DataObjectField(false, false, true, 400)]
        [BindColumn(11, "TargetURL", "目标链接", null, "nvarchar(400)", 0, 0, true)]
        public virtual String TargetURL
        {
            get { return _TargetURL; }
            set { if (OnPropertyChanging("TargetURL", value)) { _TargetURL = value; OnPropertyChanged("TargetURL"); } }
        }

        private String _Description;
        /// <summary>描述</summary>
        [DisplayName("描述")]
        [Description("描述")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(12, "Description", "描述", null, "nvarchar(200)", 0, 0, true)]
        public virtual String Description
        {
            get { return _Description; }
            set { if (OnPropertyChanging("Description", value)) { _Description = value; OnPropertyChanged("Description"); } }
        }

        private Int32 _DeletionStateCode;
        /// <summary>用户是否删除</summary>
        [DisplayName("用户是否删除")]
        [Description("用户是否删除")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(13, "DeletionStateCode", "用户是否删除", "0", "int", 10, 0, false)]
        public virtual Int32 DeletionStateCode
        {
            get { return _DeletionStateCode; }
            set { if (OnPropertyChanging("DeletionStateCode", value)) { _DeletionStateCode = value; OnPropertyChanged("DeletionStateCode"); } }
        }

        private Int32 _Enabled;
        /// <summary>是否可用</summary>
        [DisplayName("是否可用")]
        [Description("是否可用")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(14, "Enabled", "是否可用", "1", "int", 10, 0, false)]
        public virtual Int32 Enabled
        {
            get { return _Enabled; }
            set { if (OnPropertyChanging("Enabled", value)) { _Enabled = value; OnPropertyChanged("Enabled"); } }
        }

        private Int32 _SortCode;
        /// <summary>排序号</summary>
        [DisplayName("排序号")]
        [Description("排序号")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(15, "SortCode", "排序号", null, "int", 10, 0, false)]
        public virtual Int32 SortCode
        {
            get { return _SortCode; }
            set { if (OnPropertyChanging("SortCode", value)) { _SortCode = value; OnPropertyChanged("SortCode"); } }
        }

        private DateTime _CreateOn;
        /// <summary>创建上</summary>
        [DisplayName("创建上")]
        [Description("创建上")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(16, "CreateOn", "创建上", "getdate()", "smalldatetime", 3, 0, false)]
        public virtual DateTime CreateOn
        {
            get { return _CreateOn; }
            set { if (OnPropertyChanging("CreateOn", value)) { _CreateOn = value; OnPropertyChanged("CreateOn"); } }
        }

        private String _CreateUserId;
        /// <summary>创建人ID</summary>
        [DisplayName("创建人ID")]
        [Description("创建人ID")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(17, "CreateUserId", "创建人ID", null, "nvarchar(20)", 0, 0, true)]
        public virtual String CreateUserId
        {
            get { return _CreateUserId; }
            set { if (OnPropertyChanging("CreateUserId", value)) { _CreateUserId = value; OnPropertyChanged("CreateUserId"); } }
        }

        private String _CreateBy;
        /// <summary>创建由</summary>
        [DisplayName("创建由")]
        [Description("创建由")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(18, "CreateBy", "创建由", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(19, "ModifiedOn", "修改日期", "getdate()", "smalldatetime", 3, 0, false)]
        public virtual DateTime ModifiedOn
        {
            get { return _ModifiedOn; }
            set { if (OnPropertyChanging("ModifiedOn", value)) { _ModifiedOn = value; OnPropertyChanged("ModifiedOn"); } }
        }

        private String _ModifiedUserId;
        /// <summary>修改标识1修改0没修改Usersandglobalprivileges编号</summary>
        [DisplayName("修改标识1修改0没修改Usersandglobalprivileges编号")]
        [Description("修改标识1修改0没修改Usersandglobalprivileges编号")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(20, "ModifiedUserId", "修改标识1修改0没修改Usersandglobalprivileges编号", null, "nvarchar(20)", 0, 0, true)]
        public virtual String ModifiedUserId
        {
            get { return _ModifiedUserId; }
            set { if (OnPropertyChanging("ModifiedUserId", value)) { _ModifiedUserId = value; OnPropertyChanged("ModifiedUserId"); } }
        }

        private String _ModifiedBy;
        /// <summary>修改者</summary>
        [DisplayName("修改者")]
        [Description("修改者")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(21, "ModifiedBy", "修改者", null, "nvarchar(20)", 0, 0, true)]
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
                    case "ParentId" : return _ParentId;
                    case "CategoryCode" : return _CategoryCode;
                    case "ObjectId" : return _ObjectId;
                    case "Title" : return _Title;
                    case "Worked" : return _Worked;
                    case "Contents" : return _Contents;
                    case "Important" : return _Important;
                    case "PriorityId" : return _PriorityId;
                    case "IPAddress" : return _IPAddress;
                    case "TargetURL" : return _TargetURL;
                    case "Description" : return _Description;
                    case "DeletionStateCode" : return _DeletionStateCode;
                    case "Enabled" : return _Enabled;
                    case "SortCode" : return _SortCode;
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
                    case "ParentId" : _ParentId = Convert.ToString(value); break;
                    case "CategoryCode" : _CategoryCode = Convert.ToString(value); break;
                    case "ObjectId" : _ObjectId = Convert.ToString(value); break;
                    case "Title" : _Title = Convert.ToString(value); break;
                    case "Worked" : _Worked = Convert.ToInt32(value); break;
                    case "Contents" : _Contents = Convert.ToString(value); break;
                    case "Important" : _Important = Convert.ToInt32(value); break;
                    case "PriorityId" : _PriorityId = Convert.ToString(value); break;
                    case "IPAddress" : _IPAddress = Convert.ToString(value); break;
                    case "TargetURL" : _TargetURL = Convert.ToString(value); break;
                    case "Description" : _Description = Convert.ToString(value); break;
                    case "DeletionStateCode" : _DeletionStateCode = Convert.ToInt32(value); break;
                    case "Enabled" : _Enabled = Convert.ToInt32(value); break;
                    case "SortCode" : _SortCode = Convert.ToInt32(value); break;
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
        /// <summary>取得基地InnoDBfree:29696kB;(`post_id`)REFER`wbtoolkit/tbl_post`(`id`)ONDELETECA字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>编号</summary>
            public static readonly Field Id = FindByName("Id");

            ///<summary>父编号</summary>
            public static readonly Field ParentId = FindByName("ParentId");

            ///<summary>分类栏目代码</summary>
            public static readonly Field CategoryCode = FindByName("CategoryCode");

            ///<summary>费用对象ID</summary>
            public static readonly Field ObjectId = FindByName("ObjectId");

            ///<summary>分类名称</summary>
            public static readonly Field Title = FindByName("Title");

            ///<summary>工作</summary>
            public static readonly Field Worked = FindByName("Worked");

            ///<summary>内容</summary>
            public static readonly Field Contents = FindByName("Contents");

            ///<summary>重要</summary>
            public static readonly Field Important = FindByName("Important");

            ///<summary>优先级编号</summary>
            public static readonly Field PriorityId = FindByName("PriorityId");

            ///<summary>地址地址</summary>
            public static readonly Field IPAddress = FindByName("IPAddress");

            ///<summary>目标链接</summary>
            public static readonly Field TargetURL = FindByName("TargetURL");

            ///<summary>描述</summary>
            public static readonly Field Description = FindByName("Description");

            ///<summary>用户是否删除</summary>
            public static readonly Field DeletionStateCode = FindByName("DeletionStateCode");

            ///<summary>是否可用</summary>
            public static readonly Field Enabled = FindByName("Enabled");

            ///<summary>排序号</summary>
            public static readonly Field SortCode = FindByName("SortCode");

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

    /// <summary>基地InnoDBfree:29696kB;(`post_id`)REFER`wbtoolkit/tbl_post`(`id`)ONDELETECA接口</summary>
    public partial interface IBase_Comment
    {
        #region 属性
        /// <summary>编号</summary>
        String Id { get; set; }

        /// <summary>父编号</summary>
        String ParentId { get; set; }

        /// <summary>分类栏目代码</summary>
        String CategoryCode { get; set; }

        /// <summary>费用对象ID</summary>
        String ObjectId { get; set; }

        /// <summary>分类名称</summary>
        String Title { get; set; }

        /// <summary>工作</summary>
        Int32 Worked { get; set; }

        /// <summary>内容</summary>
        String Contents { get; set; }

        /// <summary>重要</summary>
        Int32 Important { get; set; }

        /// <summary>优先级编号</summary>
        String PriorityId { get; set; }

        /// <summary>地址地址</summary>
        String IPAddress { get; set; }

        /// <summary>目标链接</summary>
        String TargetURL { get; set; }

        /// <summary>描述</summary>
        String Description { get; set; }

        /// <summary>用户是否删除</summary>
        Int32 DeletionStateCode { get; set; }

        /// <summary>是否可用</summary>
        Int32 Enabled { get; set; }

        /// <summary>排序号</summary>
        Int32 SortCode { get; set; }

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