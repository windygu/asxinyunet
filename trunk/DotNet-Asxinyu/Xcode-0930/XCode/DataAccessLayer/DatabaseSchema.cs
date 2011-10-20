﻿//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Text;
//using System.Threading;
//using NewLife.Collections;
//using NewLife.Configuration;
//using NewLife.Log;
//using XCode.Common;
//using XCode.Configuration;

//namespace XCode.DataAccessLayer
//{
//    /// <summary>数据架构</summary>
//    class DatabaseSchema
//    {
//        #region 属性
//        private IDatabase _Database;
//        /// <summary>数据库</summary>
//        private IDatabase Database
//        {
//            get { return _Database; }
//            set { _Database = value; }
//        }

//        /// <summary>连接名</summary>
//        private String ConnName { get { return Database.ConnName; } }

//        private IMetaData _MetaData;
//        /// <summary>数据库元数据</summary>
//        private IMetaData MetaData
//        {
//            get { return _MetaData ?? (_MetaData = Database.CreateMetaData()); }
//        }

//        private List<IDataTable> _EntityTables;
//        /// <summary>实体表集合</summary>
//        private List<IDataTable> EntityTables
//        {
//            get
//            {
//                if (_EntityTables == null) _EntityTables = EntityFactory.GetTablesByConnName(ConnName);

//                return _EntityTables;
//            }
//            set { _EntityTables = null; }
//        }

//        private Dictionary<String, IDataTable> _DBTables;
//        /// <summary>数据库表集合</summary>
//        private Dictionary<String, IDataTable> DBTables
//        {
//            get
//            {
//                if (_DBTables != null) return _DBTables;
//                lock (this)
//                {
//                    if (_DBTables != null) return _DBTables;

//                    List<IDataTable> list = MetaData.GetTables();

//                    _DBTables = new Dictionary<String, IDataTable>();
//                    if (list != null && list.Count > 0)
//                    {
//                        foreach (IDataTable item in list)
//                        {
//                            _DBTables.Add(item.Name, item);
//                        }
//                    }
//                }
//                return _DBTables;
//            }
//        }
//        #endregion

//        #region 构造函数
//        /// <summary>
//        /// 构造函数
//        /// </summary>
//        /// <param name="database"></param>
//        private DatabaseSchema(IDatabase database)
//        {
//            Database = database;
//        }

//        private static DictionaryCache<IDatabase, DatabaseSchema> _objcache = new DictionaryCache<IDatabase, DatabaseSchema>();
//        /// <summary>
//        /// 创建对象
//        /// </summary>
//        /// <param name="database"></param>
//        /// <returns></returns>
//        public static DatabaseSchema Create(IDatabase database)
//        {
//            return _objcache.GetItem(database, delegate(IDatabase key)
//            {
//                return new DatabaseSchema(key);
//            });
//        }

//        /// <summary>
//        /// 检查数据库信息架构，如果打开开关，则同步检查，否则异步检查
//        /// </summary>
//        /// <param name="database"></param>
//        public static DatabaseSchema Check(IDatabase database)
//        {
//            DatabaseSchema ds = Create(database);
//            if (Enable == null || Exclude.Contains(database.ConnName)) return ds;

//            ds.EntityTables = null;

//            return Check(ds, database);
//        }

//        public static DatabaseSchema Check(IDatabase database, IDataTable table)
//        {
//            DatabaseSchema ds = Create(database);
//            if (Enable == null || Exclude.Contains(database.ConnName)) return ds;

//            ds.EntityTables = new List<IDataTable>();
//            ds.EntityTables.Add(table);
//            ds.Check();
//            return ds;
//        }

//        public static DatabaseSchema Check(IDatabase database, List<IDataTable> tables)
//        {
//            DatabaseSchema ds = Create(database);
//            if (Enable == null || Exclude.Contains(database.ConnName)) return ds;

//            ds.EntityTables = tables;
//            ds.Check();
//            return ds;
//        }

//        static DatabaseSchema Check(DatabaseSchema ds, IDatabase database)
//        {
//            if (Enable == null || Exclude.Contains(database.ConnName)) return ds;

