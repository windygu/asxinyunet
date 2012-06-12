using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace DotNet.CommonEntity
{
    /// <summary>用户配置信息表</summary>
    [Serializable]
    [DataObject]
    [Description("用户配置信息表")]
    [BindIndex("PRIMARY", true, "Id")]
    [BindIndex("UserId", false, "UserId")]
    [BindIndex("Name", false, "UserId,Name")]
    [BindIndex("Description", false, "Description")]
    [BindRelation("UserId", false, "User", "Id")]
    [BindRelation("UserId", false, "User", "Id")]
    [BindTable("UserProfile", Description = "用户配置信息表", ConnName = "DotNetCommon", DbType = DatabaseType.MySql)]
    public partial class UserProfile<TEntity> : IUserProfile
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

        private Int32 _UserId;
        /// <summary>用户编号</summary>
        [DisplayName("用户编号")]
        [Description("用户编号")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(2, "UserId", "用户编号", null, "int(11)", 10, 0, false)]
        public virtual Int32 UserId
        {
            get { return _UserId; }
            set { if (OnPropertyChanging("UserId", value)) { _UserId = value; OnPropertyChanged("UserId"); } }
        }

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(3, "Name", "名称", null, "varchar(50)", 0, 0, false)]
        public virtual String Name
        {
            get { return _Name; }
            set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } }
        }

        private String _Value;
        /// <summary>值</summary>
        [DisplayName("值")]
        [Description("值")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(4, "Value", "值", "", "varchar(100)", 0, 0, false)]
        public virtual String Value
        {
            get { return _Value; }
            set { if (OnPropertyChanging("Value", value)) { _Value = value; OnPropertyChanged("Value"); } }
        }

        private Int32 _SortCode;
        /// <summary>排序码</summary>
        [DisplayName("排序码")]
        [Description("排序码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(5, "SortCode", "排序码", "9999", "int(11)", 10, 0, false)]
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
        [BindColumn(6, "IsEnable", "是否有效", "1", "tinyint(4)", 3, 0, false)]
        public virtual SByte IsEnable
        {
            get { return _IsEnable; }
            set { if (OnPropertyChanging("IsEnable", value)) { _IsEnable = value; OnPropertyChanged("IsEnable"); } }
        }

        private String _Description;
        /// <summary>描述</summary>
        [DisplayName("描述")]
        [Description("描述")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(7, "Description", "描述", "", "varchar(50)", 0, 0, false)]
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
                    case "UserId" : return _UserId;
                    case "Name" : return _Name;
                    case "Value" : return _Value;
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
                    case "UserId" : _UserId = Convert.ToInt32(value); break;
                    case "Name" : _Name = Convert.ToString(value); break;
                    case "Value" : _Value = Convert.ToString(value); break;
                    case "SortCode" : _SortCode = Convert.ToInt32(value); break;
                    case "IsEnable" : _IsEnable = Convert.ToSByte(value); break;
                    case "Description" : _Description = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得用户配置信息表字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>编号</summary>
            public static readonly Field Id = FindByName("Id");

            ///<summary>用户编号</summary>
            public static readonly Field UserId = FindByName("UserId");

            ///<summary>名称</summary>
            public static readonly Field Name = FindByName("Name");

            ///<summary>值</summary>
            public static readonly Field Value = FindByName("Value");

            ///<summary>排序码</summary>
            public static readonly Field SortCode = FindByName("SortCode");

            ///<summary>是否有效</summary>
            public static readonly Field IsEnable = FindByName("IsEnable");

            ///<summary>描述</summary>
            public static readonly Field Description = FindByName("Description");

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }
        #endregion
    }

    /// <summary>用户配置信息表接口</summary>
    public partial interface IUserProfile
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 Id { get; set; }

        /// <summary>用户编号</summary>
        Int32 UserId { get; set; }

        /// <summary>名称</summary>
        String Name { get; set; }

        /// <summary>值</summary>
        String Value { get; set; }

        /// <summary>排序码</summary>
        Int32 SortCode { get; set; }

        /// <summary>是否有效</summary>
        SByte IsEnable { get; set; }

        /// <summary>描述</summary>
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