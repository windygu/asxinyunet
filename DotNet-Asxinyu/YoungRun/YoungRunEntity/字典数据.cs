using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace YoungRunEntity
{
    /// <summary>字典数据</summary>
    [Serializable]
    [DataObject]
    [Description("字典数据")]
    [BindIndex("PRIMARY", true, "ID")]
    [BindTable("tb_dictype", Description = "字典数据", ConnName = "YoungRunMIS", DbType = DatabaseType.MySql)]
    public partial class tb_dictype : Itb_dictype
    
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

        private String _TypeName;
        /// <summary>类型名称</summary>
        [DisplayName("类型名称")]
        [Description("类型名称")]
        [DataObjectField(false, false, false, 20)]
        [BindColumn(2, "TypeName", "类型名称", null, "varchar(20)", 0, 0, false)]
        public String TypeName
        {
            get { return _TypeName; }
            set { if (OnPropertyChanging("TypeName", value)) { _TypeName = value; OnPropertyChanged("TypeName"); } }
        }

        private String _Value;
        /// <summary>数据值</summary>
        [DisplayName("数据值")]
        [Description("数据值")]
        [DataObjectField(false, false, false, 20)]
        [BindColumn(3, "Value", "数据值", null, "varchar(20)", 0, 0, false)]
        public String Value
        {
            get { return _Value; }
            set { if (OnPropertyChanging("Value", value)) { _Value = value; OnPropertyChanged("Value"); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "Remark", "备注", null, "varchar(50)", 0, 0, false)]
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
                    case "TypeName" : return _TypeName;
                    case "Value" : return _Value;
                    case "Remark" : return _Remark;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "ID" : _ID = Convert.ToUInt32(value); break;
                    case "TypeName" : _TypeName = Convert.ToString(value); break;
                    case "Value" : _Value = Convert.ToString(value); break;
                    case "Remark" : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得字典数据字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>编号</summary>
            public static readonly FieldItem ID = Meta.Table.FindByName("ID");

            ///<summary>类型名称</summary>
            public static readonly FieldItem TypeName = Meta.Table.FindByName("TypeName");

            ///<summary>数据值</summary>
            public static readonly FieldItem Value = Meta.Table.FindByName("Value");

            ///<summary>备注</summary>
            public static readonly FieldItem Remark = Meta.Table.FindByName("Remark");
        }
        #endregion
    }

    /// <summary>字典数据接口</summary>
    public partial interface Itb_dictype
    {
        #region 属性
        /// <summary>编号</summary>
        UInt32 ID { get; set; }

        /// <summary>类型名称</summary>
        String TypeName { get; set; }

        /// <summary>数据值</summary>
        String Value { get; set; }

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