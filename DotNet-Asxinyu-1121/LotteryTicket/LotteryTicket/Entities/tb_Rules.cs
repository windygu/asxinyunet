﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using System.Xml.Serialization;
using XCode.Configuration;
using XCode.DataAccessLayer;

#pragma warning disable 3021
#pragma warning disable 3008
namespace LotteryTicket
{
    /// <summary></summary>
    [Serializable]
    [DataObject]
    [Description("")]
    [BindIndex("PrimaryKey", true, "Id")]
    [BindIndex("Id", false, "Id")]
    [BindTable("tb_Rules", Description = "", ConnName = "LotTick", DbType = DatabaseType.Access)]
    public partial class tb_Rules : Itb_Rules
    
    {
        #region 属性
        private Int32 _Id;
        /// <summary>序号</summary>
        [DisplayName("序号")]
        [Description("序号")]
        [DataObjectField(true, true , false, 10)]
        [BindColumn(1, "Id", "序号", null, "Long", 10, 0, false)]
        public virtual Int32 Id
        {
            get { return _Id; }
            set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } }
        }

        private String _IndexSelectorNameTP;
        /// <summary>指标函数</summary>
        [DisplayName("指标函数")]
        [Description("指标函数")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(2, "IndexSelectorNameTP", "指标函数", null, "VarChar", 0, 0, false)]
        public virtual String IndexSelectorNameTP
        {
            get { return _IndexSelectorNameTP; }
            set { if (OnPropertyChanging("IndexSelectorNameTP", value)) { _IndexSelectorNameTP = value; OnPropertyChanged("IndexSelectorNameTP"); } }
        }

        private String _CompareRuleNameTP;
        /// <summary>对比类型</summary>
        [DisplayName("对比类型")]
        [Description("对比类型")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "CompareRuleNameTP", "对比类型", null, "VarChar", 0, 0, false)]
        public virtual String CompareRuleNameTP
        {
            get { return _CompareRuleNameTP; }
            set { if (OnPropertyChanging("CompareRuleNameTP", value)) { _CompareRuleNameTP = value; OnPropertyChanged("CompareRuleNameTP"); } }
        }

        private Int16 _FloorLimit;
        /// <summary>下限</summary>
        [DisplayName("下限")]
        [Description("下限")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(4, "FloorLimit", "下限", "0", "Short", 5, 0, false)]
        public virtual Int16 FloorLimit
        {
            get { return _FloorLimit; }
            set { if (OnPropertyChanging("FloorLimit", value)) { _FloorLimit = value; OnPropertyChanged("FloorLimit"); } }
        }

        private Int16 _CeilLimit;
        /// <summary>上限</summary>
        [DisplayName("上限")]
        [Description("上限")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(5, "CeilLimit", "上限", "0", "Short", 5, 0, false)]
        public virtual Int16 CeilLimit
        {
            get { return _CeilLimit; }
            set { if (OnPropertyChanging("CeilLimit", value)) { _CeilLimit = value; OnPropertyChanged("CeilLimit"); } }
        }

        private String _CompListStr;
        /// <summary>对比序列</summary>
        [DisplayName("对比序列")]
        [Description("对比序列")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(6, "CompListStr", "对比序列", null, "VarChar", 0, 0, false)]
        public virtual String CompListStr
        {
            get { return _CompListStr; }
            set { if (OnPropertyChanging("CompListStr", value)) { _CompListStr = value; OnPropertyChanged("CompListStr"); } }
        }

        private Int16 _DataRows;
        /// <summary>验证行数</summary>
        [DisplayName("验证行数")]
        [Description("验证行数")]
        [DataObjectField(false, false, false, 5)]
        [BindColumn(7, "DataRows", "验证行数", "0", "Short", 5, 0, false)]
        public virtual Int16 DataRows
        {
            get { return _DataRows; }
            set { if (OnPropertyChanging("DataRows", value)) { _DataRows = value; OnPropertyChanged("DataRows"); } }
        }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, false, 8)]
        [BindColumn(8, "UpdateTime", "更新时间", null, "DateTime", 0, 0, false)]
        public virtual DateTime UpdateTime
        {
            get { return _UpdateTime; }
            set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 80)]
        [BindColumn(9, "Remark", "备注", null, "VarChar", 0, 0, false)]
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
                    case "Id" : return _Id;
                    case "IndexSelectorNameTP" : return _IndexSelectorNameTP;
                    case "CompareRuleNameTP" : return _CompareRuleNameTP;
                    case "FloorLimit" : return _FloorLimit;
                    case "CeilLimit" : return _CeilLimit;
                    case "CompListStr" : return _CompListStr;
                    case "DataRows" : return _DataRows;
                    case "UpdateTime" : return _UpdateTime;
                    case "Remark" : return _Remark;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id" : _Id = Convert.ToInt32(value); break;
                    case "IndexSelectorNameTP" : _IndexSelectorNameTP = Convert.ToString(value); break;
                    case "CompareRuleNameTP" : _CompareRuleNameTP = Convert.ToString(value); break;
                    case "FloorLimit" : _FloorLimit = Convert.ToInt16(value); break;
                    case "CeilLimit" : _CeilLimit = Convert.ToInt16(value); break;
                    case "CompListStr" : _CompListStr = Convert.ToString(value); break;
                    case "DataRows" : _DataRows = Convert.ToInt16(value); break;
                    case "UpdateTime" : _UpdateTime = Convert.ToDateTime(value); break;
                    case "Remark" : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>序号</summary>
            public static readonly FieldItem Id = Meta.Table.FindByName("Id");

            ///<summary>指标函数</summary>
            public static readonly FieldItem IndexSelectorNameTP = Meta.Table.FindByName("IndexSelectorNameTP");

            ///<summary>对比类型</summary>
            public static readonly FieldItem CompareRuleNameTP = Meta.Table.FindByName("CompareRuleNameTP");

            ///<summary>下限</summary>
            public static readonly FieldItem FloorLimit = Meta.Table.FindByName("FloorLimit");

            ///<summary>上限</summary>
            public static readonly FieldItem CeilLimit = Meta.Table.FindByName("CeilLimit");

            ///<summary>对比序列</summary>
            public static readonly FieldItem CompListStr = Meta.Table.FindByName("CompListStr");

            ///<summary>验证行数</summary>
            public static readonly FieldItem DataRows = Meta.Table.FindByName("DataRows");

            ///<summary>更新时间</summary>
            public static readonly FieldItem UpdateTime = Meta.Table.FindByName("UpdateTime");

            ///<summary>备注</summary>
            public static readonly FieldItem Remark = Meta.Table.FindByName("Remark");
        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface Itb_Rules
    {
        #region 属性
        /// <summary>序号</summary>
        Int32 Id { get; set; }

        /// <summary>指标函数</summary>
        String IndexSelectorNameTP { get; set; }

        /// <summary>对比类型</summary>
        String CompareRuleNameTP { get; set; }

        /// <summary>下限</summary>
        Int16 FloorLimit { get; set; }

        /// <summary>上限</summary>
        Int16 CeilLimit { get; set; }

        /// <summary>对比序列</summary>
        String CompListStr { get; set; }

        /// <summary>验证行数</summary>
        Int16 DataRows { get; set; }

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