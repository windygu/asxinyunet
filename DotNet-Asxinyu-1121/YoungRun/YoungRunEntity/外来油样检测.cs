using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using System.Xml.Serialization;
using XCode.Configuration;
using XCode.DataAccessLayer;

#pragma warning disable 3021
#pragma warning disable 3008
namespace YoungRunEntity
{
    /// <summary>外来油样检测</summary>
    [Serializable]
    [DataObject]
    [Description("外来油样检测")]
    [BindIndex("PRIMARY", true, "ID")]
    [BindTable("tb_OutSampleTest", Description = "外来油样检测", ConnName = "YoungRunMIS", DbType = DatabaseType.MySql)]
    public partial class tb_OutSampleTest : Itb_OutSampleTest
    
    {
        #region 属性
        private String _ID;
        /// <summary>记录编号</summary>
        [DisplayName("记录编号")]
        [Description("记录编号")]
        [DataObjectField(true, false, false, 20)]
        [BindColumn(1, "ID", "记录编号", null, "varchar(20)", 0, 0, false)]
        public virtual String ID
        {
            get { return _ID; }
            set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } }
        }

        private String _OilName;
        /// <summary>油品名称</summary>
        [DisplayName("油品名称")]
        [Description("油品名称")]
        [DataObjectField(false, false, false, 20)]
        [BindColumn(2, "OilName", "油品名称", null, "varchar(20)", 0, 0, false)]
        public virtual String OilName
        {
            get { return _OilName; }
            set { if (OnPropertyChanging("OilName", value)) { _OilName = value; OnPropertyChanged("OilName"); } }
        }

        private String _DataID;
        /// <summary>数据编号</summary>
        [DisplayName("数据编号")]
        [Description("数据编号")]
        [DataObjectField(false, false, false, 20)]
        [BindColumn(3, "DataID", "数据编号", null, "varchar(20)", 0, 0, false)]
        public virtual String DataID
        {
            get { return _DataID; }
            set { if (OnPropertyChanging("DataID", value)) { _DataID = value; OnPropertyChanged("DataID"); } }
        }

        private String _SendPersonTP;
        /// <summary>送样人</summary>
        [DisplayName("送样人")]
        [Description("送样人")]
        [DataObjectField(false, false, false, 20)]
        [BindColumn(4, "SendPersonTP", "送样人", null, "varchar(20)", 0, 0, false)]
        public virtual String SendPersonTP
        {
            get { return _SendPersonTP; }
            set { if (OnPropertyChanging("SendPersonTP", value)) { _SendPersonTP = value; OnPropertyChanged("SendPersonTP"); } }
        }

        private DateTime _SendDateTime;
        /// <summary>送样时间</summary>
        [DisplayName("送样时间")]
        [Description("送样时间")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn(5, "SendDateTime", "送样时间", null, "datetime", 0, 0, false)]
        public virtual DateTime SendDateTime
        {
            get { return _SendDateTime; }
            set { if (OnPropertyChanging("SendDateTime", value)) { _SendDateTime = value; OnPropertyChanged("SendDateTime"); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(6, "Remark", "备注", null, "varchar(50)", 0, 0, false)]
        public virtual String Remark
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
                    case "ID" : return _ID;
                    case "OilName" : return _OilName;
                    case "DataID" : return _DataID;
                    case "SendPersonTP" : return _SendPersonTP;
                    case "SendDateTime" : return _SendDateTime;
                    case "Remark" : return _Remark;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "ID" : _ID = Convert.ToString(value); break;
                    case "OilName" : _OilName = Convert.ToString(value); break;
                    case "DataID" : _DataID = Convert.ToString(value); break;
                    case "SendPersonTP" : _SendPersonTP = Convert.ToString(value); break;
                    case "SendDateTime" : _SendDateTime = Convert.ToDateTime(value); break;
                    case "Remark" : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得外来油样检测字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>记录编号</summary>
            public static readonly FieldItem ID = Meta.Table.FindByName("ID");

            ///<summary>油品名称</summary>
            public static readonly FieldItem OilName = Meta.Table.FindByName("OilName");

            ///<summary>数据编号</summary>
            public static readonly FieldItem DataID = Meta.Table.FindByName("DataID");

            ///<summary>送样人</summary>
            public static readonly FieldItem SendPersonTP = Meta.Table.FindByName("SendPersonTP");

            ///<summary>送样时间</summary>
            public static readonly FieldItem SendDateTime = Meta.Table.FindByName("SendDateTime");

            ///<summary>备注</summary>
            public static readonly FieldItem Remark = Meta.Table.FindByName("Remark");
        }
        #endregion
    }

    /// <summary>外来油样检测接口</summary>
    public partial interface Itb_OutSampleTest
    {
        #region 属性
        /// <summary>记录编号</summary>
        String ID { get; set; }

        /// <summary>油品名称</summary>
        String OilName { get; set; }

        /// <summary>数据编号</summary>
        String DataID { get; set; }

        /// <summary>送样人</summary>
        String SendPersonTP { get; set; }

        /// <summary>送样时间</summary>
        DateTime SendDateTime { get; set; }

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
#pragma warning restore 3008
#pragma warning restore 3021