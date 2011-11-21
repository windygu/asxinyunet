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
    /// <summary>油品全套指标</summary>
    [Serializable]
    [DataObject]
    [Description("油品全套指标")]
    [BindIndex("PRIMARY", true, "ID")]
    [BindTable("tb_OilData", Description = "油品全套指标", ConnName = "YoungRunMIS", DbType = DatabaseType.MySql)]
    public partial class tb_OilData : Itb_OilData
    
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

        private String _OilNameTP;
        /// <summary>油品名称</summary>
        [DisplayName("油品名称")]
        [Description("油品名称")]
        [DataObjectField(false, false, false, 30)]
        [BindColumn(2, "OilNameTP", "油品名称", null, "varchar(30)", 0, 0, false)]
        public virtual String OilNameTP
        {
            get { return _OilNameTP; }
            set { if (OnPropertyChanging("OilNameTP", value)) { _OilNameTP = value; OnPropertyChanged("OilNameTP"); } }
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

        private Int32 _PP;
        /// <summary>倾点</summary>
        [DisplayName("倾点")]
        [Description("倾点")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(6, "PP", "倾点", "-1", "int(10)", 10, 0, false)]
        public virtual Int32 PP
        {
            get { return _PP; }
            set { if (OnPropertyChanging("PP", value)) { _PP = value; OnPropertyChanged("PP"); } }
        }

        private Int32 _FP;
        /// <summary>闪点</summary>
        [DisplayName("闪点")]
        [Description("闪点")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(7, "FP", "闪点", "-1", "int(10)", 10, 0, false)]
        public virtual Int32 FP
        {
            get { return _FP; }
            set { if (OnPropertyChanging("FP", value)) { _FP = value; OnPropertyChanged("FP"); } }
        }

        private Double _AV;
        /// <summary>酸值</summary>
        [DisplayName("酸值")]
        [Description("酸值")]
        [DataObjectField(false, false, true, 22)]
        [BindColumn(8, "AV", "酸值", "-1", "double", 22, 0, false)]
        public virtual Double AV
        {
            get { return _AV; }
            set { if (OnPropertyChanging("AV", value)) { _AV = value; OnPropertyChanged("AV"); } }
        }

        private Double _WC;
        /// <summary>水分</summary>
        [DisplayName("水分")]
        [Description("水分")]
        [DataObjectField(false, false, true, 22)]
        [BindColumn(9, "WC", "水分", "-1", "double", 22, 0, false)]
        public virtual Double WC
        {
            get { return _WC; }
            set { if (OnPropertyChanging("WC", value)) { _WC = value; OnPropertyChanged("WC"); } }
        }

        private String _ASTM;
        /// <summary>色度</summary>
        [DisplayName("色度")]
        [Description("色度")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(10, "ASTM", "色度", "", "varchar(10)", 0, 0, false)]
        public virtual String ASTM
        {
            get { return _ASTM; }
            set { if (OnPropertyChanging("ASTM", value)) { _ASTM = value; OnPropertyChanged("ASTM"); } }
        }

        private Double _D20;
        /// <summary>密度</summary>
        [DisplayName("密度")]
        [Description("密度")]
        [DataObjectField(false, false, true, 22)]
        [BindColumn(11, "D20", "密度", "-1", "double", 22, 0, false)]
        public virtual Double D20
        {
            get { return _D20; }
            set { if (OnPropertyChanging("D20", value)) { _D20 = value; OnPropertyChanged("D20"); } }
        }

        private Double _MI;
        /// <summary>机械杂质</summary>
        [DisplayName("机械杂质")]
        [Description("机械杂质")]
        [DataObjectField(false, false, true, 22)]
        [BindColumn(12, "MI", "机械杂质", "-1", "double", 22, 0, false)]
        public virtual Double MI
        {
            get { return _MI; }
            set { if (OnPropertyChanging("MI", value)) { _MI = value; OnPropertyChanged("MI"); } }
        }

        private Double _CR;
        /// <summary>残炭</summary>
        [DisplayName("残炭")]
        [Description("残炭")]
        [DataObjectField(false, false, true, 22)]
        [BindColumn(13, "CR", "残炭", "-1", "double", 22, 0, false)]
        public virtual Double CR
        {
            get { return _CR; }
            set { if (OnPropertyChanging("CR", value)) { _CR = value; OnPropertyChanged("CR"); } }
        }

        private String _WAA;
        /// <summary>水溶性酸碱</summary>
        [DisplayName("水溶性酸碱")]
        [Description("水溶性酸碱")]
        [DataObjectField(false, false, true, 15)]
        [BindColumn(14, "WAA", "水溶性酸碱", "", "varchar(15)", 0, 0, false)]
        public virtual String WAA
        {
            get { return _WAA; }
            set { if (OnPropertyChanging("WAA", value)) { _WAA = value; OnPropertyChanged("WAA"); } }
        }

        private String _V;
        /// <summary>低温运动粘度</summary>
        [DisplayName("低温运动粘度")]
        [Description("低温运动粘度")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(15, "V", "低温运动粘度", "", "varchar(50)", 0, 0, false)]
        public virtual String V
        {
            get { return _V; }
            set { if (OnPropertyChanging("V", value)) { _V = value; OnPropertyChanged("V"); } }
        }

        private String _Distillation;
        /// <summary>馏程</summary>
        [DisplayName("馏程")]
        [Description("馏程")]
        [DataObjectField(false, false, true, 60)]
        [BindColumn(16, "Distillation", "馏程", "", "varchar(60)", 0, 0, false)]
        public virtual String Distillation
        {
            get { return _Distillation; }
            set { if (OnPropertyChanging("Distillation", value)) { _Distillation = value; OnPropertyChanged("Distillation"); } }
        }

        private String _XZQD;
        /// <summary>旋转氧弹</summary>
        [DisplayName("旋转氧弹")]
        [Description("旋转氧弹")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(17, "XZQD", "旋转氧弹", "", "varchar(20)", 0, 0, false)]
        public virtual String XZQD
        {
            get { return _XZQD; }
            set { if (OnPropertyChanging("XZQD", value)) { _XZQD = value; OnPropertyChanged("XZQD"); } }
        }

        private String _Other;
        /// <summary>其他指标</summary>
        [DisplayName("其他指标")]
        [Description("其他指标")]
        [DataObjectField(false, false, true, 60)]
        [BindColumn(18, "Other", "其他指标", null, "varchar(60)", 0, 0, false)]
        public virtual String Other
        {
            get { return _Other; }
            set { if (OnPropertyChanging("Other", value)) { _Other = value; OnPropertyChanged("Other"); } }
        }

        private String _TestPersonTP;
        /// <summary>检测人</summary>
        [DisplayName("检测人")]
        [Description("检测人")]
        [DataObjectField(false, false, false, 20)]
        [BindColumn(19, "TestPersonTP", "检测人", null, "varchar(20)", 0, 0, false)]
        public virtual String TestPersonTP
        {
            get { return _TestPersonTP; }
            set { if (OnPropertyChanging("TestPersonTP", value)) { _TestPersonTP = value; OnPropertyChanged("TestPersonTP"); } }
        }

        private String _RecordType;
        /// <summary>记录类型</summary>
        [DisplayName("记录类型")]
        [Description("记录类型")]
        [DataObjectField(false, false, false, 16)]
        [BindColumn(20, "RecordType", "记录类型", null, "varchar(16)", 0, 0, false)]
        public virtual String RecordType
        {
            get { return _RecordType; }
            set { if (OnPropertyChanging("RecordType", value)) { _RecordType = value; OnPropertyChanged("RecordType"); } }
        }

        private DateTime _TestDateTime;
        /// <summary>测试时间</summary>
        [DisplayName("测试时间")]
        [Description("测试时间")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn(21, "TestDateTime", "测试时间", null, "datetime", 0, 0, false)]
        public virtual DateTime TestDateTime
        {
            get { return _TestDateTime; }
            set { if (OnPropertyChanging("TestDateTime", value)) { _TestDateTime = value; OnPropertyChanged("TestDateTime"); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(22, "Remark", "备注", null, "varchar(50)", 0, 0, false)]
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
                    case "OilNameTP" : return _OilNameTP;
                    case "V40" : return _V40;
                    case "V100" : return _V100;
                    case "VI" : return _VI;
                    case "PP" : return _PP;
                    case "FP" : return _FP;
                    case "AV" : return _AV;
                    case "WC" : return _WC;
                    case "ASTM" : return _ASTM;
                    case "D20" : return _D20;
                    case "MI" : return _MI;
                    case "CR" : return _CR;
                    case "WAA" : return _WAA;
                    case "V" : return _V;
                    case "Distillation" : return _Distillation;
                    case "XZQD" : return _XZQD;
                    case "Other" : return _Other;
                    case "TestPersonTP" : return _TestPersonTP;
                    case "RecordType" : return _RecordType;
                    case "TestDateTime" : return _TestDateTime;
                    case "Remark" : return _Remark;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "ID" : _ID = Convert.ToString(value); break;
                    case "OilNameTP" : _OilNameTP = Convert.ToString(value); break;
                    case "V40" : _V40 = Convert.ToDouble(value); break;
                    case "V100" : _V100 = Convert.ToDouble(value); break;
                    case "VI" : _VI = Convert.ToInt32(value); break;
                    case "PP" : _PP = Convert.ToInt32(value); break;
                    case "FP" : _FP = Convert.ToInt32(value); break;
                    case "AV" : _AV = Convert.ToDouble(value); break;
                    case "WC" : _WC = Convert.ToDouble(value); break;
                    case "ASTM" : _ASTM = Convert.ToString(value); break;
                    case "D20" : _D20 = Convert.ToDouble(value); break;
                    case "MI" : _MI = Convert.ToDouble(value); break;
                    case "CR" : _CR = Convert.ToDouble(value); break;
                    case "WAA" : _WAA = Convert.ToString(value); break;
                    case "V" : _V = Convert.ToString(value); break;
                    case "Distillation" : _Distillation = Convert.ToString(value); break;
                    case "XZQD" : _XZQD = Convert.ToString(value); break;
                    case "Other" : _Other = Convert.ToString(value); break;
                    case "TestPersonTP" : _TestPersonTP = Convert.ToString(value); break;
                    case "RecordType" : _RecordType = Convert.ToString(value); break;
                    case "TestDateTime" : _TestDateTime = Convert.ToDateTime(value); break;
                    case "Remark" : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得油品全套指标字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>数据编号</summary>
            public static readonly FieldItem ID = Meta.Table.FindByName("ID");

            ///<summary>油品名称</summary>
            public static readonly FieldItem OilNameTP = Meta.Table.FindByName("OilNameTP");

            ///<summary>V40</summary>
            public static readonly FieldItem V40 = Meta.Table.FindByName("V40");

            ///<summary>V100</summary>
            public static readonly FieldItem V100 = Meta.Table.FindByName("V100");

            ///<summary>粘度指数</summary>
            public static readonly FieldItem VI = Meta.Table.FindByName("VI");

            ///<summary>倾点</summary>
            public static readonly FieldItem PP = Meta.Table.FindByName("PP");

            ///<summary>闪点</summary>
            public static readonly FieldItem FP = Meta.Table.FindByName("FP");

            ///<summary>酸值</summary>
            public static readonly FieldItem AV = Meta.Table.FindByName("AV");

            ///<summary>水分</summary>
            public static readonly FieldItem WC = Meta.Table.FindByName("WC");

            ///<summary>色度</summary>
            public static readonly FieldItem ASTM = Meta.Table.FindByName("ASTM");

            ///<summary>密度</summary>
            public static readonly FieldItem D20 = Meta.Table.FindByName("D20");

            ///<summary>机械杂质</summary>
            public static readonly FieldItem MI = Meta.Table.FindByName("MI");

            ///<summary>残炭</summary>
            public static readonly FieldItem CR = Meta.Table.FindByName("CR");

            ///<summary>水溶性酸碱</summary>
            public static readonly FieldItem WAA = Meta.Table.FindByName("WAA");

            ///<summary>低温运动粘度</summary>
            public static readonly FieldItem V = Meta.Table.FindByName("V");

            ///<summary>馏程</summary>
            public static readonly FieldItem Distillation = Meta.Table.FindByName("Distillation");

            ///<summary>旋转氧弹</summary>
            public static readonly FieldItem XZQD = Meta.Table.FindByName("XZQD");

            ///<summary>其他指标</summary>
            public static readonly FieldItem Other = Meta.Table.FindByName("Other");

            ///<summary>检测人</summary>
            public static readonly FieldItem TestPersonTP = Meta.Table.FindByName("TestPersonTP");

            ///<summary>记录类型</summary>
            public static readonly FieldItem RecordType = Meta.Table.FindByName("RecordType");

            ///<summary>测试时间</summary>
            public static readonly FieldItem TestDateTime = Meta.Table.FindByName("TestDateTime");

            ///<summary>备注</summary>
            public static readonly FieldItem Remark = Meta.Table.FindByName("Remark");
        }
        #endregion
    }

    /// <summary>油品全套指标接口</summary>
    public partial interface Itb_OilData
    {
        #region 属性
        /// <summary>数据编号</summary>
        String ID { get; set; }

        /// <summary>油品名称</summary>
        String OilNameTP { get; set; }

        /// <summary>V40</summary>
        Double V40 { get; set; }

        /// <summary>V100</summary>
        Double V100 { get; set; }

        /// <summary>粘度指数</summary>
        Int32 VI { get; set; }

        /// <summary>倾点</summary>
        Int32 PP { get; set; }

        /// <summary>闪点</summary>
        Int32 FP { get; set; }

        /// <summary>酸值</summary>
        Double AV { get; set; }

        /// <summary>水分</summary>
        Double WC { get; set; }

        /// <summary>色度</summary>
        String ASTM { get; set; }

        /// <summary>密度</summary>
        Double D20 { get; set; }

        /// <summary>机械杂质</summary>
        Double MI { get; set; }

        /// <summary>残炭</summary>
        Double CR { get; set; }

        /// <summary>水溶性酸碱</summary>
        String WAA { get; set; }

        /// <summary>低温运动粘度</summary>
        String V { get; set; }

        /// <summary>馏程</summary>
        String Distillation { get; set; }

        /// <summary>旋转氧弹</summary>
        String XZQD { get; set; }

        /// <summary>其他指标</summary>
        String Other { get; set; }

        /// <summary>检测人</summary>
        String TestPersonTP { get; set; }

        /// <summary>记录类型</summary>
        String RecordType { get; set; }

        /// <summary>测试时间</summary>
        DateTime TestDateTime { get; set; }

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