/*
 * XCoder v4.3.2011.0915
 * 作者：Administrator/PC2010081511LNR
 * 时间：2011-10-11 15:59:28
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
    /// <summary>数据</summary>
    [Serializable]
    [DataObject]
    [Description("数据")]
    [BindIndex("PrimaryKey", true, "序号")]
    [BindTable("Data", Description = "数据", ConnName = "YoungRunST", DbType = DatabaseType.Access)]
    public partial class Data : IData
    
    {
        #region 属性
        private Int32 _序号;
        /// <summary>序号</summary>
        [DisplayName("序号")]
        [Description("序号")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "序号", "序号", null, "Long", 10, 0, false)]
        public Int32 序号
        {
            get { return _序号; }
            set { if (OnPropertyChanging("序号", value)) { _序号 = value; OnPropertyChanged("序号"); } }
        }

        private Int32 _日期1;
        /// <summary>日期1</summary>
        [DisplayName("日期1")]
        [Description("日期1")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(2, "日期1", "日期1", "0", "Long", 10, 0, false)]
        public Int32 日期1
        {
            get { return _日期1; }
            set { if (OnPropertyChanging("日期1", value)) { _日期1 = value; OnPropertyChanged("日期1"); } }
        }

        private Int32 _日期2;
        /// <summary>日期2</summary>
        [DisplayName("日期2")]
        [Description("日期2")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(3, "日期2", "日期2", "0", "Long", 10, 0, false)]
        public Int32 日期2
        {
            get { return _日期2; }
            set { if (OnPropertyChanging("日期2", value)) { _日期2 = value; OnPropertyChanged("日期2"); } }
        }

        private Int32 _时间1;
        /// <summary>时间1</summary>
        [DisplayName("时间1")]
        [Description("时间1")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(4, "时间1", "时间1", "0", "Long", 10, 0, false)]
        public Int32 时间1
        {
            get { return _时间1; }
            set { if (OnPropertyChanging("时间1", value)) { _时间1 = value; OnPropertyChanged("时间1"); } }
        }

        private Int32 _时间2;
        /// <summary>时间2</summary>
        [DisplayName("时间2")]
        [Description("时间2")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(5, "时间2", "时间2", "0", "Long", 10, 0, false)]
        public Int32 时间2
        {
            get { return _时间2; }
            set { if (OnPropertyChanging("时间2", value)) { _时间2 = value; OnPropertyChanged("时间2"); } }
        }

        private String _操作员;
        /// <summary>操作员</summary>
        [DisplayName("操作员")]
        [Description("操作员")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(6, "操作员", "操作员", null, "VarChar", 0, 0, false)]
        public String 操作员
        {
            get { return _操作员; }
            set { if (OnPropertyChanging("操作员", value)) { _操作员 = value; OnPropertyChanged("操作员"); } }
        }

        private Int32 _打印次数;
        /// <summary>打印次数</summary>
        [DisplayName("打印次数")]
        [Description("打印次数")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(7, "打印次数", "打印次数", "0", "Long", 10, 0, false)]
        public Int32 打印次数
        {
            get { return _打印次数; }
            set { if (OnPropertyChanging("打印次数", value)) { _打印次数 = value; OnPropertyChanged("打印次数"); } }
        }

        private String _毛重;
        /// <summary>毛重</summary>
        [DisplayName("毛重")]
        [Description("毛重")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(8, "毛重", "毛重", null, "VarChar", 0, 0, false)]
        public String 毛重
        {
            get { return _毛重; }
            set { if (OnPropertyChanging("毛重", value)) { _毛重 = value; OnPropertyChanged("毛重"); } }
        }

        private String _皮重;
        /// <summary>皮重</summary>
        [DisplayName("皮重")]
        [Description("皮重")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(9, "皮重", "皮重", null, "VarChar", 0, 0, false)]
        public String 皮重
        {
            get { return _皮重; }
            set { if (OnPropertyChanging("皮重", value)) { _皮重 = value; OnPropertyChanged("皮重"); } }
        }

        private String _车号;
        /// <summary>车号</summary>
        [DisplayName("车号")]
        [Description("车号")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(10, "车号", "车号", null, "VarChar", 0, 0, false)]
        public String 车号
        {
            get { return _车号; }
            set { if (OnPropertyChanging("车号", value)) { _车号 = value; OnPropertyChanged("车号"); } }
        }

        private String _货号;
        /// <summary>货号</summary>
        [DisplayName("货号")]
        [Description("货号")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(11, "货号", "货号", null, "VarChar", 0, 0, false)]
        public String 货号
        {
            get { return _货号; }
            set { if (OnPropertyChanging("货号", value)) { _货号 = value; OnPropertyChanged("货号"); } }
        }

        private String _客户;
        /// <summary>客户</summary>
        [DisplayName("客户")]
        [Description("客户")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(12, "客户", "客户", null, "VarChar", 0, 0, false)]
        public String 客户
        {
            get { return _客户; }
            set { if (OnPropertyChanging("客户", value)) { _客户 = value; OnPropertyChanged("客户"); } }
        }

        private String _净重;
        /// <summary>净重</summary>
        [DisplayName("净重")]
        [Description("净重")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(13, "净重", "净重", null, "VarChar", 0, 0, false)]
        public String 净重
        {
            get { return _净重; }
            set { if (OnPropertyChanging("净重", value)) { _净重 = value; OnPropertyChanged("净重"); } }
        }

        private String _折扣率;
        /// <summary>折扣率</summary>
        [DisplayName("折扣率")]
        [Description("折扣率")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(14, "折扣率", "折扣率", null, "VarChar", 0, 0, false)]
        public String 折扣率
        {
            get { return _折扣率; }
            set { if (OnPropertyChanging("折扣率", value)) { _折扣率 = value; OnPropertyChanged("折扣率"); } }
        }

        private String _金额;
        /// <summary>金额</summary>
        [DisplayName("金额")]
        [Description("金额")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(15, "金额", "金额", null, "VarChar", 0, 0, false)]
        public String 金额
        {
            get { return _金额; }
            set { if (OnPropertyChanging("金额", value)) { _金额 = value; OnPropertyChanged("金额"); } }
        }

        private String _业务类别;
        /// <summary>业务类别</summary>
        [DisplayName("业务类别")]
        [Description("业务类别")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(16, "业务类别", "业务类别", null, "VarChar", 0, 0, false)]
        public String 业务类别
        {
            get { return _业务类别; }
            set { if (OnPropertyChanging("业务类别", value)) { _业务类别 = value; OnPropertyChanged("业务类别"); } }
        }

        private String _驾驶员;
        /// <summary>驾驶员</summary>
        [DisplayName("驾驶员")]
        [Description("驾驶员")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(17, "驾驶员", "驾驶员", null, "VarChar", 0, 0, false)]
        public String 驾驶员
        {
            get { return _驾驶员; }
            set { if (OnPropertyChanging("驾驶员", value)) { _驾驶员 = value; OnPropertyChanged("驾驶员"); } }
        }

        private String _发货单位;
        /// <summary>发货单位</summary>
        [DisplayName("发货单位")]
        [Description("发货单位")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(18, "发货单位", "发货单位", null, "VarChar", 0, 0, false)]
        public String 发货单位
        {
            get { return _发货单位; }
            set { if (OnPropertyChanging("发货单位", value)) { _发货单位 = value; OnPropertyChanged("发货单位"); } }
        }

        private String _运货单位;
        /// <summary>运货单位</summary>
        [DisplayName("运货单位")]
        [Description("运货单位")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(19, "运货单位", "运货单位", null, "VarChar", 0, 0, false)]
        public String 运货单位
        {
            get { return _运货单位; }
            set { if (OnPropertyChanging("运货单位", value)) { _运货单位 = value; OnPropertyChanged("运货单位"); } }
        }

        private String _代理单位;
        /// <summary>代理单位</summary>
        [DisplayName("代理单位")]
        [Description("代理单位")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(20, "代理单位", "代理单位", null, "VarChar", 0, 0, false)]
        public String 代理单位
        {
            get { return _代理单位; }
            set { if (OnPropertyChanging("代理单位", value)) { _代理单位 = value; OnPropertyChanged("代理单位"); } }
        }

        private String _收货单位;
        /// <summary>收货单位</summary>
        [DisplayName("收货单位")]
        [Description("收货单位")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(21, "收货单位", "收货单位", null, "VarChar", 0, 0, false)]
        public String 收货单位
        {
            get { return _收货单位; }
            set { if (OnPropertyChanging("收货单位", value)) { _收货单位 = value; OnPropertyChanged("收货单位"); } }
        }

        private String _包装重;
        /// <summary>包装重</summary>
        [DisplayName("包装重")]
        [Description("包装重")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(22, "包装重", "包装重", null, "VarChar", 0, 0, false)]
        public String 包装重
        {
            get { return _包装重; }
            set { if (OnPropertyChanging("包装重", value)) { _包装重 = value; OnPropertyChanged("包装重"); } }
        }

        private String _单价;
        /// <summary>单价</summary>
        [DisplayName("单价")]
        [Description("单价")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(23, "单价", "单价", null, "VarChar", 0, 0, false)]
        public String 单价
        {
            get { return _单价; }
            set { if (OnPropertyChanging("单价", value)) { _单价 = value; OnPropertyChanged("单价"); } }
        }

        private String _备注;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(24, "备注", "备注", null, "VarChar", 0, 0, false)]
        public String 备注
        {
            get { return _备注; }
            set { if (OnPropertyChanging("备注", value)) { _备注 = value; OnPropertyChanged("备注"); } }
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
                    case "序号" : return _序号;
                    case "日期1" : return _日期1;
                    case "日期2" : return _日期2;
                    case "时间1" : return _时间1;
                    case "时间2" : return _时间2;
                    case "操作员" : return _操作员;
                    case "打印次数" : return _打印次数;
                    case "毛重" : return _毛重;
                    case "皮重" : return _皮重;
                    case "车号" : return _车号;
                    case "货号" : return _货号;
                    case "客户" : return _客户;
                    case "净重" : return _净重;
                    case "折扣率" : return _折扣率;
                    case "金额" : return _金额;
                    case "业务类别" : return _业务类别;
                    case "驾驶员" : return _驾驶员;
                    case "发货单位" : return _发货单位;
                    case "运货单位" : return _运货单位;
                    case "代理单位" : return _代理单位;
                    case "收货单位" : return _收货单位;
                    case "包装重" : return _包装重;
                    case "单价" : return _单价;
                    case "备注" : return _备注;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "序号" : _序号 = Convert.ToInt32(value); break;
                    case "日期1" : _日期1 = Convert.ToInt32(value); break;
                    case "日期2" : _日期2 = Convert.ToInt32(value); break;
                    case "时间1" : _时间1 = Convert.ToInt32(value); break;
                    case "时间2" : _时间2 = Convert.ToInt32(value); break;
                    case "操作员" : _操作员 = Convert.ToString(value); break;
                    case "打印次数" : _打印次数 = Convert.ToInt32(value); break;
                    case "毛重" : _毛重 = Convert.ToString(value); break;
                    case "皮重" : _皮重 = Convert.ToString(value); break;
                    case "车号" : _车号 = Convert.ToString(value); break;
                    case "货号" : _货号 = Convert.ToString(value); break;
                    case "客户" : _客户 = Convert.ToString(value); break;
                    case "净重" : _净重 = Convert.ToString(value); break;
                    case "折扣率" : _折扣率 = Convert.ToString(value); break;
                    case "金额" : _金额 = Convert.ToString(value); break;
                    case "业务类别" : _业务类别 = Convert.ToString(value); break;
                    case "驾驶员" : _驾驶员 = Convert.ToString(value); break;
                    case "发货单位" : _发货单位 = Convert.ToString(value); break;
                    case "运货单位" : _运货单位 = Convert.ToString(value); break;
                    case "代理单位" : _代理单位 = Convert.ToString(value); break;
                    case "收货单位" : _收货单位 = Convert.ToString(value); break;
                    case "包装重" : _包装重 = Convert.ToString(value); break;
                    case "单价" : _单价 = Convert.ToString(value); break;
                    case "备注" : _备注 = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得数据字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>序号</summary>
            public static readonly FieldItem 序号 = Meta.Table.FindByName("序号");

            ///<summary>日期1</summary>
            public static readonly FieldItem 日期1 = Meta.Table.FindByName("日期1");

            ///<summary>日期2</summary>
            public static readonly FieldItem 日期2 = Meta.Table.FindByName("日期2");

            ///<summary>时间1</summary>
            public static readonly FieldItem 时间1 = Meta.Table.FindByName("时间1");

            ///<summary>时间2</summary>
            public static readonly FieldItem 时间2 = Meta.Table.FindByName("时间2");

            ///<summary>操作员</summary>
            public static readonly FieldItem 操作员 = Meta.Table.FindByName("操作员");

            ///<summary>打印次数</summary>
            public static readonly FieldItem 打印次数 = Meta.Table.FindByName("打印次数");

            ///<summary>毛重</summary>
            public static readonly FieldItem 毛重 = Meta.Table.FindByName("毛重");

            ///<summary>皮重</summary>
            public static readonly FieldItem 皮重 = Meta.Table.FindByName("皮重");

            ///<summary>车号</summary>
            public static readonly FieldItem 车号 = Meta.Table.FindByName("车号");

            ///<summary>货号</summary>
            public static readonly FieldItem 货号 = Meta.Table.FindByName("货号");

            ///<summary>客户</summary>
            public static readonly FieldItem 客户 = Meta.Table.FindByName("客户");

            ///<summary>净重</summary>
            public static readonly FieldItem 净重 = Meta.Table.FindByName("净重");

            ///<summary>折扣率</summary>
            public static readonly FieldItem 折扣率 = Meta.Table.FindByName("折扣率");

            ///<summary>金额</summary>
            public static readonly FieldItem 金额 = Meta.Table.FindByName("金额");

            ///<summary>业务类别</summary>
            public static readonly FieldItem 业务类别 = Meta.Table.FindByName("业务类别");

            ///<summary>驾驶员</summary>
            public static readonly FieldItem 驾驶员 = Meta.Table.FindByName("驾驶员");

            ///<summary>发货单位</summary>
            public static readonly FieldItem 发货单位 = Meta.Table.FindByName("发货单位");

            ///<summary>运货单位</summary>
            public static readonly FieldItem 运货单位 = Meta.Table.FindByName("运货单位");

            ///<summary>代理单位</summary>
            public static readonly FieldItem 代理单位 = Meta.Table.FindByName("代理单位");

            ///<summary>收货单位</summary>
            public static readonly FieldItem 收货单位 = Meta.Table.FindByName("收货单位");

            ///<summary>包装重</summary>
            public static readonly FieldItem 包装重 = Meta.Table.FindByName("包装重");

            ///<summary>单价</summary>
            public static readonly FieldItem 单价 = Meta.Table.FindByName("单价");

            ///<summary>备注</summary>
            public static readonly FieldItem 备注 = Meta.Table.FindByName("备注");
        }
        #endregion
    }

    /// <summary>数据接口</summary>
    public partial interface IData
    {
        #region 属性
        /// <summary>序号</summary>
        Int32 序号 { get; set; }

        /// <summary>日期1</summary>
        Int32 日期1 { get; set; }

        /// <summary>日期2</summary>
        Int32 日期2 { get; set; }

        /// <summary>时间1</summary>
        Int32 时间1 { get; set; }

        /// <summary>时间2</summary>
        Int32 时间2 { get; set; }

        /// <summary>操作员</summary>
        String 操作员 { get; set; }

        /// <summary>打印次数</summary>
        Int32 打印次数 { get; set; }

        /// <summary>毛重</summary>
        String 毛重 { get; set; }

        /// <summary>皮重</summary>
        String 皮重 { get; set; }

        /// <summary>车号</summary>
        String 车号 { get; set; }

        /// <summary>货号</summary>
        String 货号 { get; set; }

        /// <summary>客户</summary>
        String 客户 { get; set; }

        /// <summary>净重</summary>
        String 净重 { get; set; }

        /// <summary>折扣率</summary>
        String 折扣率 { get; set; }

        /// <summary>金额</summary>
        String 金额 { get; set; }

        /// <summary>业务类别</summary>
        String 业务类别 { get; set; }

        /// <summary>驾驶员</summary>
        String 驾驶员 { get; set; }

        /// <summary>发货单位</summary>
        String 发货单位 { get; set; }

        /// <summary>运货单位</summary>
        String 运货单位 { get; set; }

        /// <summary>代理单位</summary>
        String 代理单位 { get; set; }

        /// <summary>收货单位</summary>
        String 收货单位 { get; set; }

        /// <summary>包装重</summary>
        String 包装重 { get; set; }

        /// <summary>单价</summary>
        String 单价 { get; set; }

        /// <summary>备注</summary>
        String 备注 { get; set; }
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