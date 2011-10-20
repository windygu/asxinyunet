/*
 * XCoder v4.3.2011.0915
 * 作者：Administrator/PC2010081511LNR
 * 时间：2011-10-07 13:25:05
 * 版权：版权所有 (C) 新生命开发团队 2011
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace YoungRunEntity
{
    /// <summary>油样检测数据表</summary>
    [Serializable]
    [DataObject]
    [Description("油样检测数据表")]
    [BindTable("tb_oilsampletest", Description = "油样检测数据表", ConnName = "YoungRunMIS", DbType = DatabaseType.MySql)]
    public partial class tb_oilsampletest : Itb_oilsampletest
    
    {
        #region 属性
        private String _ID;
        /// <summary>记录编号</summary>
        [DisplayName("记录编号")]
        [Description("记录编号")]
        [DataObjectField(true, false, false, 20)]
        [BindColumn(1, "ID", "记录编号", null, "varchar(20)", 0, 0, false)]
        public String ID
        {
            get { return _ID; }
            set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } }
        }

        private String _RecordType;
        /// <summary>记录类型</summary>
        [DisplayName("记录类型")]
        [Description("记录类型")]
        [DataObjectField(false, false, true, 16)]
        [BindColumn(2, "RecordType", "记录类型", null, "varchar(16)", 0, 0, false)]
        public String RecordType
        {
            get { return _RecordType; }
            set { if (OnPropertyChanging("RecordType", value)) { _RecordType = value; OnPropertyChanged("RecordType"); } }
        }

        private String _OilName;
        /// <summary>油品名称</summary>
        [DisplayName("油品名称")]
        [Description("油品名称")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(3, "OilName", "油品名称", null, "varchar(20)", 0, 0, false)]
        public String OilName
        {
            get { return _OilName; }
            set { if (OnPropertyChanging("OilName", value)) { _OilName = value; OnPropertyChanged("OilName"); } }
        }

        private String _Provider;
        /// <summary>供应方</summary>
        [DisplayName("供应方")]
        [Description("供应方")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(4, "Provider", "供应方", null, "varchar(20)", 0, 0, false)]
        public String Provider
        {
            get { return _Provider; }
            set { if (OnPropertyChanging("Provider", value)) { _Provider = value; OnPropertyChanged("Provider"); } }
        }

        private String _DataID;
        /// <summary>数据编号</summary>
        [DisplayName("数据编号")]
        [Description("数据编号")]
        [DataObjectField(false, false, false, 20)]
        [BindColumn(5, "DataID", "数据编号", null, "varchar(20)", 0, 0, false)]
        public String DataID
        {
            get { return _DataID; }
            set { if (OnPropertyChanging("DataID", value)) { _DataID = value; OnPropertyChanged("DataID"); } }
        }

        private String _SendPerson;
        /// <summary>送样人</summary>
        [DisplayName("送样人")]
        [Description("送样人")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(6, "SendPerson", "送样人", null, "varchar(20)", 0, 0, false)]
        public String SendPerson
        {
            get { return _SendPerson; }
            set { if (OnPropertyChanging("SendPerson", value)) { _SendPerson = value; OnPropertyChanged("SendPerson"); } }
        }

        private DateTime _SendDateTime;
        /// <summary>送样时间</summary>
        [DisplayName("送样时间")]
        [Description("送样时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn(7, "SendDateTime", "送样时间", null, "datetime", 0, 0, false)]
        public DateTime SendDateTime
        {
            get { return _SendDateTime; }
            set { if (OnPropertyChanging("SendDateTime", value)) { _SendDateTime = value; OnPropertyChanged("SendDateTime"); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(8, "Remark", "备注", null, "varchar(50)", 0, 0, false)]
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
                    case "ID" : return _ID;
                    case "RecordType" : return _RecordType;
                    case "OilName" : return _OilName;
                    case "Provider" : return _Provider;
                    case "DataID" : return _DataID;
                    case "SendPerson" : return _SendPerson;
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
                    case "RecordType" : _RecordType = Convert.ToString(value); break;
                    case "OilName" : _OilName = Convert.ToString(value); break;
                    case "Provider" : _Provider = Convert.ToString(value); break;
                    case "DataID" : _DataID = Convert.ToString(value); break;
                    case "SendPerson" : _SendPerson = Convert.ToString(value); break;
                    case "SendDateTime" : _SendDateTime = Convert.ToDateTime(value); break;
                    case "Remark" : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得油样检测数据表字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>记录编号</summary>
            public static readonly FieldItem ID = Meta.Table.FindByName("ID");

            ///<summary>记录类型</summary>
            public static readonly FieldItem RecordType = Meta.Table.FindByName("RecordType");

            ///<summary>油品名称</summary>
            public static readonly FieldItem OilName = Meta.Table.FindByName("OilName");

            ///<summary>供应方</summary>
            public static readonly FieldItem Provider = Meta.Table.FindByName("Provider");

            ///<summary>数据编号</summary>
            public static readonly FieldItem DataID = Meta.Table.FindByName("DataID");

            ///<summary>送样人</summary>
            public static readonly FieldItem SendPerson = Meta.Table.FindByName("SendPerson");

            ///<summary>送样时间</summary>
            public static readonly FieldItem SendDateTime = Meta.Table.FindByName("SendDateTime");

            ///<summary>备注</summary>
            public static readonly FieldItem Remark = Meta.Table.FindByName("Remark");
        }
        #endregion
    }

    /// <summary>油样检测数据表接口</summary>
    public partial interface Itb_oilsampletest
    {
        #region 属性
        /// <summary>记录编号</summary>
        String ID { get; set; }

        /// <summary>记录类型</summary>
        String RecordType { get; set; }

        /// <summary>油品名称</summary>
        String OilName { get; set; }

        /// <summary>供应方</summary>
        String Provider { get; set; }

        /// <summary>数据编号</summary>
        String DataID { get; set; }

        /// <summary>送样人</summary>
        String SendPerson { get; set; }

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