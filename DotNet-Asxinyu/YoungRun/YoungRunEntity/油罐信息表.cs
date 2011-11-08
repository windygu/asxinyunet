using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace YoungRunEntity
{
    /// <summary>油罐信息表</summary>
    [Serializable]
    [DataObject]
    [Description("油罐信息表")]
    [BindIndex("PRIMARY", true, "TankId")]
    [BindTable("tb_OilTankInfo", Description = "油罐信息表", ConnName = "YoungRunST", DbType = DatabaseType.MySql)]
    public partial class tb_OilTankInfo : Itb_OilTankInfo
    
    {
        #region 属性
        private String _TankId;
        /// <summary>罐号</summary>
        [DisplayName("罐号")]
        [Description("罐号")]
        [DataObjectField(true, false, false, 10)]
        [BindColumn(1, "TankId", "罐号", null, "varchar(10)", 0, 0, false)]
        public String TankId
        {
            get { return _TankId; }
            set { if (OnPropertyChanging("TankId", value)) { _TankId = value; OnPropertyChanged("TankId"); } }
        }

        private Double _Height;
        /// <summary>总高度</summary>
        [DisplayName("总高度")]
        [Description("总高度")]
        [DataObjectField(false, false, false, 22)]
        [BindColumn(2, "Height", "总高度", null, "double", 22, 0, false)]
        public Double Height
        {
            get { return _Height; }
            set { if (OnPropertyChanging("Height", value)) { _Height = value; OnPropertyChanged("Height"); } }
        }

        private Double _Volume;
        /// <summary>体积</summary>
        [DisplayName("体积")]
        [Description("体积")]
        [DataObjectField(false, false, false, 22)]
        [BindColumn(3, "Volume", "体积", null, "double", 22, 0, false)]
        public Double Volume
        {
            get { return _Volume; }
            set { if (OnPropertyChanging("Volume", value)) { _Volume = value; OnPropertyChanged("Volume"); } }
        }

        private Double _PerCmVolume;
        /// <summary>每1cm容量</summary>
        [DisplayName("每1cm容量")]
        [Description("每1cm容量")]
        [DataObjectField(false, false, false, 22)]
        [BindColumn(4, "PerCmVolume", "每1cm容量", null, "double", 22, 0, false)]
        public Double PerCmVolume
        {
            get { return _PerCmVolume; }
            set { if (OnPropertyChanging("PerCmVolume", value)) { _PerCmVolume = value; OnPropertyChanged("PerCmVolume"); } }
        }

        private String _ProductNameTP;
        /// <summary>油品名称</summary>
        [DisplayName("油品名称")]
        [Description("油品名称")]
        [DataObjectField(false, false, false, 20)]
        [BindColumn(5, "ProductNameTP", "油品名称", null, "varchar(20)", 0, 0, false)]
        public String ProductNameTP
        {
            get { return _ProductNameTP; }
            set { if (OnPropertyChanging("ProductNameTP", value)) { _ProductNameTP = value; OnPropertyChanged("ProductNameTP"); } }
        }

        private String _StrogeType;
        /// <summary>存储类型</summary>
        [DisplayName("存储类型")]
        [Description("存储类型")]
        [DataObjectField(false, false, false, 20)]
        [BindColumn(6, "StrogeType", "存储类型", null, "varchar(20)", 0, 0, false)]
        public String StrogeType
        {
            get { return _StrogeType; }
            set { if (OnPropertyChanging("StrogeType", value)) { _StrogeType = value; OnPropertyChanged("StrogeType"); } }
        }

        private String _Purpose;
        /// <summary>用途</summary>
        [DisplayName("用途")]
        [Description("用途")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn(7, "Purpose", "用途", "", "varchar(30)", 0, 0, false)]
        public String Purpose
        {
            get { return _Purpose; }
            set { if (OnPropertyChanging("Purpose", value)) { _Purpose = value; OnPropertyChanged("Purpose"); } }
        }

        private Double _AlarmHeight;
        /// <summary>警戒高度</summary>
        [DisplayName("警戒高度")]
        [Description("警戒高度")]
        [DataObjectField(false, false, false, 22)]
        [BindColumn(8, "AlarmHeight", "警戒高度", "0.8", "double", 22, 0, false)]
        public Double AlarmHeight
        {
            get { return _AlarmHeight; }
            set { if (OnPropertyChanging("AlarmHeight", value)) { _AlarmHeight = value; OnPropertyChanged("AlarmHeight"); } }
        }

        private Double _D20;
        /// <summary>密度</summary>
        [DisplayName("密度")]
        [Description("密度")]
        [DataObjectField(false, false, false, 22)]
        [BindColumn(9, "D20", "密度", "0.91", "double", 22, 0, false)]
        public Double D20
        {
            get { return _D20; }
            set { if (OnPropertyChanging("D20", value)) { _D20 = value; OnPropertyChanged("D20"); } }
        }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn(10, "UpdateTime", "更新时间", null, "datetime", 0, 0, false)]
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
        [BindColumn(11, "Remark", "备注", null, "varchar(50)", 0, 0, false)]
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
                    case "TankId" : return _TankId;
                    case "Height" : return _Height;
                    case "Volume" : return _Volume;
                    case "PerCmVolume" : return _PerCmVolume;
                    case "ProductNameTP" : return _ProductNameTP;
                    case "StrogeType" : return _StrogeType;
                    case "Purpose" : return _Purpose;
                    case "AlarmHeight" : return _AlarmHeight;
                    case "D20" : return _D20;
                    case "UpdateTime" : return _UpdateTime;
                    case "Remark" : return _Remark;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "TankId" : _TankId = Convert.ToString(value); break;
                    case "Height" : _Height = Convert.ToDouble(value); break;
                    case "Volume" : _Volume = Convert.ToDouble(value); break;
                    case "PerCmVolume" : _PerCmVolume = Convert.ToDouble(value); break;
                    case "ProductNameTP" : _ProductNameTP = Convert.ToString(value); break;
                    case "StrogeType" : _StrogeType = Convert.ToString(value); break;
                    case "Purpose" : _Purpose = Convert.ToString(value); break;
                    case "AlarmHeight" : _AlarmHeight = Convert.ToDouble(value); break;
                    case "D20" : _D20 = Convert.ToDouble(value); break;
                    case "UpdateTime" : _UpdateTime = Convert.ToDateTime(value); break;
                    case "Remark" : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得油罐信息表字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>罐号</summary>
            public static readonly FieldItem TankId = Meta.Table.FindByName("TankId");

            ///<summary>总高度</summary>
            public static readonly FieldItem Height = Meta.Table.FindByName("Height");

            ///<summary>体积</summary>
            public static readonly FieldItem Volume = Meta.Table.FindByName("Volume");

            ///<summary>每1cm容量</summary>
            public static readonly FieldItem PerCmVolume = Meta.Table.FindByName("PerCmVolume");

            ///<summary>油品名称</summary>
            public static readonly FieldItem ProductNameTP = Meta.Table.FindByName("ProductNameTP");

            ///<summary>存储类型</summary>
            public static readonly FieldItem StrogeType = Meta.Table.FindByName("StrogeType");

            ///<summary>用途</summary>
            public static readonly FieldItem Purpose = Meta.Table.FindByName("Purpose");

            ///<summary>警戒高度</summary>
            public static readonly FieldItem AlarmHeight = Meta.Table.FindByName("AlarmHeight");

            ///<summary>密度</summary>
            public static readonly FieldItem D20 = Meta.Table.FindByName("D20");

            ///<summary>更新时间</summary>
            public static readonly FieldItem UpdateTime = Meta.Table.FindByName("UpdateTime");

            ///<summary>备注</summary>
            public static readonly FieldItem Remark = Meta.Table.FindByName("Remark");
        }
        #endregion
    }

    /// <summary>油罐信息表接口</summary>
    public partial interface Itb_OilTankInfo
    {
        #region 属性
        /// <summary>罐号</summary>
        String TankId { get; set; }

        /// <summary>总高度</summary>
        Double Height { get; set; }

        /// <summary>体积</summary>
        Double Volume { get; set; }

        /// <summary>每1cm容量</summary>
        Double PerCmVolume { get; set; }

        /// <summary>油品名称</summary>
        String ProductNameTP { get; set; }

        /// <summary>存储类型</summary>
        String StrogeType { get; set; }

        /// <summary>用途</summary>
        String Purpose { get; set; }

        /// <summary>警戒高度</summary>
        Double AlarmHeight { get; set; }

        /// <summary>密度</summary>
        Double D20 { get; set; }

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