﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Common;
using System.Reflection;
using System.Xml.Serialization;
using NewLife.Collections;
using NewLife.Configuration;
using XCode.DataAccessLayer;
using NewLife.Reflection;

namespace XCode.Configuration
{
    /// <summary>数据表元数据</summary>
    public class TableItem
    {
        #region 特性
        private Type _EntityType;
        /// <summary>实体类型</summary>
        public Type EntityType { get { return _EntityType; } }

        private BindTableAttribute _Table;
        /// <summary>绑定表特性</summary>
        public BindTableAttribute Table { get { return _Table; } }

        private BindIndexAttribute[] _Indexes;
        /// <summary>绑定索引特性</summary>
        public BindIndexAttribute[] Indexes { get { return _Indexes; } }

        private BindRelationAttribute[] _Relations;
        /// <summary>绑定关系特性</summary>
        public BindRelationAttribute[] Relations { get { return _Relations; } }

        private DescriptionAttribute _Description;
        /// <summary>说明</summary>
        public String Description
        {
            get
            {
                if (_Description != null && !String.IsNullOrEmpty(_Description.Description)) return _Description.Description;
                if (Table != null && !String.IsNullOrEmpty(Table.Description)) return Table.Description;

                return null;
            }
        }

        /// <summary>模型检查模式</summary>
        private ModelCheckModeAttribute _ModelCheckMode;
        ///// <summary>模型检查模式</summary>
        //private ModelCheckModeAttribute ModelCheckMode { get { return _ModelCheckMode; } }
        #endregion

        #region 属性
        private String _TableName;
        /// <summary>表名</summary>
        public String TableName
        {
            get
            {
                if (String.IsNullOrEmpty(_TableName))
                {
                    BindTableAttribute table = Table;
                    String str = table != null ? table.Name : EntityType.Name;

                    if (DAL.ConnStrs.ContainsKey(ConnName))
                    {
                        // 特殊处理Oracle数据库，在表名前加上方案名（用户名）
                        DAL dal = DAL.Create(ConnName);
                        if (dal != null && !str.Contains("."))
                        {
                            if (dal.DbType == DatabaseType.Oracle)
                            {
                                // 加上用户名
                                //String UserID = (dal.Db as Oracle).UserID;
                                //if (!String.IsNullOrEmpty(UserID)) str = UserID + "." + str;

                                DbConnectionStringBuilder ocsb = dal.Db.Factory.CreateConnectionStringBuilder();
                                ocsb.ConnectionString = dal.ConnStr;
                                if (ocsb.ContainsKey("User ID")) str = (String)ocsb["User ID"] + "." + str;
                            }
                        }
                    }
                    _TableName = str;
                }
                return _TableName;
            }
        }

        private String _ConnName;
        /// <summary>连接名</summary>
        public String ConnName
        {
            get
            {
                if (String.IsNullOrEmpty(_ConnName))
                {
                    String connName = null;
                    if (Table != null) connName = Table.ConnName;

                    String str = FindConnMap(connName, EntityType.Name);
                    _ConnName = String.IsNullOrEmpty(str) ? connName : str;
                }
                return _ConnName;
            }
        }

        private static List<String> _ConnMaps;
        /// <summary>连接名映射</summary>
        private static List<String> ConnMaps
        {
            get
            {
                if (_ConnMaps != null) return _ConnMaps;

                _ConnMaps = new List<String>();
                String str = Config.GetMutilConfig<String>(null, "XCode.ConnMaps", "XCodeConnMaps");
                if (String.IsNullOrEmpty(str)) return _ConnMaps;
                String[] ss = str.Split(',');
                foreach (String item in ss)
                {
                    if (item.Contains("#") && !item.EndsWith("#") ||
                        item.Contains("@") && !item.EndsWith("@")) _ConnMaps.Add(item.Trim());
                }
                return _ConnMaps;
            }
        }

