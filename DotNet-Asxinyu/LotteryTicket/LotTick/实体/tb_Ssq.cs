﻿using System;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

#pragma warning disable 3021
#pragma warning disable 3008
namespace LotTick
{
    /// <summary></summary>
    [Serializable]
    [DataObject]
    [Description("")]
    [BindIndex("PrimaryKey", true, "期号")]
    [BindTable("tb_Ssq", Description = "", ConnName = "LotTick", DbType = DatabaseType.Access)]
    public partial class tb_Ssq : Itb_Ssq
    
    {
        #region 属性
        private Int32 _期号;
        /// <summary>期号</summary>
        [DisplayName("期号")]
        [Description("期号")]
        [DataObjectField(true, false, true, 10)]
        [BindColumn(1, "期号", "期号", "0", "Long", 10, 0, false)]
        public virtual Int32 期号
        {
            get { return _期号; }
            set { if (OnPropertyChanging("期号", value)) { _期号 = value; OnPropertyChanged("期号"); } }
        }

        private DateTime _开奖日期;
        /// <summary>开奖日期</summary>
        [DisplayName("开奖日期")]
        [Description("开奖日期")]
        [DataObjectField(false, false, true, 8)]
        [BindColumn(2, "开奖日期", "开奖日期", null, "DateTime", 0, 0, false)]
        public virtual DateTime 开奖日期
        {
            get { return _开奖日期; }
            set { if (OnPropertyChanging("开奖日期", value)) { _开奖日期 = value; OnPropertyChanged("开奖日期"); } }
        }

        private Int32 _号码1;
        /// <summary>号码1</summary>
        [DisplayName("号码1")]
        [Description("号码1")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(3, "号码1", "号码1", "0", "Long", 10, 0, false)]
        public virtual Int32 号码1
        {
            get { return _号码1; }
            set { if (OnPropertyChanging("号码1", value)) { _号码1 = value; OnPropertyChanged("号码1"); } }
        }

        private Int32 _号码2;
        /// <summary>号码2</summary>
        [DisplayName("号码2")]
        [Description("号码2")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(4, "号码2", "号码2", "0", "Long", 10, 0, false)]
        public virtual Int32 号码2
        {
            get { return _号码2; }
            set { if (OnPropertyChanging("号码2", value)) { _号码2 = value; OnPropertyChanged("号码2"); } }
        }

        private Int32 _号码3;
        /// <summary>号码3</summary>
        [DisplayName("号码3")]
        [Description("号码3")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(5, "号码3", "号码3", "0", "Long", 10, 0, false)]
        public virtual Int32 号码3
        {
            get { return _号码3; }
            set { if (OnPropertyChanging("号码3", value)) { _号码3 = value; OnPropertyChanged("号码3"); } }
        }

        private Int32 _号码4;
        /// <summary>号码4</summary>
        [DisplayName("号码4")]
        [Description("号码4")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(6, "号码4", "号码4", "0", "Long", 10, 0, false)]
        public virtual Int32 号码4
        {
            get { return _号码4; }
            set { if (OnPropertyChanging("号码4", value)) { _号码4 = value; OnPropertyChanged("号码4"); } }
        }

        private Int32 _号码5;
        /// <summary>号码5</summary>
        [DisplayName("号码5")]
        [Description("号码5")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(7, "号码5", "号码5", "0", "Long", 10, 0, false)]
        public virtual Int32 号码5
        {
            get { return _号码5; }
            set { if (OnPropertyChanging("号码5", value)) { _号码5 = value; OnPropertyChanged("号码5"); } }
        }

        private Int32 _号码6;
        /// <summary>号码6</summary>
        [DisplayName("号码6")]
        [Description("号码6")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(8, "号码6", "号码6", "0", "Long", 10, 0, false)]
        public virtual Int32 号码6
        {
            get { return _号码6; }
            set { if (OnPropertyChanging("号码6", value)) { _号码6 = value; OnPropertyChanged("号码6"); } }
        }

        private Int32 _蓝球;
        /// <summary>蓝球</summary>
        [DisplayName("蓝球")]
        [Description("蓝球")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(9, "蓝球", "蓝球", "0", "Long", 10, 0, false)]
        public virtual Int32 蓝球
        {
            get { return _蓝球; }
            set { if (OnPropertyChanging("蓝球", value)) { _蓝球 = value; OnPropertyChanged("蓝球"); } }
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
                    case "期号" : return _期号;
                    case "开奖日期" : return _开奖日期;
                    case "号码1" : return _号码1;
                    case "号码2" : return _号码2;
                    case "号码3" : return _号码3;
                    case "号码4" : return _号码4;
                    case "号码5" : return _号码5;
                    case "号码6" : return _号码6;
                    case "蓝球" : return _蓝球;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "期号" : _期号 = Convert.ToInt32(value); break;
                    case "开奖日期" : _开奖日期 = Convert.ToDateTime(value); break;
                    case "号码1" : _号码1 = Convert.ToInt32(value); break;
                    case "号码2" : _号码2 = Convert.ToInt32(value); break;
                    case "号码3" : _号码3 = Convert.ToInt32(value); break;
                    case "号码4" : _号码4 = Convert.ToInt32(value); break;
                    case "号码5" : _号码5 = Convert.ToInt32(value); break;
                    case "号码6" : _号码6 = Convert.ToInt32(value); break;
                    case "蓝球" : _蓝球 = Convert.ToInt32(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>期号</summary>
            public static readonly FieldItem 期号 = Meta.Table.FindByName("期号");

            ///<summary>开奖日期</summary>
            public static readonly FieldItem 开奖日期 = Meta.Table.FindByName("开奖日期");

            ///<summary>号码1</summary>
            public static readonly FieldItem 号码1 = Meta.Table.FindByName("号码1");

            ///<summary>号码2</summary>
            public static readonly FieldItem 号码2 = Meta.Table.FindByName("号码2");

            ///<summary>号码3</summary>
            public static readonly FieldItem 号码3 = Meta.Table.FindByName("号码3");

            ///<summary>号码4</summary>
            public static readonly FieldItem 号码4 = Meta.Table.FindByName("号码4");

            ///<summary>号码5</summary>
            public static readonly FieldItem 号码5 = Meta.Table.FindByName("号码5");

            ///<summary>号码6</summary>
            public static readonly FieldItem 号码6 = Meta.Table.FindByName("号码6");

            ///<summary>蓝球</summary>
            public static readonly FieldItem 蓝球 = Meta.Table.FindByName("蓝球");
        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface Itb_Ssq
    {
        #region 属性
        /// <summary>期号</summary>
        Int32 期号 { get; set; }

        /// <summary>开奖日期</summary>
        DateTime 开奖日期 { get; set; }

        /// <summary>号码1</summary>
        Int32 号码1 { get; set; }

        /// <summary>号码2</summary>
        Int32 号码2 { get; set; }

        /// <summary>号码3</summary>
        Int32 号码3 { get; set; }

        /// <summary>号码4</summary>
        Int32 号码4 { get; set; }

        /// <summary>号码5</summary>
        Int32 号码5 { get; set; }

        /// <summary>号码6</summary>
        Int32 号码6 { get; set; }

        /// <summary>蓝球</summary>
        Int32 蓝球 { get; set; }
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