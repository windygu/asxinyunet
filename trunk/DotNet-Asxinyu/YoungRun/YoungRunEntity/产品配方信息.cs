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
    /// <summary>产品配方信息</summary>
    [Serializable]
    [DataObject]
    [Description("产品配方信息")]
    [BindTable("tb_productformule", Description = "产品配方信息", ConnName = "YoungRunMIS", DbType = DatabaseType.MySql)]
    public partial class tb_productformule : Itb_productformule
    
    {
        #region 属性
        private String _ProductName;
        /// <summary>产品名称</summary>
        [DisplayName("产品名称")]
        [Description("产品名称")]
        [DataObjectField(true, false, false, 20)]
        [BindColumn(1, "ProductName", "产品名称", null, "varchar(20)", 0, 0, false)]
        public String ProductName
        {
            get { return _ProductName; }
            set { if (OnPropertyChanging("ProductName", value)) { _ProductName = value; OnPropertyChanged("ProductName"); } }
        }

        private Double _BtCount;
        /// <summary>白土用量</summary>
        [DisplayName("白土用量")]
        [Description("白土用量")]
        [DataObjectField(false, false, true, 22)]
        [BindColumn(2, "BtCount", "白土用量", "-1", "double", 22, 0, false)]
        public Double BtCount
        {
            get { return _BtCount; }
            set { if (OnPropertyChanging("BtCount", value)) { _BtCount = value; OnPropertyChanged("BtCount"); } }
        }

        private Double _T501Count;
        /// <summary>T501用量</summary>
        [DisplayName("T501用量")]
        [Description("T501用量")]
        [DataObjectField(false, false, true, 22)]
        [BindColumn(3, "T501Count", "T501用量", "-1", "double", 22, 0, false)]
        public Double T501Count
        {
            get { return _T501Count; }
            set { if (OnPropertyChanging("T501Count", value)) { _T501Count = value; OnPropertyChanged("T501Count"); } }
        }

        private Double _T602Count;
        /// <summary>T602用量</summary>
        [DisplayName("T602用量")]
        [Description("T602用量")]
        [DataObjectField(false, false, true, 22)]
        [BindColumn(4, "T602Count", "T602用量", "-1", "double", 22, 0, false)]
        public Double T602Count
        {
            get { return _T602Count; }
            set { if (OnPropertyChanging("T602Count", value)) { _T602Count = value; OnPropertyChanged("T602Count"); } }
        }

        private Double _YJCount;
        /// <summary>液碱用量</summary>
        [DisplayName("液碱用量")]
        [Description("液碱用量")]
        [DataObjectField(false, false, true, 22)]
        [BindColumn(5, "YJCount", "液碱用量", "-1", "double", 22, 0, false)]
        public Double YJCount
        {
            get { return _YJCount; }
            set { if (OnPropertyChanging("YJCount", value)) { _YJCount = value; OnPropertyChanged("YJCount"); } }
        }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn(6, "UpdateTime", "更新时间", null, "datetime", 0, 0, false)]
        public DateTime UpdateTime
        {
            get { return _UpdateTime; }
            set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(7, "Remark", "备注", null, "varchar(50)", 0, 0, false)]
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
                    case "ProductName" : return _ProductName;
                    case "BtCount" : return _BtCount;
                    case "T501Count" : return _T501Count;
                    case "T602Count" : return _T602Count;
                    case "YJCount" : return _YJCount;
                    case "UpdateTime" : return _UpdateTime;
                    case "Remark" : return _Remark;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "ProductName" : _ProductName = Convert.ToString(value); break;
                    case "BtCount" : _BtCount = Convert.ToDouble(value); break;
                    case "T501Count" : _T501Count = Convert.ToDouble(value); break;
                    case "T602Count" : _T602Count = Convert.ToDouble(value); break;
                    case "YJCount" : _YJCount = Convert.ToDouble(value); break;
                    case "UpdateTime" : _UpdateTime = Convert.ToDateTime(value); break;
                    case "Remark" : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得产品配方信息字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>产品名称</summary>
            public static readonly FieldItem ProductName = Meta.Table.FindByName("ProductName");

            ///<summary>白土用量</summary>
            public static readonly FieldItem BtCount = Meta.Table.FindByName("BtCount");

            ///<summary>T501用量</summary>
            public static readonly FieldItem T501Count = Meta.Table.FindByName("T501Count");

            ///<summary>T602用量</summary>
            public static readonly FieldItem T602Count = Meta.Table.FindByName("T602Count");

            ///<summary>液碱用量</summary>
            public static readonly FieldItem YJCount = Meta.Table.FindByName("YJCount");

            ///<summary>更新时间</summary>
            public static readonly FieldItem UpdateTime = Meta.Table.FindByName("UpdateTime");

            ///<summary>备注</summary>
            public static readonly FieldItem Remark = Meta.Table.FindByName("Remark");
        }
        #endregion
    }

    /// <summary>产品配方信息接口</summary>
    public partial interface Itb_productformule
    {
        #region 属性
        /// <summary>产品名称</summary>
        String ProductName { get; set; }

        /// <summary>白土用量</summary>
        Double BtCount { get; set; }

        /// <summary>T501用量</summary>
        Double T501Count { get; set; }

        /// <summary>T602用量</summary>
        Double T602Count { get; set; }

        /// <summary>液碱用量</summary>
        Double YJCount { get; set; }

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