        /// <summary>根据连接名和类名查找连接名映射</summary>
        /// <param name="connName"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        private static String FindConnMap(String connName, String className)
        {
            String name1 = connName + "#";
            String name2 = className + "@";

            foreach (String item in ConnMaps)
            {
                if (item.StartsWith(name1)) return item.Substring(name1.Length);
                if (item.StartsWith(name2)) return item.Substring(name2.Length);
            }
            return null;
        }
        #endregion

        #region 扩展属性
        private FieldItem[] _Fields;
        /// <summary>数据字段</summary>
        [XmlArray]
        [Description("数据字段")]
        public FieldItem[] Fields { get { return _Fields; } }

        private FieldItem[] _AllFields;
        /// <summary>所有字段</summary>
        [XmlIgnore]
        public FieldItem[] AllFields { get { return _AllFields; } }

        private FieldItem _Identity;
        /// <summary>标识列</summary>
        [XmlIgnore]
        public FieldItem Identity { get { return _Identity; } }

        private FieldItem[] _PrimaryKeys;
        /// <summary>主键</summary>
        [XmlIgnore]
        public FieldItem[] PrimaryKeys { get { return _PrimaryKeys; } }

        private IList<String> _FieldNames;
        /// <summary>字段名集合</summary>
        [XmlIgnore]
        public IList<String> FieldNames
        {
            get
            {
                if (_FieldNames != null) return _FieldNames;

                List<String> list = new List<String>();
                foreach (FieldItem item in Fields)
                {
                    if (!list.Contains(item.Name)) list.Add(item.Name);
                }
                _FieldNames = new ReadOnlyCollection<String>(list);

                return _FieldNames;
            }
        }

        //private Dictionary<String, FieldItem> _FieldItems;
        ///// <summary>数据字段字典，字段名不区分大小写</summary>
        //public Dictionary<String, FieldItem> FieldItems
        //{
        //    get
        //    {
        //        if (_FieldItems == null)
        //        {
        //            Dictionary<String, FieldItem> dic = new Dictionary<String, FieldItem>(StringComparer.OrdinalIgnoreCase);
        //            foreach (FieldItem item in Fields)
        //            {
        //                if (!dic.ContainsKey(item.Name)) dic.Add(item.Name, item);
        //                if (!dic.ContainsKey(item.ColumnName)) dic.Add(item.ColumnName, item);
        //            }
        //            _FieldItems = dic;
        //        }

        //        return _FieldItems;
        //    }
        //}

        private IDataTable _DataTable;
        /// <summary>数据表架构</summary>
        [XmlIgnore]
        public IDataTable DataTable { get { return _DataTable; } }

        /// <summary>模型检查模式</summary>
        public ModelCheckModes ModelCheckMode { get { return _ModelCheckMode != null ? _ModelCheckMode.Mode : ModelCheckModes.CheckAllTablesWhenInit; } }
        #endregion

        #region 构造
        private TableItem(Type type)
        {
            _EntityType = type;
            _Table = type.GetCustomAttribute<BindTableAttribute>(true);
            if (_Table == null) throw new ArgumentOutOfRangeException("type", "类型" + type + "没有" + typeof(BindTableAttribute).Name + "特性！");

            _Indexes = type.GetCustomAttributes<BindIndexAttribute>(true);
            _Relations = type.GetCustomAttributes<BindRelationAttribute>(true);

            _Description = type.GetCustomAttribute<DescriptionAttribute>(true);

            _ModelCheckMode = type.GetCustomAttribute<ModelCheckModeAttribute>(true);

            InitFields();
        }

        static DictionaryCache<Type, TableItem> cache = new DictionaryCache<Type, TableItem>();
        /// <summary>创建</summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static TableItem Create(Type type)
        {
            if (type == null) throw new ArgumentNullException("type");
            //if (BindTableAttribute.GetCustomAttribute(type) == null)
            //    throw new ArgumentOutOfRangeException("type", "类型" + type + "没有" + typeof(BindTableAttribute).Name + "特性！");

            // 不能给没有BindTableAttribute特性的类型创建TableItem，否则可能会在InitFields中抛出异常
            return cache.GetItem(type, key => key.GetCustomAttribute<BindTableAttribute>(true) != null ? new TableItem(key) : null);
        }

