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
    /// <summary>白土车间检测</summary>
    [Serializable]
    [DataObject]
    [Description("白土车间检测")]
    [BindIndex("PRIMARY", true, "ID")]
    [BindTable("tb_BtTestData", Description = "白土车间检测", ConnName = "YoungRunMIS", DbType = DatabaseType.MySql)]
    public partial class tb_BtTestData : Itb_BtTestData
    
    {
        #region 属性
        private String _ID;
        /// <summary>数据编号</summary>
        [DisplayName("数据编号")]
        [Description("数据编号")]
        [DataObjectField(true, false, false, 20)]
        [BindColumn(1, "ID", "数据编号", null, "varchar(20)", 0, 0, false)]
        public virtual String ID
        {
            get { return _ID; }
            set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } }
        }

        private String _ProductNameTP;
        /// <summary>产品名称</summary>
        [DisplayName("产品名称")]
        [Description("产品名称")]
        [DataObjectField(false, false, false, 20)]
        [BindColumn(2, "ProductNameTP", "产品名称", null, "varchar(20)", 0, 0, false)]
        public virtual String ProductNameTP
        {
            get { return _ProductNameTP; }
            set { if (OnPropertyChanging("ProductNameTP", value)) { _ProductNameTP = value; OnPropertyChanged("ProductNameTP"); } }
        }

        private Double _V40;
        /// <summary>V40</summary>
        [DisplayName("V40")]
        [Description("V40")]
        [DataObjectField(false, false, true, 22)]
        [BindColumn(3, "V40", "V40", "-1", "double", 22, 0, false)]
        public virtual Double V40
        {
            get { return _V40; }
            set { if (OnPropertyChanging("V40", value)) { _V40 = value; OnPropertyChanged("V40"); } }
        }

        private Double _V100;
        /// <summary>V100</summary>
        [DisplayName("V100")]
        [Description("V100")]
        [DataObjectField(false, false, true, 22)]
        [BindColumn(4, "V100", "V100", "-1", "double", 22, 0, false)]
        public virtual Double V100
        {
            get { return _V100; }
            set { if (OnPropertyChanging("V100", value)) { _V100 = value; OnPropertyChanged("V100"); } }
        }

        private Int32 _VI;
        /// <summary>粘度指数</summary>
        [DisplayName("粘度指数")]
        [Description("粘度指数")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(5, "VI", "粘度指数", "-1", "int(10)", 10, 0, false)]
        public virtual Int32 VI
        {
            get { return _VI; }
            set { if (OnPropertyChanging("VI", value)) { _VI = value; OnPropertyChanged("VI"); } }
        }

        private Double _AV;
        /// <summary>酸值</summary>
        [DisplayName("酸值")]
        [Description("酸值")]
        [DataObjectField(false, false, true, 22)]
        [BindColumn(6, "AV", "酸值", "-1", "double", 22, 0, false)]
        public virtual Double AV
        {
            get { return _AV; }
            set { if (OnPropertyChanging("AV", value)) { _AV = value; OnPropertyChanged("AV"); } }
        }

        private String _ASTM;
        /// <summary>色度</summary>
        [DisplayName("色度")]
        [Description("色度")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(7, "ASTM", "色度", null, "varchar(20)", 0, 0, false)]
        public virtual String ASTM
        {
            get { return _ASTM; }
            set { if (OnPropertyChanging("ASTM", value)) { _ASTM = value; OnPropertyChanged("ASTM"); } }
        }

        private String _Others;
        /// <summary>其他</summary>
        [DisplayName("其他")]
        [Description("其他")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(8, "Others", "其他", null, "varchar(50)", 0, 0, false)]
        public virtual String Others
        {
            get { return _Others; }
            set { if (OnPropertyChanging("Others", value)) { _Others = value; OnPropertyChanged("Others"); } }
        }

        private DateTime _GetSampleTime;
        /// <summary>采样时间</summary>
        [DisplayName("采样时间")]
        [Description("采样时间")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn(9, "GetSampleTime", "采样时间", null, "datetime", 0, 0, false)]
        public virtual DateTime GetSampleTime
        {
            get { return _GetSampleTime; }
            set { if (OnPropertyChanging("GetSampleTime", value)) { _GetSampleTime = value; OnPropertyChanged("GetSampleTime"); } }
        }

        private String _GetSamLocationTP;
        /// <summary>采样地点</summary>
        [DisplayName("采样地点")]
        [Description("采样地点")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(10, "GetSamLocationTP", "采样地点", "", "varchar(10)", 0, 0, false)]
        public virtual String GetSamLocationTP
        {
            get { return _GetSamLocationTP; }
            set { if (OnPropertyChanging("GetSamLocationTP", value)) { _GetSamLocationTP = value; OnPropertyChanged("GetSamLocationTP"); } }
        }

        private String _GetSampPersonTP;
        /// <summary>采样人</summary>
        [DisplayName("采样人")]
        [Description("采样人")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(11, "GetSampPersonTP", "采样人", "", "varchar(20)", 0, 0, false)]
        public virtual String GetSampPersonTP
        {
            get { return _GetSampPersonTP; }
            set { if (OnPropertyChanging("GetSampPersonTP", value)) { _GetSampPersonTP = value; OnPropertyChanged("GetSampPersonTP"); } }
        }

        private String _TestPersonTP;
        /// <summary>检测人</summary>
        [DisplayName("检测人")]
        [Description("检测人")]
        [DataObjectField(false, false, false, 20)]
        [BindColumn(12, "TestPersonTP", "检测人", "", "varchar(20)", 0, 0, false)]
        public virtual String TestPersonTP
        {
            get { return _TestPersonTP; }
            set { if (OnPropertyChanging("TestPersonTP", value)) { _TestPersonTP = value; OnPropertyChanged("TestPersonTP"); } }
        }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn(13, "UpdateTime", "更新时间", null, "datetime", 0, 0, false)]
        public virtual DateTime UpdateTime
        {
            get { return _UpdateTime; }
            set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(14, "Remark", "备注", null, "varchar(100)", 0, 0, false)]
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
                    case "ProductNameTP" : return _ProductNameTP;
                    case "V40" : return _V40;
                    case "V100" : return _V100;
                    case "VI" : return _VI;
                    case "AV" : return _AV;
                    case "ASTM" : return _ASTM;
                    case "Others" : return _Others;
                    case "GetSampleTime" : return _GetSampleTime;
                    case "GetSamLocationTP" : return _GetSamLocationTP;
                    case "GetSampPersonTP" : return _GetSampPersonTP;
                    case "TestPersonTP" : return _TestPersonTP;
                    case "UpdateTime" : return _UpdateTime;
                    case "Remark" : return _Remark;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "ID" : _ID = Convert.ToString(value); break;
                    case "ProductNameTP" : _ProductNameTP = Convert.ToString(value); break;
                    case "V40" : _V40 = Convert.ToDouble(value); break;
                    case "V100" : _V100 = Convert.ToDouble(value); break;
                    case "VI" : _VI = Convert.ToInt32(value); break;
                    case "AV" : _AV = Convert.ToDouble(value); break;
                    case "ASTM" : _ASTM = Convert.ToString(value); break;
                    case "Others" : _Others = Convert.ToString(value); break;
                    case "GetSampleTime" : _GetSampleTime = Convert.ToDateTime(value); break;
                    case "GetSamLocationTP" : _GetSamLocationTP = Convert.ToString(value); break;
                    case "GetSampPersonTP" : _GetSampPersonTP = Convert.ToString(value); break;
                    case "TestPersonTP" : _TestPersonTP = Convert.ToString(value); break;
                    case "UpdateTime" : _UpdateTime = Convert.ToDateTime(value); break;
                    case "Remark" : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得白土车间检测字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>数据编号</summary>
            public static readonly FieldItem ID = Meta.Table.FindByName("ID");

            ///<summary>产品名称</summary>
            public static readonly FieldItem ProductNameTP = Meta.Table.FindByName("ProductNameTP");

            ///<summary>V40</summary>
            public static readonly FieldItem V40 = Meta.Table.FindByName("V40");

            ///<summary>V100</summary>
            public static readonly FieldItem V100 = Meta.Table.FindByName("V100");

            ///<summary>粘度指数</summary>
            public static readonly FieldItem VI = Meta.Table.FindByName("VI");

            ///<summary>酸值</summary>
            public static readonly FieldItem AV = Meta.Table.FindByName("AV");

            ///<summary>色度</summary>
            public static readonly FieldItem ASTM = Meta.Table.FindByName("ASTM");

            ///<summary>其他</summary>
            public static readonly FieldItem Others = Meta.Table.FindByName("Others");

            ///<summary>采样时间</summary>
            public static readonly FieldItem GetSampleTime = Meta.Table.FindByName("GetSampleTime");

            ///<summary>采样地点</summary>
            public static readonly FieldItem GetSamLocationTP = Meta.Table.FindByName("GetSamLocationTP");

            ///<summary>采样人</summary>
            public static readonly FieldItem GetSampPersonTP = Meta.Table.FindByName("GetSampPersonTP");

            ///<summary>检测人</summary>
            public static readonly FieldItem TestPersonTP = Meta.Table.FindByName("TestPersonTP");

            ///<summary>更新时间</summary>
            public static readonly FieldItem UpdateTime = Meta.Table.FindByName("UpdateTime");

            ///<summary>备注</summary>
            public static readonly FieldItem Remark = Meta.Table.FindByName("Remark");
        }
        #endregion
    }

    /// <summary>白土车间检测接口</summary>
    public partial interface Itb_BtTestData
    {
        #region 属性
        /// <summary>数据编号</summary>
        String ID { get; set; }

        /// <summary>产品名称</summary>
        String ProductNameTP { get; set; }

        /// <summary>V40</summary>
        Double V40 { get; set; }

        /// <summary>V100</summary>
        Double V100 { get; set; }

        /// <summary>粘度指数</summary>
        Int32 VI { get; set; }

        /// <summary>酸值</summary>
        Double AV { get; set; }

        /// <summary>色度</summary>
        String ASTM { get; set; }

        /// <summary>其他</summary>
        String Others { get; set; }

        /// <summary>采样时间</summary>
        DateTime GetSampleTime { get; set; }

        /// <summary>采样地点</summary>
        String GetSamLocationTP { get; set; }

        /// <summary>采样人</summary>
        String GetSampPersonTP { get; set; }

        /// <summary>检测人</summary>
        String TestPersonTP { get; set; }

        /// <summary>更新时间</summary>
        DateTime UpdateTime { get; set; }

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