//            // 打开了开关，并且设置为true时，使用同步方式检查
//            // 设置为false时，使用异步方式检查，因为上级的意思是不大关心数据库架构
//            if (Enable != null && Enable.Value)
//                ds.Check();
//            else
//                ds.BeginCheck();

//            return ds;
//        }
//        #endregion

//        #region 业务
//        private void BeginCheck()
//        {
//            if (Enable == null || Exclude.Contains(ConnName)) return;

//            ThreadPool.QueueUserWorkItem(delegate
//            {
//                try
//                {
//                    Check();
//                }
//                catch (Exception ex)
//                {
//                    XTrace.WriteLine(ex.ToString());
//                }
//            });
//        }

//        private void Check()
//        {
//            if (Enable == null || Exclude.Contains(ConnName)) return;

//            WriteLog("开始检查数据库架构：" + ConnName);

//            Stopwatch sw = new Stopwatch();
//            sw.Start();

//            try
//            {
//                CheckDatabase();

//                // 清空
//                _DBTables = null;

//                CheckAllTables();
//            }
//            finally
//            {
//                sw.Stop();

//                WriteLog("检查数据库架构" + ConnName + "耗时：" + sw.Elapsed.ToString());
//            }
//        }

//        private void CheckDatabase()
//        {
//            if (Enable == null || Exclude.Contains(ConnName)) return;

//            //数据库检查
//            Boolean dbExist = true;
//            try
//            {
//                dbExist = (Boolean)MetaData.SetSchema(DDLSchema.DatabaseExist, null);
//            }
//            catch
//            {
//                // 如果异常，默认认为数据库存在
//                dbExist = true;
//            }

//            if (!dbExist && Enable != null)
//            {
//                if (Enable.Value)
//                {
//                    WriteLog("创建数据库：{0}", ConnName);
//                    MetaData.SetSchema(DDLSchema.CreateDatabase, null, null);
//                }
//                else
//                {
//                    String sql = MetaData.GetSchemaSQL(DDLSchema.CreateDatabase, null, null);
//                    if (String.IsNullOrEmpty(sql))
//                        WriteLog("请为连接{0}创建数据库！", ConnName);
//                    else
//                        WriteLog("请为连接{0}创建数据库，使用以下语句：{1}", ConnName, Environment.NewLine + sql);
//                }
//            }
//        }

//        private void CheckAllTables()
//        {
//            if (Enable == null) return;

//            if (EntityTables == null || EntityTables.Count < 1) return;

//            WriteLog(ConnName + "实体个数：" + EntityTables.Count);

//            lock (EntityTables)
//            {
//                foreach (IDataTable item in EntityTables)
//                {
//                    if (Exclude.Contains(item.Name)) continue;

//                    CheckTable(item);
//                }
//            }
//        }

//        private void CheckTable(IDataTable table)
//        {
//            Dictionary<String, IDataTable> dic = DBTables;

//            try
//            {
//                Boolean b = false;
//                foreach (String elm in dic.Keys)
//                {
//                    if (String.Equals(elm, table.Name, StringComparison.OrdinalIgnoreCase))
//                    {
//                        CheckTable(table, dic[elm]);
//                        b = true;
//                        break;
//                    }
//                }
//                if (!b) CheckTable(table, null);
//            }
//            catch (Exception ex)
//            {
//                XTrace.WriteLine(ex.ToString());
//            }
//        }

//        private void CheckTable(IDataTable entitytable, IDataTable dbtable)
//        {
//            Boolean onlySql = !(Enable != null && Enable.Value);

//            if (dbtable == null)
//            {
//                #region 创建表
//                WriteLog("创建表：{0}({1})", entitytable.Name, entitytable.Description);

//                StringBuilder sb = new StringBuilder();
//                // 建表，如果不是onlySql，执行时DAL会输出SQL日志
//                CreateTable(sb, entitytable, onlySql);