        //Boolean hasInitFields = false;
        void InitFields()
        {
            //if (hasInitFields) return;
            //hasInitFields = true;

            BindTableAttribute bt = Table;
            IDataTable table = DAL.CreateTable();
            _DataTable = table;
            table.Name = bt.Name;
            table.Alias = EntityType.Name;
            table.DbType = bt.DbType;
            table.Description = Description;

            List<FieldItem> allfields = new List<FieldItem>();
            List<FieldItem> fields = new List<FieldItem>();
            List<FieldItem> pkeys = new List<FieldItem>();
            PropertyInfo[] pis = EntityType.GetProperties();
            foreach (PropertyInfo item in pis)
            {
                // 排除索引器
                if (item.GetIndexParameters().Length > 0) continue;

                FieldItem fi = new Field(this, item);
                allfields.Add(fi);

                if (fi.IsDataObjectField)
                {
                    fields.Add(fi);

                    IDataColumn f = table.CreateColumn();
                    fi.Fill(f);

                    //list.Add(f);
                    table.Columns.Add(f);
                }

                if (fi.PrimaryKey) pkeys.Add(fi);
                if (fi.IsIdentity) _Identity = fi;
            }
            if (_Indexes != null && _Indexes.Length > 0)
            {
                foreach (BindIndexAttribute item in _Indexes)
                {
                    IDataIndex di = table.CreateIndex();
                    item.Fill(di);

                    if (ModelHelper.GetIndex(table, di.Columns) != null) continue;

                    // 判断主键
                    IDataColumn[] dcs = table.GetColumns(di.Columns);
                    if (Array.TrueForAll<IDataColumn>(dcs, dc => dc.PrimaryKey))
                    {
                        di.PrimaryKey = true;
                        di.Unique = true;
                    }

                    table.Indexes.Add(di);
                }
            }
            if (_Relations != null && _Relations.Length > 0)
            {
                foreach (BindRelationAttribute item in _Relations)
                {
                    IDataRelation dr = table.CreateRelation();
                    item.Fill(dr);

                    Boolean exists = false;
                    foreach (IDataRelation elm in table.Relations)
                    {
                        if (!String.Equals(elm.Column, dr.Column, StringComparison.OrdinalIgnoreCase)) continue;
                        if (!String.Equals(elm.RelationTable, dr.RelationTable, StringComparison.OrdinalIgnoreCase)) continue;
                        if (!String.Equals(elm.RelationColumn, dr.RelationColumn, StringComparison.OrdinalIgnoreCase)) continue;

                        exists = true;
                        break;
                    }

                    if (!exists) table.Relations.Add(dr);
                }
            }
            //if (allfields != null && allfields.Count > 0) _AllFields = allfields.ToArray();
            //if (fields != null && fields.Count > 0) _Fields = fields.ToArray();
            //if (pkeys != null && pkeys.Count > 0) _PrimaryKeys = pkeys.ToArray();

            // 不允许为null
            _AllFields = allfields.ToArray();
            _Fields = fields.ToArray();
            _PrimaryKeys = pkeys.ToArray();
        }
        #endregion

        #region 方法
        /// <summary>根据名称查找</summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Field FindByName(String name)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentNullException("name");

            foreach (FieldItem item in Fields)
            {
                if (String.Equals(item.Name, name, StringComparison.OrdinalIgnoreCase)) return item as Field;
            }

            foreach (FieldItem item in Fields)
            {
                if (String.Equals(item.ColumnName, name, StringComparison.OrdinalIgnoreCase)) return item as Field;
            }

            return null;
        }

        /// <summary>已重载。</summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (String.IsNullOrEmpty(Description))
                return TableName;
            else
                return String.Format("{0}（{1}）", TableName, Description);
        }
        #endregion
    }
}