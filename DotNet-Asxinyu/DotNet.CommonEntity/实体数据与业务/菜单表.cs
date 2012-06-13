using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace DotNet.CommonEntity
{
    /// <summary>菜单表</summary>
    [Serializable]
    [DataObject]
    [Description("菜单表")]
    [BindIndex("PRIMARY", true, "Id")]
    [BindIndex("MenuName", false, "MenuName")]
    [BindIndex("DbName", false, "DbName")]
    [BindIndex("TableName", false, "TableName")]
    [BindTable("Menu", Description = "菜单表", ConnName = "DotNetCommon", DbType = DatabaseType.MySql)]
    public partial class Menu<TEntity> : IMenu
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

        private Int32 _ParentId;
        /// <summary>父编号</summary>
        [DisplayName("父编号")]
        [Description("父编号")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(2, "ParentId", "父编号", null, "int(11)", 10, 0, false)]
        public virtual Int32 ParentId
        {
            get { return _ParentId; }
            set { if (OnPropertyChanging("ParentId", value)) { _ParentId = value; OnPropertyChanged("ParentId"); } }
        }

        private String _DbName;
        /// <summary>数据库名称</summary>
        [DisplayName("数据库名称")]
        [Description("数据库名称")]
        [DataObjectField(false, false, false, 20)]
        [BindColumn(3, "DbName", "数据库名称", null, "varchar(20)", 0, 0, false)]
        public virtual String DbName
        {
            get { return _DbName; }
            set { if (OnPropertyChanging("DbName", value)) { _DbName = value; OnPropertyChanged("DbName"); } }
        }

        private String _TableName;
        /// <summary>表名称</summary>
        [DisplayName("表名称")]
        [Description("表名称")]
        [DataObjectField(false, false, false, 30)]
        [BindColumn(4, "TableName", "表名称", null, "varchar(30)", 0, 0, false)]
        public virtual String TableName
        {
            get { return _TableName; }
            set { if (OnPropertyChanging("TableName", value)) { _TableName = value; OnPropertyChanged("TableName"); } }
        }

        private String _MenuName;
        /// <summary>菜单名称</summary>
        [DisplayName("菜单名称")]
        [Description("菜单名称")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(5, "MenuName", "菜单名称", null, "varchar(50)", 0, 0, false)]
        public virtual String MenuName
        {
            get { return _MenuName; }
            set { if (OnPropertyChanging("MenuName", value)) { _MenuName = value; OnPropertyChanged("MenuName"); } }
        }

        private String _Url;
        /// <summary>链接</summary>
        [DisplayName("链接")]
        [Description("链接")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(6, "Url", "链接", null, "varchar(100)", 0, 0, false)]
        public virtual String Url
        {
            get { return _Url; }
            set { if (OnPropertyChanging("Url", value)) { _Url = value; OnPropertyChanged("Url"); } }
        }

        private String _IconsUrl;
        /// <summary> 图标链接</summary>
        [DisplayName("图标链接")]
        [Description(" 图标链接")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(7, "IconsUrl", " 图标链接", null, "varchar(100)", 0, 0, false)]
        public virtual String IconsUrl
        {
            get { return _IconsUrl; }
            set { if (OnPropertyChanging("IconsUrl", value)) { _IconsUrl = value; OnPropertyChanged("IconsUrl"); } }
        }

        private Int32 _SortCode;
        /// <summary>排序码</summary>
        [DisplayName("排序码")]
        [Description("排序码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(8, "SortCode", "排序码", "9999", "int(11)", 10, 0, false)]
        public virtual Int32 SortCode
        {
            get { return _SortCode; }
            set { if (OnPropertyChanging("SortCode", value)) { _SortCode = value; OnPropertyChanged("SortCode"); } }
        }

        private SByte _IsEnable;
        /// <summary>是否有效</summary>
        [DisplayName("是否有效")]
        [Description("是否有效")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(9, "IsEnable", "是否有效", "1", "tinyint(4)", 3, 0, false)]
        public virtual SByte IsEnable
        {
            get { return _IsEnable; }
            set { if (OnPropertyChanging("IsEnable", value)) { _IsEnable = value; OnPropertyChanged("IsEnable"); } }
        }

        private String _Description;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(10, "Description", "备注", "", "varchar(50)", 0, 0, false)]
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
                    case "ParentId" : return _ParentId;
                    case "DbName" : return _DbName;
                    case "TableName" : return _TableName;
                    case "MenuName" : return _MenuName;
                    case "Url" : return _Url;
                    case "IconsUrl" : return _IconsUrl;
                    case "SortCode" : return _SortCode;
                    case "IsEnable" : return _IsEnable;
                    case "Description" : return _Description;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id" : _Id = Convert.ToInt32(value); break;
                    case "ParentId" : _ParentId = Convert.ToInt32(value); break;
                    case "DbName" : _DbName = Convert.ToString(value); break;
                    case "TableName" : _TableName = Convert.ToString(value); break;
                    case "MenuName" : _MenuName = Convert.ToString(value); break;
                    case "Url" : _Url = Convert.ToString(value); break;
                    case "IconsUrl" : _IconsUrl = Convert.ToString(value); break;
                    case "SortCode" : _SortCode = Convert.ToInt32(value); break;
                    case "IsEnable" : _IsEnable = Convert.ToSByte(value); break;
                    case "Description" : _Description = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得菜单表字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>编号</summary>
            public static readonly Field Id = FindByName("Id");

            ///<summary>父编号</summary>
            public static readonly Field ParentId = FindByName("ParentId");

            ///<summary>数据库名称</summary>
            public static readonly Field DbName = FindByName("DbName");

            ///<summary>表名称</summary>
            public static readonly Field TableName = FindByName("TableName");

            ///<summary>菜单名称</summary>
            public static readonly Field MenuName = FindByName("MenuName");

            ///<summary>链接</summary>
            public static readonly Field Url = FindByName("Url");

            ///<summary> 图标链接</summary>
            public static readonly Field IconsUrl = FindByName("IconsUrl");

            ///<summary>排序码</summary>
            public static readonly Field SortCode = FindByName("SortCode");

            ///<summary>是否有效</summary>
            public static readonly Field IsEnable = FindByName("IsEnable");

            ///<summary>备注</summary>
            public static readonly Field Description = FindByName("Description");

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }
        #endregion
    }

    /// <summary>菜单表接口</summary>
    public partial interface IMenu
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 Id { get; set; }

        /// <summary>父编号</summary>
        Int32 ParentId { get; set; }

        /// <summary>数据库名称</summary>
        String DbName { get; set; }

        /// <summary>表名称</summary>
        String TableName { get; set; }

        /// <summary>菜单名称</summary>
        String MenuName { get; set; }

        /// <summary>链接</summary>
        String Url { get; set; }

        /// <summary> 图标链接</summary>
        String IconsUrl { get; set; }

        /// <summary>排序码</summary>
        Int32 SortCode { get; set; }

        /// <summary>是否有效</summary>
        SByte IsEnable { get; set; }

        /// <summary>备注</summary>
        String Description { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}