//                // 仅获取语句
//                if (onlySql) WriteLog("XCode.Schema.Enable没有设置为True，请手工创建表：" + entitytable.Name + Environment.NewLine + sb.ToString());
//                #endregion
//            }
//            else
//            {
//                #region 修改表
//                String sql = AlterTable(entitytable, dbtable, onlySql);
//                if (!String.IsNullOrEmpty(sql) && onlySql)
//                {
//                    WriteLog("XCode.Schema.Enable没有设置为True，请手工使用以下语句修改表：" + Environment.NewLine + sql);
//                }
//                #endregion
//            }
//        }

//        private String AlterTable(IDataTable entitytable, IDataTable dbtable, Boolean onlySql)
//        {
//            #region 准备工作
//            String sql = String.Empty;
//            StringBuilder sb = new StringBuilder();
//            Dictionary<String, IDataColumn> entitydic = new Dictionary<String, IDataColumn>();
//            if (entitytable.Columns != null)
//            {
//                foreach (IDataColumn item in entitytable.Columns)
//                {
//                    entitydic.Add(item.Name.ToLower(), item);
//                }
//            }
//            Dictionary<String, IDataColumn> dbdic = new Dictionary<String, IDataColumn>();
//            if (dbtable.Columns != null)
//            {
//                foreach (IDataColumn item in dbtable.Columns)
//                {
//                    dbdic.Add(item.Name.ToLower(), item);
//                }
//            }
//            #endregion

//            #region 新增列
//            foreach (IDataColumn item in entitytable.Columns)
//            {
//                if (!dbdic.ContainsKey(item.Name.ToLower()))
//                {
//                    AddColumn(sb, item, onlySql);

//                    //// 这里必须给dbtable加加上当前列，否则下面如果刚好有删除列的话，会导致增加列成功，然后删除列重建表的时候没有新加的列
//                    ////dbtable.Columns.Add(item.Clone(dbtable));
//                    //List<IDataColumn> dcs = new List<IDataColumn>(dbtable.Columns);
//                    //dcs.Add(item.Clone(dbtable));
//                    //dbtable.Columns = dcs.ToArray();
//                }
//            }
//            #endregion

//            #region 删除列
//            StringBuilder sbDelete = new StringBuilder();
//            Dictionary<String, FieldItem> names = new Dictionary<String, FieldItem>();
//            //foreach (IDataColumn item in dbtable.Fields)
//            //{
//            //    if (!entitydic.ContainsKey(item.Name.ToLower())) DropColumn(sbDelete, item, onlySql);
//            //}
//            for (int i = dbtable.Columns.Count - 1; i >= 0; i--)
//            {
//                IDataColumn item = dbtable.Columns[i];
//                if (!entitydic.ContainsKey(item.Name.ToLower())) DropColumn(sbDelete, item, onlySql);
//            }
//            if (sbDelete.Length > 0)
//            {
//                if (NoDelete)
//                {
//                    //不许删除列，显示日志
//                    XTrace.WriteLine("数据表中发现有多余字段，XCode.Schema.NoDelete被设置为True，请手工执行以下语句删除：" + Environment.NewLine + sbDelete.ToString());
//                }
//                else
//                {
//                    if (sb.Length > 0) sb.AppendLine(";");
//                    sb.Append(sbDelete.ToString());
//                }
//            }
//            #endregion

//            #region 修改列
//            // 开发时的实体数据库
//            IDatabase entityDb = DbFactory.Create(entitytable.DbType);

//            foreach (IDataColumn item in entitytable.Columns)
//            {
//                if (!dbdic.ContainsKey(item.Name.ToLower())) continue;
//                IDataColumn dbf = dbdic[item.Name.ToLower()];

//                // 是否已改变
//                Boolean isChanged = false;

//                //比较类型/允许空/主键
//                if (item.DataType != dbf.DataType ||
//                    item.Identity != dbf.Identity ||
//                    item.PrimaryKey != dbf.PrimaryKey ||
//                    item.Nullable != dbf.Nullable && !item.Identity && !item.PrimaryKey)
//                {
//                    isChanged = true;
//                }

//                //仅针对字符串类型比较长度
//                if (!isChanged && Type.GetTypeCode(item.DataType) == TypeCode.String && item.Length != dbf.Length)
//                {
//                    isChanged = true;

