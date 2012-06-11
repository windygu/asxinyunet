﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace DotNet.CommonEntity
{
    /// <summary>员工信息表</summary>
    [Serializable]
    [DataObject]
    [Description("员工信息表")]
    [BindIndex("PRIMARY", true, "Id")]
    [BindIndex("OrganizeId", false, "OrganizeId")]
    [BindIndex("UserName", false, "UserName")]
    [BindIndex("Code", false, "Code")]
    [BindIndex("IdCard", false, "IdCard")]
    [BindRelation("OrganizeId", false, "Organize", "Id")]
    [BindRelation("Id", true, "User", "StaffId")]
    [BindTable("Staff", Description = "员工信息表", ConnName = "DotNetCommon", DbType = DatabaseType.MySql)]
    public partial class Staff : IStaff
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

        private Int32 _OrganizeId;
        /// <summary>组织编号</summary>
        [DisplayName("组织编号")]
        [Description("组织编号")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(2, "OrganizeId", "组织编号", null, "int(11)", 10, 0, false)]
        public virtual Int32 OrganizeId
        {
            get { return _OrganizeId; }
            set { if (OnPropertyChanging("OrganizeId", value)) { _OrganizeId = value; OnPropertyChanged("OrganizeId"); } }
        }

        private String _UserName;
        /// <summary>用户名</summary>
        [DisplayName("用户名")]
        [Description("用户名")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(3, "UserName", "用户名", null, "varchar(50)", 0, 0, false)]
        public virtual String UserName
        {
            get { return _UserName; }
            set { if (OnPropertyChanging("UserName", value)) { _UserName = value; OnPropertyChanged("UserName"); } }
        }

        private String _RealName;
        /// <summary>用户名</summary>
        [DisplayName("用户名")]
        [Description("用户名")]
        [DataObjectField(false, false, false, 30)]
        [BindColumn(4, "RealName", "用户名", null, "varchar(30)", 0, 0, false)]
        public virtual String RealName
        {
            get { return _RealName; }
            set { if (OnPropertyChanging("RealName", value)) { _RealName = value; OnPropertyChanged("RealName"); } }
        }

        private String _Code;
        /// <summary>工号</summary>
        [DisplayName("工号")]
        [Description("工号")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "Code", "工号", null, "varchar(50)", 0, 0, false)]
        public virtual String Code
        {
            get { return _Code; }
            set { if (OnPropertyChanging("Code", value)) { _Code = value; OnPropertyChanged("Code"); } }
        }

        private SByte _Sex;
        /// <summary>性别</summary>
        [DisplayName("性别")]
        [Description("性别")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(6, "Sex", "性别", null, "tinyint(4)", 3, 0, false)]
        public virtual SByte Sex
        {
            get { return _Sex; }
            set { if (OnPropertyChanging("Sex", value)) { _Sex = value; OnPropertyChanged("Sex"); } }
        }

        private String _IdCard;
        /// <summary>身份证号</summary>
        [DisplayName("身份证号")]
        [Description("身份证号")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn(7, "IdCard", "身份证号", "", "varchar(30)", 0, 0, false)]
        public virtual String IdCard
        {
            get { return _IdCard; }
            set { if (OnPropertyChanging("IdCard", value)) { _IdCard = value; OnPropertyChanged("IdCard"); } }
        }

        private Int32 _SortCode;
        /// <summary>排序码</summary>
        [DisplayName("排序码")]
        [Description("排序码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(8, "SortCode", "排序码", null, "int(10)", 10, 0, false)]
        public virtual Int32 SortCode
        {
            get { return _SortCode; }
            set { if (OnPropertyChanging("SortCode", value)) { _SortCode = value; OnPropertyChanged("SortCode"); } }
        }

        private SByte _IsEnable;
        /// <summary>是否有效</summary>
        [DisplayName("是否有效")]
        [Description("是否有效")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(9, "IsEnable", "是否有效", "1", "tinyint(4)", 3, 0, false)]
        public virtual SByte IsEnable
        {
            get { return _IsEnable; }
            set { if (OnPropertyChanging("IsEnable", value)) { _IsEnable = value; OnPropertyChanged("IsEnable"); } }
        }

        private SByte _DeletionStatusCode;
        /// <summary>删除标志</summary>
        [DisplayName("删除标志")]
        [Description("删除标志")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(10, "DeletionStatusCode", "删除标志", "0", "tinyint(4)", 3, 0, false)]
        public virtual SByte DeletionStatusCode
        {
            get { return _DeletionStatusCode; }
            set { if (OnPropertyChanging("DeletionStatusCode", value)) { _DeletionStatusCode = value; OnPropertyChanged("DeletionStatusCode"); } }
        }

        private String _Description;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(11, "Description", "备注", "", "varchar(50)", 0, 0, false)]
        public virtual String Description
        {
            get { return _Description; }
            set { if (OnPropertyChanging("Description", value)) { _Description = value; OnPropertyChanged("Description"); } }
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
                    case "OrganizeId" : return _OrganizeId;
                    case "UserName" : return _UserName;
                    case "RealName" : return _RealName;
                    case "Code" : return _Code;
                    case "Sex" : return _Sex;
                    case "IdCard" : return _IdCard;
                    case "SortCode" : return _SortCode;
                    case "IsEnable" : return _IsEnable;
                    case "DeletionStatusCode" : return _DeletionStatusCode;
                    case "Description" : return _Description;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id" : _Id = Convert.ToInt32(value); break;
                    case "OrganizeId" : _OrganizeId = Convert.ToInt32(value); break;
                    case "UserName" : _UserName = Convert.ToString(value); break;
                    case "RealName" : _RealName = Convert.ToString(value); break;
                    case "Code" : _Code = Convert.ToString(value); break;
                    case "Sex" : _Sex = Convert.ToSByte(value); break;
                    case "IdCard" : _IdCard = Convert.ToString(value); break;
                    case "SortCode" : _SortCode = Convert.ToInt32(value); break;
                    case "IsEnable" : _IsEnable = Convert.ToSByte(value); break;
                    case "DeletionStatusCode" : _DeletionStatusCode = Convert.ToSByte(value); break;
                    case "Description" : _Description = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得员工信息表字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>编号</summary>
            public static readonly Field Id = FindByName("Id");

            ///<summary>组织编号</summary>
            public static readonly Field OrganizeId = FindByName("OrganizeId");

            ///<summary>用户名</summary>
            public static readonly Field UserName = FindByName("UserName");

            ///<summary>用户名</summary>
            public static readonly Field RealName = FindByName("RealName");

            ///<summary>工号</summary>
            public static readonly Field Code = FindByName("Code");

            ///<summary>性别</summary>
            public static readonly Field Sex = FindByName("Sex");

            ///<summary>身份证号</summary>
            public static readonly Field IdCard = FindByName("IdCard");

            ///<summary>排序码</summary>
            public static readonly Field SortCode = FindByName("SortCode");

            ///<summary>是否有效</summary>
            public static readonly Field IsEnable = FindByName("IsEnable");

            ///<summary>删除标志</summary>
            public static readonly Field DeletionStatusCode = FindByName("DeletionStatusCode");

            ///<summary>备注</summary>
            public static readonly Field Description = FindByName("Description");

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }
        #endregion
    }

    /// <summary>员工信息表接口</summary>
    public partial interface IStaff
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 Id { get; set; }

        /// <summary>组织编号</summary>
        Int32 OrganizeId { get; set; }

        /// <summary>用户名</summary>
        String UserName { get; set; }

        /// <summary>用户名</summary>
        String RealName { get; set; }

        /// <summary>工号</summary>
        String Code { get; set; }

        /// <summary>性别</summary>
        SByte Sex { get; set; }

        /// <summary>身份证号</summary>
        String IdCard { get; set; }

        /// <summary>排序码</summary>
        Int32 SortCode { get; set; }

        /// <summary>是否有效</summary>
        SByte IsEnable { get; set; }

        /// <summary>删除标志</summary>
        SByte DeletionStatusCode { get; set; }

        /// <summary>备注</summary>
        String Description { get; set; }
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