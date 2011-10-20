﻿using System;
using System.ComponentModel;
using System.Reflection;
using XCode.DataAccessLayer;

namespace XCode.Configuration
{
    /// <summary>
    /// 数据属性元数据以及特性
    /// </summary>
    public class FieldItem
    {
        #region 属性
        private PropertyInfo _Property;
        /// <summary>属性元数据</summary>
        [Obsolete("该成员在后续版本中讲不再被支持！")]
        public PropertyInfo Property
        {
            get { return _Property; }
            set { _Property = value; }
        }

        private BindColumnAttribute _Column;
        /// <summary>绑定列特性</summary>
        [Obsolete("该成员在后续版本中讲不再被支持！")]
        public BindColumnAttribute Column
        {
            get { return _Column; }
            set { _Column = value; }
        }

        private DataObjectFieldAttribute _DataObjectField;
        /// <summary>数据字段特性</summary>
        [Obsolete("该成员在后续版本中讲不再被支持！")]
        public DataObjectFieldAttribute DataObjectField
        {
            get { return _DataObjectField; }
            set { _DataObjectField = value; }
        }

        private DescriptionAttribute _Description;
        /// <summary>数据字段特性</summary>
        public String Description
        {
            get
            {
                if (_Description != null && !String.IsNullOrEmpty(_Description.Description)) return _Description.Description;
                if (_Column != null && !String.IsNullOrEmpty(_Column.Description)) return _Column.Description;
                return null;
            }
        }
        #endregion

        #region 扩展属性
        /// <summary>属性名</summary>
        public String Name { get { return _Property == null ? null : _Property.Name; } }

        /// <summary>属性类型</summary>
        public Type Type { get { return _Property == null ? null : _Property.PropertyType; } }

        /// <summary>属性类型</summary>
        internal Type DeclaringType { get { return _Property == null ? null : _Property.DeclaringType; } }

        /// <summary>是否标识列</summary>
        public Boolean IsIdentity { get { return _DataObjectField == null ? false : _DataObjectField.IsIdentity; } }

        /// <summary>是否主键</summary>
        public Boolean PrimaryKey { get { return _DataObjectField == null ? false : _DataObjectField.PrimaryKey; } }

        /// <summary>是否允许空</summary>
        public Boolean IsNullable { get { return _DataObjectField == null ? false : _DataObjectField.IsNullable; } }

        /// <summary>长度</summary>
        public Int32 Length { get { return _DataObjectField == null ? 0 : _DataObjectField.Length; } }

        /// <summary>是否数据绑定列</summary>
        internal Boolean IsDataObjectField { get { return _DataObjectField != null; } }

        /// <summary>显示名</summary>
        [Obsolete("请改为使用Description属性！")]
        public String DisplayName
        {
            get
            {
                //if (Description != null && !String.IsNullOrEmpty(Description.Description)) return Description.Description;
                //if (_Column != null && !String.IsNullOrEmpty(_Column.Description)) return _Column.Description;

                return Description;
            }
        }

        /// <summary>字段名要过滤掉的标识符，考虑MSSQL、MySql、SQLite、Oracle等</summary>
        static Char[] COLUMNNAME_FLAG = new Char[] { '[', ']', '\'', '"', '`' };

        private String _ColumnName;
        /// <summary>
        /// 用于数据绑定的字段名。
        /// 默认使用BindColumn特性中指定的字段名，如果没有指定，则使用属性名。
        /// </summary>
        public String ColumnName
        {
            get
            {
                if (_ColumnName != null) return _ColumnName;

                // 字段名可能两边带有方括号等标识符
                if (_Column != null && !String.IsNullOrEmpty(_Column.Name))
                    _ColumnName = _Column.Name.Trim(COLUMNNAME_FLAG);
                else
                    _ColumnName = _Property.Name;

                return _ColumnName;
            }
        }

        /// <summary>默认值</summary>
        public String DefaultValue { get { return _Column == null ? null : _Column.DefaultValue; } }

        private TableItem _Table;
        /// <summary>表</summary>
        public TableItem Table
        {
            get { return _Table; }
            //set { _Field = value; }
        }

        private IDataColumn _Field;
        /// <summary>字段</summary>
        public IDataColumn Field
        {
            get { return _Field; }
            //set { _Field = value; }
        }
        #endregion