//                    //如果是大文本类型，长度可能不等
//                    if ((item.Length > Database.LongTextLength || item.Length <= 0) &&
//                        (entityDb != null && dbf.Length > entityDb.LongTextLength || dbf.Length <= 0)) isChanged = false;
//                }

//                if (isChanged) AlterColumn(sb, item, dbf, onlySql);

//                //比较默认值
//                isChanged = !String.Equals(item.Default + "", dbf.Default + "", StringComparison.OrdinalIgnoreCase);

//                //特殊处理时间
//                if (isChanged && Type.GetTypeCode(item.DataType) == TypeCode.DateTime && !String.IsNullOrEmpty(item.Default) && !String.IsNullOrEmpty(dbf.Default))
//                {
//                    // 如果当前默认值是开发数据库的时间默认值，则判断当前数据库的时间默认值
//                    if (entityDb.DateTimeNow == item.Default && Database.DateTimeNow == dbf.Default) isChanged = false;
//                }

//                if (isChanged)
//                {
//                    // 如果数据库存在默认值，则删除
//                    if (!String.IsNullOrEmpty(dbf.Default))
//                        GetSchemaSQL(sb, onlySql, DDLSchema.DropDefault, dbf);

//                    // 如果实体存在默认值，则增加
//                    if (!String.IsNullOrEmpty(item.Default))
//                    {
//                        if (Type.GetTypeCode(item.DataType) == TypeCode.DateTime)
//                        {
//                            // 特殊处理时间
//                            String dv = item.Default;
//                            // 如果当前默认值是开发数据库的时间默认值，则修改为当前数据库的时间默认值
//                            if (entityDb.DateTimeNow == item.Default) item.Default = Database.DateTimeNow;

//                            GetSchemaSQL(sb, onlySql, DDLSchema.AddDefault, item);

//                            // 还原
//                            item.Default = dv;
//                        }
//                        else
//                            GetSchemaSQL(sb, onlySql, DDLSchema.AddDefault, item);
//                    }
//                }

//                if (item.Description + "" != dbf.Description + "")
//                {
//                    // 先删除旧注释
//                    if (!String.IsNullOrEmpty(dbf.Description)) DropColumnDescription(sb, dbf, onlySql);

//                    // 加上新注释
//                    if (!String.IsNullOrEmpty(item.Description)) AddColumnDescription(sb, item, onlySql);
//                }
//            }
//            #endregion

//            #region 表说明
//            if (entitytable.Description != dbtable.Description)
//            {
//                // 先删除旧注释
//                if (!String.IsNullOrEmpty(dbtable.Description)) DropTableDescription(sb, dbtable, onlySql);

//                // 加上新注释
//                if (!String.IsNullOrEmpty(entitytable.Description)) AddTableDescription(sb, entitytable, onlySql);
//            }
//            #endregion

//            #region 删除索引
//            if (dbtable.Indexes != null)
//            {
//                for (int i = dbtable.Indexes.Count - 1; i >= 0; i--)
//                {
//                    IDataIndex item = dbtable.Indexes[i];
//                    if (item.PrimaryKey) continue;

//                    IDataIndex di = ModelHelper.GetIndex(entitytable, item.Columns);
//                    if (di != null) continue;

//                    //DropIndex(sb, item, onlySql);
//                    GetSchemaSQL(sb, onlySql, DDLSchema.DropIndex, item);
//                    dbtable.Indexes.RemoveAt(i);
//                }
//            }
//            #endregion

//            #region 新增索引
//            if (entitytable.Indexes != null)
//            {
//                foreach (IDataIndex item in entitytable.Indexes)
//                {
//                    if (item.PrimaryKey) continue;

//                    IDataIndex di = ModelHelper.GetIndex(dbtable, item.Columns);
//                    if (di != null) continue;

//                    //CreateIndex(sb, item, onlySql);
//                    GetSchemaSQL(sb, onlySql, DDLSchema.CreateIndex, item);
//                    dbtable.Indexes.Add(item.Clone(dbtable));
//                }
//            }
//            #endregion

//            return sb.ToString();
//        }
//        #endregion

