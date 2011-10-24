using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace YoungRunEntity
{
    /// <summary>用户信息表</summary>
    [Serializable]
    [DataObject]
    [Description("用户信息表")]
    [BindIndex("PRIMARY", true, "UserName")]
    [BindTable("tb_user", Description = "用户信息表", ConnName = "YoungRunMIS", DbType = DatabaseType.MySql)]
    public partial class tb_user : Itb_user
    
    {
        #region 属性
        private String _UserName;
        /// <summary>用户名</summary>
        [DisplayName("用户名")]
        [Description("用户名")]
        [DataObjectField(true, false, false, 20)]
        [BindColumn(1, "UserName", "用户名", null, "varchar(20)", 0, 0, false)]
        public String UserName
        {
            get { return _UserName; }
            set { if (OnPropertyChanging("UserName", value)) { _UserName = value; OnPropertyChanged("UserName"); } }
        }

        private String _PassWord;
        /// <summary>密码</summary>
        [DisplayName("密码")]
        [Description("密码")]
        [DataObjectField(false, false, false, 60)]
        [BindColumn(2, "PassWord", "密码", null, "varchar(60)", 0, 0, false)]
        public String PassWord
        {
            get { return _PassWord; }
            set { if (OnPropertyChanging("PassWord", value)) { _PassWord = value; OnPropertyChanged("PassWord"); } }
        }

        private String _DepartMent;
        /// <summary>部门</summary>
        [DisplayName("部门")]
        [Description("部门")]
        [DataObjectField(false, false, false, 20)]
        [BindColumn(3, "DepartMent", "部门", null, "varchar(20)", 0, 0, false)]
        public String DepartMent
        {
            get { return _DepartMent; }
            set { if (OnPropertyChanging("DepartMent", value)) { _DepartMent = value; OnPropertyChanged("DepartMent"); } }
        }

        private String _Name;
        /// <summary>姓名</summary>
        [DisplayName("姓名")]
        [Description("姓名")]
        [DataObjectField(false, false, false, 20)]
        [BindColumn(4, "Name", "姓名", null, "varchar(20)", 0, 0, false)]
        public String Name
        {
            get { return _Name; }
            set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } }
        }

        private String _Tel;
        /// <summary>联系电话</summary>
        [DisplayName("联系电话")]
        [Description("联系电话")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn(5, "Tel", "联系电话", null, "varchar(30)", 0, 0, false)]
        public String Tel
        {
            get { return _Tel; }
            set { if (OnPropertyChanging("Tel", value)) { _Tel = value; OnPropertyChanged("Tel"); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 65535)]
        [BindColumn(6, "Remark", "备注", null, "text", 0, 0, false)]
        public String Remark
        {
            get { return _Remark; }
            set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } }
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
                    case "UserName" : return _UserName;
                    case "PassWord" : return _PassWord;
                    case "DepartMent" : return _DepartMent;
                    case "Name" : return _Name;
                    case "Tel" : return _Tel;
                    case "Remark" : return _Remark;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "UserName" : _UserName = Convert.ToString(value); break;
                    case "PassWord" : _PassWord = Convert.ToString(value); break;
                    case "DepartMent" : _DepartMent = Convert.ToString(value); break;
                    case "Name" : _Name = Convert.ToString(value); break;
                    case "Tel" : _Tel = Convert.ToString(value); break;
                    case "Remark" : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得用户信息表字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>用户名</summary>
            public static readonly FieldItem UserName = Meta.Table.FindByName("UserName");

            ///<summary>密码</summary>
            public static readonly FieldItem PassWord = Meta.Table.FindByName("PassWord");

            ///<summary>部门</summary>
            public static readonly FieldItem DepartMent = Meta.Table.FindByName("DepartMent");

            ///<summary>姓名</summary>
            public static readonly FieldItem Name = Meta.Table.FindByName("Name");

            ///<summary>联系电话</summary>
            public static readonly FieldItem Tel = Meta.Table.FindByName("Tel");

            ///<summary>备注</summary>
            public static readonly FieldItem Remark = Meta.Table.FindByName("Remark");
        }
        #endregion
    }

    /// <summary>用户信息表接口</summary>
    public partial interface Itb_user
    {
        #region 属性
        /// <summary>用户名</summary>
        String UserName { get; set; }

        /// <summary>密码</summary>
        String PassWord { get; set; }

        /// <summary>部门</summary>
        String DepartMent { get; set; }

        /// <summary>姓名</summary>
        String Name { get; set; }

        /// <summary>联系电话</summary>
        String Tel { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }
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