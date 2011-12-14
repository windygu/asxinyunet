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
    [BindIndex("PrimaryKey", true, "Id")]
    [BindIndex("Id", false, "Id")]
    [BindIndex("SchemeId", false, "SchemeId")]
    [BindTable("tb_Rules", Description = "", ConnName = "LotTick", DbType = DatabaseType.Access)]
    public partial class tb_Rules : Itb_Rules
    
    {
        #region 属性
        private Int32 _Id;
        /// <summary>序号</summary>
        [DisplayName("序号")]
        [Description("序号")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "Id", "序号", null, "Long", 10, 0, false)]
        public virtual Int32 Id
        {
            get { return _Id; }
            set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } }
        }

        private String _SchemeId;
        /// <summary>方案编号</summary>
        [DisplayName("方案编号")]
        [Description("方案编号")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(2, "SchemeId", "方案编号", "Scheme-01", "VarChar", 0, 0, false)]
        public virtual String SchemeId
        {
            get { return _SchemeId; }
            set { if (OnPropertyChanging("SchemeId", value)) { _SchemeId = value; OnPropertyChanged("SchemeId"); } }
        }

        private String _IndexSelectorNameTP;
        /// <summary>指标函数</summary>
        [DisplayName("指标函数")]
        [Description("指标函数")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(3, "IndexSelectorNameTP", "指标函数", null, "VarChar", 0, 0, false)]
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
        [BindColumn(4, "CompareRuleNameTP", "对比类型", null, "VarChar", 0, 0, false)]
        public virtual String CompareRuleNameTP
        {
            get { return _CompareRuleNameTP; }
            set { if (OnPropertyChanging("CompareRuleNameTP", value)) { _CompareRuleNameTP = value; OnPropertyChanged("CompareRuleNameTP"); } }
        }

        private String _RuleCompareParams;
        /// <summary>比较参数</summary>
        [DisplayName("比较参数")]
        [Description("比较参数")]
        [DataObjectField(false, false, true, 250)]
        [BindColumn(5, "RuleCompareParams", "比较参数", null, "VarChar", 0, 0, false)]
        public virtual String RuleCompareParams
        {
            get { return _RuleCompareParams; }
            set { if (OnPropertyChanging("RuleCompareParams", value)) { _RuleCompareParams = value; OnPropertyChanged("RuleCompareParams"); } }
        }

        private Int32 _NeedRows;
        /// <summary>需要行数</summary>
        [DisplayName("需要行数")]
        [Description("需要行数")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(6, "NeedRows", "需要行数", "1", "Long", 10, 0, false)]
        public virtual Int32 NeedRows
        {
            get { return _NeedRows; }
            set { if (OnPropertyChanging("NeedRows", value)) { _NeedRows = value; OnPropertyChanged("NeedRows"); } }
        }

        private Double _CorrectRate;
        /// <summary>正确率</summary>
        [DisplayName("正确率")]
        [Description("正确率")]
        [DataObjectField(false, false, true, 15)]
        [BindColumn(7, "CorrectRate", "正确率", "0", "Double", 15, 0, false)]
        public virtual Double CorrectRate
        {
            get { return _CorrectRate; }
            set { if (OnPropertyChanging("CorrectRate", value)) { _CorrectRate = value; OnPropertyChanged("CorrectRate"); } }
        }

        private String _FilterInfo;
        /// <summary>过滤信息</summary>
        [DisplayName("过滤信息")]
        [Description("过滤信息")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(8, "FilterInfo", "过滤信息", null, "VarChar", 0, 0, false)]
        public virtual String FilterInfo
        {
            get { return _FilterInfo; }
            set { if (OnPropertyChanging("FilterInfo", value)) { _FilterInfo = value; OnPropertyChanged("FilterInfo"); } }
        }

        private Boolean _Enable;
        /// <summary>有效</summary>
        [DisplayName("有效")]
        [Description("有效")]
        [DataObjectField(false, false, false, 2)]
        [BindColumn(9, "Enable", "有效", "True", "Bit", 0, 0, false)]
        public virtual Boolean Enable
        {
            get { return _Enable; }
            set { if (OnPropertyChanging("Enable", value)) { _Enable = value; OnPropertyChanged("Enable"); } }
        }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, false, 8)]
        [BindColumn(10, "UpdateTime", "更新时间", null, "DateTime", 0, 0, false)]
        public virtual DateTime UpdateTime
        {
            get { return _UpdateTime; }
            set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(11, "Remark", "备注", null, "VarChar", 0, 0, false)]
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
                    case "SchemeId" : return _SchemeId;
                    case "IndexSelectorNameTP" : return _IndexSelectorNameTP;
                    case "CompareRuleNameTP" : return _CompareRuleNameTP;
                    case "RuleCompareParams" : return _RuleCompareParams;
                    case "NeedRows" : return _NeedRows;
                    case "CorrectRate" : return _CorrectRate;
                    case "FilterInfo" : return _FilterInfo;
                    case "Enable" : return _Enable;
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
                    case "SchemeId" : _SchemeId = Convert.ToString(value); break;
                    case "IndexSelectorNameTP" : _IndexSelectorNameTP = Convert.ToString(value); break;
                    case "CompareRuleNameTP" : _CompareRuleNameTP = Convert.ToString(value); break;
                    case "RuleCompareParams" : _RuleCompareParams = Convert.ToString(value); break;
                    case "NeedRows" : _NeedRows = Convert.ToInt32(value); break;
                    case "CorrectRate" : _CorrectRate = Convert.ToDouble(value); break;
                    case "FilterInfo" : _FilterInfo = Convert.ToString(value); break;
                    case "Enable" : _Enable = Convert.ToBoolean(value); break;
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

            ///<summary>方案编号</summary>
            public static readonly FieldItem SchemeId = Meta.Table.FindByName("SchemeId");

            ///<summary>指标函数</summary>
            public static readonly FieldItem IndexSelectorNameTP = Meta.Table.FindByName("IndexSelectorNameTP");

            ///<summary>对比类型</summary>
            public static readonly FieldItem CompareRuleNameTP = Meta.Table.FindByName("CompareRuleNameTP");

            ///<summary>比较参数</summary>
            public static readonly FieldItem RuleCompareParams = Meta.Table.FindByName("RuleCompareParams");

            ///<summary>需要行数</summary>
            public static readonly FieldItem NeedRows = Meta.Table.FindByName("NeedRows");

            ///<summary>正确率</summary>
            public static readonly FieldItem CorrectRate = Meta.Table.FindByName("CorrectRate");

            ///<summary>过滤信息</summary>
            public static readonly FieldItem FilterInfo = Meta.Table.FindByName("FilterInfo");

            ///<summary>有效</summary>
            public static readonly FieldItem Enable = Meta.Table.FindByName("Enable");

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

        /// <summary>方案编号</summary>
        String SchemeId { get; set; }

        /// <summary>指标函数</summary>
        String IndexSelectorNameTP { get; set; }

        /// <summary>对比类型</summary>
        String CompareRuleNameTP { get; set; }

        /// <summary>比较参数</summary>
        String RuleCompareParams { get; set; }

        /// <summary>需要行数</summary>
        Int32 NeedRows { get; set; }

        /// <summary>正确率</summary>
        Double CorrectRate { get; set; }

        /// <summary>过滤信息</summary>
        String FilterInfo { get; set; }

        /// <summary>有效</summary>
        Boolean Enable { get; set; }

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