//        #region 架构定义
//        /// <summary>
//        /// 获取架构语句，该执行的已经执行。
//        /// 如果取不到语句，则输出日志信息；
//        /// 如果不是纯语句，则执行；
//        /// </summary>
//        /// <param name="sb"></param>
//        /// <param name="onlySql"></param>
//        /// <param name="schema"></param>
//        /// <param name="values"></param>
//        private void GetSchemaSQL(StringBuilder sb, Boolean onlySql, DDLSchema schema, params Object[] values)
//        {
//            String sql = MetaData.GetSchemaSQL(schema, values);
//            if (!String.IsNullOrEmpty(sql))
//            {
//                if (sb.Length > 0) sb.AppendLine(";");
//                sb.Append(sql);

//                //if (!onlySql) XTrace.WriteLine("修改表：" + sql);
//            }
//            else if (sql == null)
//            {
//                // 只有null才表示通过非SQL的方式处理，而String.Empty表示已经通过别的SQL处理，这里不用输出日志

//                // 没办法形成SQL，输出日志信息
//                StringBuilder s = new StringBuilder();
//                if (values != null && values.Length > 0)
//                {
//                    foreach (Object item in values)
//                    {
//                        if (s.Length > 0) s.Append(" ");
//                        s.Append(item);
//                    }
//                }
//                WriteLog("修改表：{0} {1}", schema.ToString(), s.ToString());
//                //sb.AppendFormat("修改表：{0} {1}", schema.ToString(), s.ToString());
//            }

//            if (!onlySql)
//            {
//                try
//                {
//                    MetaData.SetSchema(schema, values);
//                }
//                catch (Exception ex)
//                {
//                    WriteLog("修改表{0}失败！{1}", schema.ToString(), ex.Message);
//                }
//            }
//        }

//        void CreateTable(StringBuilder sb, IDataTable table, Boolean onlySql)
//        {
//            GetSchemaSQL(sb, onlySql, DDLSchema.CreateTable, table);

//            // 加上表注释
//            if (!String.IsNullOrEmpty(table.Description)) AddTableDescription(sb, table, onlySql);

//            // 加上字段注释
//            foreach (IDataColumn item in table.Columns)
//            {
//                if (!String.IsNullOrEmpty(item.Description)) AddColumnDescription(sb, item, onlySql);
//            }

//            // 加上索引
//            if (table.Indexes != null)
//            {
//                foreach (IDataIndex item in table.Indexes)
//                {
//                    if (item.PrimaryKey) continue;

//                    // CreateIndex(sb, item, onlySql);
//                    GetSchemaSQL(sb, onlySql, DDLSchema.CreateIndex, item);
//                }
//            }
//        }

//        void AddTableDescription(StringBuilder sb, IDataTable table, Boolean onlySql)
//        {
//            GetSchemaSQL(sb, onlySql, DDLSchema.AddTableDescription, table);
//        }

//        void DropTableDescription(StringBuilder sb, IDataTable table, Boolean onlySql)
//        {
//            GetSchemaSQL(sb, onlySql, DDLSchema.DropTableDescription, table);
//        }

//        void AddColumn(StringBuilder sb, IDataColumn field, Boolean onlySql)
//        {
//            GetSchemaSQL(sb, onlySql, DDLSchema.AddColumn, field);

//            if (!String.IsNullOrEmpty(field.Description)) AddColumnDescription(sb, field, onlySql);
//        }

//        void AddColumnDescription(StringBuilder sb, IDataColumn field, Boolean onlySql)
//        {
//            GetSchemaSQL(sb, onlySql, DDLSchema.AddColumnDescription, field);
//        }

//        void DropColumn(StringBuilder sb, IDataColumn field, Boolean onlySql)
//        {
//            if (!String.IsNullOrEmpty(field.Description)) DropColumnDescription(sb, field, onlySql);

//            GetSchemaSQL(sb, onlySql, DDLSchema.DropColumn, field);
//        }

//        void DropColumnDescription(StringBuilder sb, IDataColumn field, Boolean onlySql)
//        {
//            GetSchemaSQL(sb, onlySql, DDLSchema.DropColumnDescription, field);
//        }

