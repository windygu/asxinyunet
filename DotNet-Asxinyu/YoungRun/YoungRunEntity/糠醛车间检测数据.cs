using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace YoungRunEntity
{
    /// <summary>糠醛车间检测数据</summary>
    [Serializable]
    [DataObject]
    [Description("糠醛车间检测数据")]
    [BindIndex("PRIMARY", true, "ID")]
    [BindTable("tb_kqtestdata", Description = "糠醛车间检测数据", ConnName = "YoungRunMIS", DbType = DatabaseType.MySql)]
    public partial class tb_kqtestdata : Itb_kqtestdata
    
    {
        #region 属性
        private String _ID;
        /// <summary>数据编号</summary>
        [DisplayName("数据编号")]
        [Description("数据编号")]
        [DataObjectField(true, false, false, 20)]
        [BindColumn(1, "ID", "数据编号", null, "varchar(20)", 0, 0, false)]
        public String ID
        {
            get { return _ID; }
            set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } }
        }

        private String _RawNameTP;
        /// <summary>原料名称</summary>
        [DisplayName("原料名称")]
        [Description("原料名称")]
        [DataObjectField(false, false, false, 20)]
        [BindColumn(2, "RawNameTP", "原料名称", null, "varchar(20)", 0, 0, false)]
        public String RawNameTP
        {
            get { return _RawNameTP; }
            set { if (OnPropertyChanging("RawNameTP", value)) { _RawNameTP = value; OnPropertyChanged("RawNameTP"); } }
        }

        private String _JQIsHaveKQTP;
        /// <summary>精油含醛</summary>
        [DisplayName("精油含醛")]
        [Description("精油含醛")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(3, "JQIsHaveKQTP", "精油含醛", "", "varchar(10)", 0, 0, false)]
        public String JQIsHaveKQTP
        {
            get { return _JQIsHaveKQTP; }
            set { if (OnPropertyChanging("JQIsHaveKQTP", value)) { _JQIsHaveKQTP = value; OnPropertyChanged("JQIsHaveKQTP"); } }
        }

        private Double _AV;
        /// <summary>酸值</summary>
        [DisplayName("酸值")]
        [Description("酸值")]
        [DataObjectField(false, false, true, 22)]
        [BindColumn(4, "AV", "酸值", "-1", "double", 22, 0, false)]
        public Double AV
        {
            get { return _AV; }
            set { if (OnPropertyChanging("AV", value)) { _AV = value; OnPropertyChanged("AV"); } }
        }

        private String _CYIsHaveKQTP;
        /// <summary>抽油含醛</summary>
        [DisplayName("抽油含醛")]
        [Description("抽油含醛")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(5, "CYIsHaveKQTP", "抽油含醛", "", "varchar(10)", 0, 0, false)]
        public String CYIsHaveKQTP
        {
            get { return _CYIsHaveKQTP; }
            set { if (OnPropertyChanging("CYIsHaveKQTP", value)) { _CYIsHaveKQTP = value; OnPropertyChanged("CYIsHaveKQTP"); } }
        }

        private String _T8WIsHaveKQTP;
        /// <summary>塔8水含醛</summary>
        [DisplayName("塔8水含醛")]
        [Description("塔8水含醛")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(6, "T8WIsHaveKQTP", "塔8水含醛", "", "varchar(10)", 0, 0, false)]
        public String T8WIsHaveKQTP
        {
            get { return _T8WIsHaveKQTP; }
            set { if (OnPropertyChanging("T8WIsHaveKQTP", value)) { _T8WIsHaveKQTP = value; OnPropertyChanged("T8WIsHaveKQTP"); } }
        }

        private String _ASTM;
        /// <summary>色度</summary>
        [DisplayName("色度")]
        [Description("色度")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(7, "ASTM", "色度", "-1", "varchar(10)", 0, 0, false)]
        public String ASTM
        {
            get { return _ASTM; }
            set { if (OnPropertyChanging("ASTM", value)) { _ASTM = value; OnPropertyChanged("ASTM"); } }
        }

        private DateTime _GetSampleTime;
        /// <summary>采样时间</summary>
        [DisplayName("采样时间")]
        [Description("采样时间")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn(8, "GetSampleTime", "采样时间", null, "datetime", 0, 0, false)]
        public DateTime GetSampleTime
        {
            get { return _GetSampleTime; }
            set { if (OnPropertyChanging("GetSampleTime", value)) { _GetSampleTime = value; OnPropertyChanged("GetSampleTime"); } }
        }

        private String _GetSampPersonTP;
        /// <summary>采样人</summary>
        [DisplayName("采样人")]
        [Description("采样人")]
        [DataObjectField(false, false, false, 20)]
        [BindColumn(9, "GetSampPersonTP", "采样人", null, "varchar(20)", 0, 0, false)]
        public String GetSampPersonTP
        {
            get { return _GetSampPersonTP; }
            set { if (OnPropertyChanging("GetSampPersonTP", value)) { _GetSampPersonTP = value; OnPropertyChanged("GetSampPersonTP"); } }
        }

        private String _TestPersonTP;
        /// <summary>检测人</summary>
        [DisplayName("检测人")]
        [Description("检测人")]
        [DataObjectField(false, false, false, 20)]
        [BindColumn(10, "TestPersonTP", "检测人", null, "varchar(20)", 0, 0, false)]
        public String TestPersonTP
        {
            get { return _TestPersonTP; }
            set { if (OnPropertyChanging("TestPersonTP", value)) { _TestPersonTP = value; OnPropertyChanged("TestPersonTP"); } }
        }

        private String _GetSampLocationTP;
        /// <summary>采样地点</summary>
        [DisplayName("采样地点")]
        [Description("采样地点")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(11, "GetSampLocationTP", "采样地点", null, "varchar(10)", 0, 0, false)]
        public String GetSampLocationTP
        {
            get { return _GetSampLocationTP; }
            set { if (OnPropertyChanging("GetSampLocationTP", value)) { _GetSampLocationTP = value; OnPropertyChanged("GetSampLocationTP"); } }
        }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn(12, "UpdateTime", "更新时间", null, "datetime", 0, 0, false)]
        public DateTime UpdateTime
        {
            get { return _UpdateTime; }
            set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(13, "Remark", "备注", null, "varchar(100)", 0, 0, false)]
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
                    case "RawNameTP" : return _RawNameTP;
                    case "JQIsHaveKQTP" : return _JQIsHaveKQTP;
                    case "AV" : return _AV;
                    case "CYIsHaveKQTP" : return _CYIsHaveKQTP;
                    case "T8WIsHaveKQTP" : return _T8WIsHaveKQTP;
                    case "ASTM" : return _ASTM;
                    case "GetSampleTime" : return _GetSampleTime;
                    case "GetSampPersonTP" : return _GetSampPersonTP;
                    case "TestPersonTP" : return _TestPersonTP;
                    case "GetSampLocationTP" : return _GetSampLocationTP;
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
                    case "RawNameTP" : _RawNameTP = Convert.ToString(value); break;
                    case "JQIsHaveKQTP" : _JQIsHaveKQTP = Convert.ToString(value); break;
                    case "AV" : _AV = Convert.ToDouble(value); break;
                    case "CYIsHaveKQTP" : _CYIsHaveKQTP = Convert.ToString(value); break;
                    case "T8WIsHaveKQTP" : _T8WIsHaveKQTP = Convert.ToString(value); break;
                    case "ASTM" : _ASTM = Convert.ToString(value); break;
                    case "GetSampleTime" : _GetSampleTime = Convert.ToDateTime(value); break;
                    case "GetSampPersonTP" : _GetSampPersonTP = Convert.ToString(value); break;
                    case "TestPersonTP" : _TestPersonTP = Convert.ToString(value); break;
                    case "GetSampLocationTP" : _GetSampLocationTP = Convert.ToString(value); break;
                    case "UpdateTime" : _UpdateTime = Convert.ToDateTime(value); break;
                    case "Remark" : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得糠醛车间检测数据字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>数据编号</summary>
            public static readonly FieldItem ID = Meta.Table.FindByName("ID");

            ///<summary>原料名称</summary>
            public static readonly FieldItem RawNameTP = Meta.Table.FindByName("RawNameTP");

            ///<summary>精油含醛</summary>
            public static readonly FieldItem JQIsHaveKQTP = Meta.Table.FindByName("JQIsHaveKQTP");

            ///<summary>酸值</summary>
            public static readonly FieldItem AV = Meta.Table.FindByName("AV");

            ///<summary>抽油含醛</summary>
            public static readonly FieldItem CYIsHaveKQTP = Meta.Table.FindByName("CYIsHaveKQTP");

            ///<summary>塔8水含醛</summary>
            public static readonly FieldItem T8WIsHaveKQTP = Meta.Table.FindByName("T8WIsHaveKQTP");

            ///<summary>色度</summary>
            public static readonly FieldItem ASTM = Meta.Table.FindByName("ASTM");

            ///<summary>采样时间</summary>
            public static readonly FieldItem GetSampleTime = Meta.Table.FindByName("GetSampleTime");

            ///<summary>采样人</summary>
            public static readonly FieldItem GetSampPersonTP = Meta.Table.FindByName("GetSampPersonTP");

            ///<summary>检测人</summary>
            public static readonly FieldItem TestPersonTP = Meta.Table.FindByName("TestPersonTP");

            ///<summary>采样地点</summary>
            public static readonly FieldItem GetSampLocationTP = Meta.Table.FindByName("GetSampLocationTP");

            ///<summary>更新时间</summary>
            public static readonly FieldItem UpdateTime = Meta.Table.FindByName("UpdateTime");

            ///<summary>备注</summary>
            public static readonly FieldItem Remark = Meta.Table.FindByName("Remark");
        }
        #endregion
    }

    /// <summary>糠醛车间检测数据接口</summary>
    public partial interface Itb_kqtestdata
    {
        #region 属性
        /// <summary>数据编号</summary>
        String ID { get; set; }

        /// <summary>原料名称</summary>
        String RawNameTP { get; set; }

        /// <summary>精油含醛</summary>
        String JQIsHaveKQTP { get; set; }

        /// <summary>酸值</summary>
        Double AV { get; set; }

        /// <summary>抽油含醛</summary>
        String CYIsHaveKQTP { get; set; }

        /// <summary>塔8水含醛</summary>
        String T8WIsHaveKQTP { get; set; }

        /// <summary>色度</summary>
        String ASTM { get; set; }

        /// <summary>采样时间</summary>
        DateTime GetSampleTime { get; set; }

        /// <summary>采样人</summary>
        String GetSampPersonTP { get; set; }

        /// <summary>检测人</summary>
        String TestPersonTP { get; set; }

        /// <summary>采样地点</summary>
        String GetSampLocationTP { get; set; }

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