        #region 构造
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="table"></param>
        /// <param name="property"></param>
        public FieldItem(TableItem table, PropertyInfo property)
        {
            if (property == null) throw new ArgumentNullException("property");

            _Table = table;

            _Property = property;
            _Column = BindColumnAttribute.GetCustomAttribute(_Property);
            _DataObjectField = DataObjectAttribute.GetCustomAttribute(_Property, typeof(DataObjectFieldAttribute)) as DataObjectFieldAttribute;
            _Description = DescriptionAttribute.GetCustomAttribute(_Property, typeof(DescriptionAttribute)) as DescriptionAttribute;
        }
        #endregion

        #region 方法
        /// <summary>
        /// 已重载。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            //if (String.IsNullOrEmpty(Description))
            //    return Name;
            //else
            //    return String.Format("{1}（{0}）", Name, Description);

            // 为了保持兼容旧的_.Name等代码，必须只能返回字段名
            return ColumnName;
        }

        /// <summary>
        /// 填充到XField中去
        /// </summary>
        /// <param name="field"></param>
        public void Fill(IDataColumn field)
        {
            _Field = field;

            if (field == null) return;

            IDataColumn xf = field;
            if (xf == null) return;

            xf.Name = ColumnName;
            xf.Alias = Name;
            xf.DataType = _Property.PropertyType;
            xf.Description = Description;

            if (_Column != null)
            {
                xf.ID = _Column.Order;
                xf.RawType = _Column.RawType;
                xf.Precision = _Column.Precision;
                xf.Scale = _Column.Scale;
                xf.IsUnicode = _Column.IsUnicode;
                xf.Default = _Column.DefaultValue;
            }
            if (_DataObjectField != null)
            {
                xf.Length = _DataObjectField.Length;
                xf.Identity = _DataObjectField.IsIdentity;
                xf.PrimaryKey = _DataObjectField.PrimaryKey;
                xf.Nullable = _DataObjectField.IsNullable;
            }
        }

        /// <summary>
        /// 建立表达式
        /// </summary>
        /// <param name="action"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereExpression CreateExpression(String action, Object value)
        {
            IEntityOperate op = EntityFactory.CreateOperate(Table.EntityType);
            String sql = null;
            String name = op.FormatName(ColumnName);
            if (!String.IsNullOrEmpty(action) && action.Contains("{0}"))
            {
                if (action.Contains("%"))
                    sql = name + " Like " + op.FormatValue(this, String.Format(action, value));
                else
                    sql = name + String.Format(action, op.FormatValue(this, value));
            }
            else
                sql = String.Format("{0}{1}{2}", name, action, op.FormatValue(this, value));
            return new WhereExpression(sql);
        }
        #endregion

        #region 重载运算符
        /// <summary>
        /// 等于
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereExpression Equal(object value) { return MakeCondition(this, value, "="); }

        /// <summary>
        /// 不等于
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereExpression NotEqual(object value) { return MakeCondition(this, value, "<>"); }

        //public static String operator ==(FieldItem field, Object value) { return MakeCondition(field, value, "=="); }
        //public static String operator !=(FieldItem field, Object value) { return MakeCondition(field, value, "<>"); }

        /// <summary>
        /// 以某个字符串开始
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereExpression StartsWith(Object value) { return CreateExpression("{0}%", value); }

        /// <summary>
        /// 以某个字符串结束
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereExpression EndsWith(Object value) { return CreateExpression("%{0}", value); }

        /// <summary>
        /// 包含某个字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WhereExpression Contains(Object value) { return CreateExpression("%{0}%", value); }

        /// <summary>
        /// 大于
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static WhereExpression operator >(FieldItem field, Object value) { return MakeCondition(field, value, ">"); }

        /// <summary>
        /// 小于
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static WhereExpression operator <(FieldItem field, Object value) { return MakeCondition(field, value, "<"); }

        /// <summary>
        /// 大于等于
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static WhereExpression operator >=(FieldItem field, Object value) { return MakeCondition(field, value, ">="); }

        /// <summary>
        /// 小于等于
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static WhereExpression operator <=(FieldItem field, Object value) { return MakeCondition(field, value, "<="); }

        static WhereExpression MakeCondition(FieldItem field, Object value, String action)
        {
            //IEntityOperate op = EntityFactory.CreateOperate(field.Table.EntityType);
            //return new WhereExpression(String.Format("{0}{1}{2}", op.FormatName(field.ColumnName), action, op.FormatValue(field, value)));
            return field == null ? new WhereExpression() : field.CreateExpression(action, value);
        }
        #endregion

        #region 类型转换
        /// <summary>
        /// 类型转换
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static implicit operator String(FieldItem obj)
        {
            return !obj.Equals(null) ? obj.ColumnName : null;
        }
        #endregion
    }
}