//        void AlterColumn(StringBuilder sb, IDataColumn field, IDataColumn oldfield, Boolean onlySql)
//        {
//            GetSchemaSQL(sb, onlySql, DDLSchema.AlterColumn, field, oldfield);
//        }

//        //void CreateIndex(StringBuilder sb, IDataIndex di, Boolean onlySql)
//        //{
//        //    GetSchemaSQL(sb, onlySql, DDLSchema.CreateIndex, di);
//        //}

//        //void DropIndex(StringBuilder sb, IDataIndex di, Boolean onlySql)
//        //{
//        //    GetSchemaSQL(sb, onlySql, DDLSchema.DropIndex, di);
//        //}
//        #endregion

//        #region 设置
//        private static Boolean? _Enable;
//        /// <summary>
//        /// 是否启用数据架构
//        /// </summary>
//        public static Boolean? Enable
//        {
//            get
//            {
//                if (_Enable != null) return _Enable.Value;

//                //String str = ConfigurationManager.AppSettings["XCode.Schema.Enable"];
//                //if (String.IsNullOrEmpty(str)) str = ConfigurationManager.AppSettings["DatabaseSchema_Enable"];
//                //if (String.IsNullOrEmpty(str)) return null;
//                //if (str == "1" || str.Equals(Boolean.TrueString, StringComparison.OrdinalIgnoreCase))
//                //    _Enable = true;
//                //else if (str == "0" || str.Equals(Boolean.FalseString, StringComparison.OrdinalIgnoreCase))
//                //    _Enable = false;
//                //else
//                //    _Enable = Convert.ToBoolean(str);

//                _Enable = Config.GetConfig<Boolean?>("XCode.Schema.Enable", Config.GetConfig<Boolean?>("DatabaseSchema_Enable"));

//                return _Enable.Value;
//            }
//            set { _Enable = value; }
//        }

//        private static Boolean? _NoDelete;
//        /// <summary>
//        /// 是否启用不删除字段
//        /// </summary>
//        public static Boolean NoDelete
//        {
//            get
//            {
//                if (_NoDelete != null) return _NoDelete.Value;

//                _NoDelete = Config.GetConfig<Boolean>("XCode.Schema.NoDelete", Config.GetConfig<Boolean>("DatabaseSchema_NoDelete"));

//                return _NoDelete.Value;
//            }
//            set { _NoDelete = value; }
//        }

//        private static ICollection<String> _Exclude;
//        /// <summary>
//        /// 要排除的链接名
//        /// </summary>
//        public static ICollection<String> Exclude
//        {
//            get
//            {
//                if (_Exclude != null) return _Exclude;

//                //String str = ConfigurationManager.AppSettings["DatabaseSchema_Exclude"];
//                String str = Config.GetConfig<String>("XCode.Schema.Exclude", Config.GetConfig<String>("DatabaseSchema_Exclude"));

//                if (String.IsNullOrEmpty(str))
//                    _Exclude = new HashSet<String>();
//                else
//                {
//                    //_Exclude = new HashSet<String>(StringComparer.OrdinalIgnoreCase);
//                    //String[] ss = str.Split(new Char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
//                    //if (ss != null && ss.Length > 0)
//                    //{
//                    //    foreach (String item in ss)
//                    //    {
//                    //        _Exclude.Add(item);
//                    //    }
//                    //}

//                    _Exclude = new HashSet<String>(StringComparer.OrdinalIgnoreCase, str.Split(new Char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries));
//                }

//                return _Exclude;
//            }
//        }
//        #endregion

//        #region 调试输出
//        /// <summary>已重载</summary>
//        /// <returns></returns>
//        public override string ToString()
//        {
//            return Database.ToString();
//        }

//        private static void WriteLog(String msg)
//        {
//            if (DAL.Debug) DAL.WriteLog(msg);
//        }

//        private static void WriteLog(String format, params Object[] args)
//        {
//            if (DAL.Debug) DAL.WriteLog(format, args);
//        }
//        #endregion
//    }
//}