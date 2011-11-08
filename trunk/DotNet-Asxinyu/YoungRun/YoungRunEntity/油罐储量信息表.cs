using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace YoungRunEntity
{
    /// <summary>油罐储量信息表</summary>
    [Serializable]
    [DataObject]
    [Description("油罐储量信息表")]
    [BindIndex("PRIMARY", true, "ID")]
    [BindTable("tb_OilTankST", Description = "油罐储量信息表", ConnName = "YoungRunST", DbType = DatabaseType.MySql)]
    public partial class tb_OilTankST : Itb_OilTankST
    
    {
        #region 属性
        private UInt32 _ID;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "ID", "编号", null, "int(10) unsigned", 10, 0, false)]
        public UInt32 ID
        {
            get { return _ID; }
            set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } }
        }

        private String _TankIdTP;
        /// <summary>罐号</summary>
        [DisplayName("罐号")]
        [Description("罐号")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(2, "TankIdTP", "罐号", null, "varchar(10)", 0, 0, false)]
        public String TankIdTP
        {
            get { return _TankIdTP; }
            set { if (OnPropertyChanging("TankIdTP", value)) { _TankIdTP = value; OnPropertyChanged("TankIdTP"); } }
        }

        private String _ProductNameTP;
        /// <summary>油品名称</summary>
        [DisplayName("油品名称")]
        [Description("油品名称")]
        [DataObjectField(false, false, false, 20)]
        [BindColumn(3, "ProductNameTP", "油品名称", null, "varchar(20)", 0, 0, false)]
        public String ProductNameTP
        {
            get { return _ProductNameTP; }
            set { if (OnPropertyChanging("ProductNameTP", value)) { _ProductNameTP = value; OnPropertyChanged("ProductNameTP"); } }
        }

        private Double _LiquidLevel;
        /// <summary>液位</summary>
        [DisplayName("液位")]
        [Description("液位")]
        [DataObjectField(false, false, false, 22)]
        [BindColumn(4, "LiquidLevel", "液位", null, "double", 22, 0, false)]
        public Double LiquidLevel
        {
            get { return _LiquidLevel; }
            set { if (OnPropertyChanging("LiquidLevel", value)) { _LiquidLevel = value; OnPropertyChanged("LiquidLevel"); } }
        }

        private Double _CurVolume;
        /// <summary>当前体积</summary>
        [DisplayName("当前体积")]
        [Description("当前体积")]
        [DataObjectField(false, false, false, 22)]
        [BindColumn(5, "CurVolume", "当前体积", null, "double", 22, 0, false)]
        public Double CurVolume
        {
            get { return _CurVolume; }
            set { if (OnPropertyChanging("CurVolume", value)) { _CurVolume = value; OnPropertyChanged("CurVolume"); } }
        }

        private Double _CurWeigth;
        /// <summary>存储重量</summary>
        [DisplayName("存储重量")]
        [Description("存储重量")]
        [DataObjectField(false, false, false, 22)]
        [BindColumn(6, "CurWeigth", "存储重量", null, "double", 22, 0, false)]
        public Double CurWeigth
        {
            get { return _CurWeigth; }
            set { if (OnPropertyChanging("CurWeigth", value)) { _CurWeigth = value; OnPropertyChanged("CurWeigth"); } }
        }

        private Double _D20;
        /// <summary>密度</summary>
        [DisplayName("密度")]
        [Description("密度")]
        [DataObjectField(false, false, false, 22)]
        [BindColumn(7, "D20", "密度", "0.91", "double", 22, 0, false)]
        public Double D20
        {
            get { return _D20; }
            set { if (OnPropertyChanging("D20", value)) { _D20 = value; OnPropertyChanged("D20"); } }
        }

        private Double _CurTemperature;
        /// <summary>温度</summary>
        [DisplayName("温度")]
        [Description("温度")]
        [DataObjectField(false, false, true, 22)]
        [BindColumn(8, "CurTemperature", "温度", "20", "double", 22, 0, false)]
        public Double CurTemperature
        {
            get { return _CurTemperature; }
            set { if (OnPropertyChanging("CurTemperature", value)) { _CurTemperature = value; OnPropertyChanged("CurTemperature"); } }
        }

        private DateTime _RecordTime;
        /// <summary>计量时间</summary>
        [DisplayName("计量时间")]
        [Description("计量时间")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn(9, "RecordTime", "计量时间", null, "datetime", 0, 0, false)]
        public DateTime RecordTime
        {
            get { return _RecordTime; }
            set { if (OnPropertyChanging("RecordTime", value)) { _RecordTime = value; OnPropertyChanged("RecordTime"); } }
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
        [DataObjectField(false, false, true, 30)]
        [BindColumn(11, "Remark", "备注", null, "varchar(30)", 0, 0, false)]
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
                    case "TankIdTP" : return _TankIdTP;
                    case "ProductNameTP" : return _ProductNameTP;
                    case "LiquidLevel" : return _LiquidLevel;
                    case "CurVolume" : return _CurVolume;
                    case "CurWeigth" : return _CurWeigth;
                    case "D20" : return _D20;
                    case "CurTemperature" : return _CurTemperature;
                    case "RecordTime" : return _RecordTime;
                    case "UpdateTime" : return _UpdateTime;
                    case "Remark" : return _Remark;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "ID" : _ID = Convert.ToUInt32(value); break;
                    case "TankIdTP" : _TankIdTP = Convert.ToString(value); break;
                    case "ProductNameTP" : _ProductNameTP = Convert.ToString(value); break;
                    case "LiquidLevel" : _LiquidLevel = Convert.ToDouble(value); break;
                    case "CurVolume" : _CurVolume = Convert.ToDouble(value); break;
                    case "CurWeigth" : _CurWeigth = Convert.ToDouble(value); break;
                    case "D20" : _D20 = Convert.ToDouble(value); break;
                    case "CurTemperature" : _CurTemperature = Convert.ToDouble(value); break;
                    case "RecordTime" : _RecordTime = Convert.ToDateTime(value); break;
                    case "UpdateTime" : _UpdateTime = Convert.ToDateTime(value); break;
                    case "Remark" : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得油罐储量信息表字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>编号</summary>
            public static readonly FieldItem ID = Meta.Table.FindByName("ID");

            ///<summary>罐号</summary>
            public static readonly FieldItem TankIdTP = Meta.Table.FindByName("TankIdTP");

            ///<summary>油品名称</summary>
            public static readonly FieldItem ProductNameTP = Meta.Table.FindByName("ProductNameTP");

            ///<summary>液位</summary>
            public static readonly FieldItem LiquidLevel = Meta.Table.FindByName("LiquidLevel");

            ///<summary>当前体积</summary>
            public static readonly FieldItem CurVolume = Meta.Table.FindByName("CurVolume");

            ///<summary>存储重量</summary>
            public static readonly FieldItem CurWeigth = Meta.Table.FindByName("CurWeigth");

            ///<summary>密度</summary>
            public static readonly FieldItem D20 = Meta.Table.FindByName("D20");

            ///<summary>温度</summary>
            public static readonly FieldItem CurTemperature = Meta.Table.FindByName("CurTemperature");

            ///<summary>计量时间</summary>
            public static readonly FieldItem RecordTime = Meta.Table.FindByName("RecordTime");

            ///<summary>更新时间</summary>
            public static readonly FieldItem UpdateTime = Meta.Table.FindByName("UpdateTime");

            ///<summary>备注</summary>
            public static readonly FieldItem Remark = Meta.Table.FindByName("Remark");
        }
        #endregion
    }

    /// <summary>油罐储量信息表接口</summary>
    public partial interface Itb_OilTankST
    {
        #region 属性
        /// <summary>编号</summary>
        UInt32 ID { get; set; }

        /// <summary>罐号</summary>
        String TankIdTP { get; set; }

        /// <summary>油品名称</summary>
        String ProductNameTP { get; set; }

        /// <summary>液位</summary>
        Double LiquidLevel { get; set; }

        /// <summary>当前体积</summary>
        Double CurVolume { get; set; }

        /// <summary>存储重量</summary>
        Double CurWeigth { get; set; }

        /// <summary>密度</summary>
        Double D20 { get; set; }

        /// <summary>温度</summary>
        Double CurTemperature { get; set; }

        /// <summary>计量时间</summary>
        DateTime RecordTime { get; set; }

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