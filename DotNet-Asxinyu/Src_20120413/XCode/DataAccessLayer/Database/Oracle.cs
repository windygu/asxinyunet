using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using NewLife;
using NewLife.Configuration;
using NewLife.Linq;
using XCode.Common;
using System.Threading;

namespace XCode.DataAccessLayer
{
    class Oracle : RemoteDb
    {
        #region 属性
        /// <summary>返回数据库类型。外部DAL数据库类请使用Other</summary>
        public override DatabaseType DbType
        {
            get { return DatabaseType.Oracle; }
        }

        private static DbProviderFactory _dbProviderFactory;
        /// <summary>提供者工厂</summary>
        static DbProviderFactory dbProviderFactory
        {
            get
            {
                // 首先尝试使用Oracle.DataAccess
                if (_dbProviderFactory == null)
                {
                    lock (typeof(Oracle))
                    {
                        if (_dbProviderFactory == null)
                        {
                            // 检查Oracle客户端运行时
                            //ThreadPoolX.QueueUserWorkItem(CheckRuntime);
                            CheckRuntime();

                            try
                            {
                                String fileName = "Oracle.DataAccess.dll";
                                _dbProviderFactory = GetProviderFactory(fileName, "Oracle.DataAccess.Client.OracleClientFactory");
                                if (_dbProviderFactory != null && DAL.Debug)
                                {
                                    var asm = _dbProviderFactory.GetType().Assembly;
                                    if (DAL.Debug) DAL.WriteLog("Oracle使用文件驱动{0} 版本v{1}", asm.Location, asm.GetName().Version);

                                    //try
                                    //{
                                    //    var code = CheckVersionCompatibility(asm.GetName().Version.ToString());
                                    //    DAL.WriteDebugLog("Oracle检查版本兼容失败结果：{0}", code);
                                    //}
                                    //catch (Exception ex)
                                    //{
                                    //    DAL.WriteDebugLog("Oracle检查版本兼容失败！{0}", ex.Message);
                                    //}
                                }
                            }
                            catch (FileNotFoundException) { }
                            catch (Exception ex)
                            {
                                if (DAL.Debug) DAL.WriteLog(ex.ToString());
                            }
                        }

                        // 以下三种方式都可以加载，前两种只是为了减少对程序集的引用，第二种是为了避免第一种中没有注册
                        if (_dbProviderFactory == null)
                        {
                            _dbProviderFactory = DbProviderFactories.GetFactory("System.Data.OracleClient");
                            if (_dbProviderFactory != null && DAL.Debug) DAL.WriteLog("Oracle使用配置驱动{0}", _dbProviderFactory.GetType().Assembly.Location);
                        }
                        if (_dbProviderFactory == null)
                        {
                            String fileName = "System.Data.OracleClient.dll";
                            _dbProviderFactory = GetProviderFactory(fileName, "System.Data.OracleClient.OracleClientFactory");
                            if (_dbProviderFactory != null && DAL.Debug) DAL.WriteLog("Oracle使用系统驱动{0}", _dbProviderFactory.GetType().Assembly.Location);
                        }
                        //if (_dbProviderFactory == null) _dbProviderFactory = OracleClientFactory.Instance;
                    }
                }

                return _dbProviderFactory;
            }
        }

        /// <summary>工厂</summary>
        public override DbProviderFactory Factory
        {
            //get { return OracleClientFactory.Instance; }
            get { return dbProviderFactory; }
        }

        private String _UserID;
        /// <summary>用户名UserID</summary>
        public String UserID
        {
            get
            {
                if (_UserID != null) return _UserID;
                _UserID = String.Empty;

                String connStr = ConnectionString;
                if (String.IsNullOrEmpty(connStr)) return null;

                DbConnectionStringBuilder ocsb = Factory.CreateConnectionStringBuilder();
                ocsb.ConnectionString = connStr;

                if (ocsb.ContainsKey("User ID")) _UserID = (String)ocsb["User ID"];

                return _UserID;
            }
        }

        /// <summary>拥有者</summary>
        public override String Owner
        {
            get
            {
                // 利用null和Empty的区别来判断是否已计算
                if (base.Owner == null)
                {
                    base.Owner = UserID;
                    if (String.IsNullOrEmpty(base.Owner)) base.Owner = String.Empty;
                }
                return base.Owner;
            }
            set { base.Owner = value; }
        }

        private static String _DllPath;
        /// <summary>OCI目录</summary>
        public static String DllPath
        {
            get
            {
                if (_DllPath == null)
                {
                    _DllPath = "";

                    String ocifile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "oci.dll");
                    if (!File.Exists(ocifile) && Runtime.IsWeb) ocifile = Path.Combine(HttpRuntime.BinDirectory, "oci.dll");
                    if (!File.Exists(ocifile)) ocifile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"OracleClient\oci.dll");
                    if (!File.Exists(ocifile)) ocifile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\OracleClient\oci.dll");
                    if (!File.Exists(ocifile))
                    {
                        // 全盘搜索
                        try
                        {
                            foreach (var item in DriveInfo.GetDrives())
                            {
                                // 仅搜索硬盘和移动存储
                                if (item.DriveType != DriveType.Fixed && item.DriveType != DriveType.Removable || !item.IsReady) continue;

                                ocifile = Path.Combine(item.RootDirectory.FullName, @"OracleClient\oci.dll");
                                if (File.Exists(ocifile)) break;
                            }
                        }
                        catch { }
                        //ocifile = @"C:\OracleClient\oci.dll";
                    }
                    if (File.Exists(ocifile)) _DllPath = Path.GetDirectoryName(ocifile);
                }
                return _DllPath;
            }
            set
            {
                _DllPath = value;

                String ocifile = Path.Combine(value, "oci.dll");
                if (!File.Exists(ocifile))
                {
                    String dir = Path.Combine(value, "bin");
                    ocifile = Path.Combine(dir, "oci.dll");
                    if (File.Exists(ocifile)) _DllPath = dir;
                }

                if (!Path.IsPathRooted(_DllPath)) _DllPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _DllPath);
                _DllPath = new DirectoryInfo(_DllPath).FullName;
            }
        }

        private static String _OracleHome;
        /// <summary>Oracle运行时主目录</summary>
        public static String OracleHome
        {
            get
            {
                if (_OracleHome == null)
                {
                    _OracleHome = String.Empty;

                    // 如果DllPath目录存在，则基于它找主目录
                    var dir = DllPath;
                    if (!String.IsNullOrEmpty(dir) && Directory.Exists(dir))
                    {
                        _OracleHome = dir;

                        // 如果该目录就有network目录，则使用它作为主目录
                        if (!Directory.Exists(Path.Combine(dir, "network")))
                        {
                            // 否则找上一级
                            DirectoryInfo di = new DirectoryInfo(dir);
                            di = di.Parent;

                            if (Directory.Exists(Path.Combine(di.FullName, "network"))) _OracleHome = di.FullName;
                        }
                    }
                }
                return _OracleHome;
            }
            //set { _OracleHome = value; }
        }

        protected override void OnSetConnectionString(XDbConnectionStringBuilder builder)
        {
            String str = null;
            // 获取OCI目录
            if (builder.TryGetAndRemove("DllPath", out str) && !String.IsNullOrEmpty(str))
                SetDllPath(str);
            //else if (!String.IsNullOrEmpty(str = DllPath))
            //    SetDllPath(str);
            else
            {
                //if (!String.IsNullOrEmpty(str = DllPath)) SetDllPath(str);
                // 异步设置DLL目录
                ThreadPool.QueueUserWorkItem(ss => SetDllPath(DllPath));
                Thread.Sleep(500);
            }
        }

        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern IntPtr LoadLibrary(string fileName);

        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern int SetDllDirectory(string pathName);
        #endregion

        #region 方法
        /// <summary>创建数据库会话</summary>
        /// <returns></returns>
        protected override IDbSession OnCreateSession()
        {
            return new OracleSession();
        }

        /// <summary>创建元数据对象</summary>
        /// <returns></returns>
        protected override IMetaData OnCreateMetaData()
        {
            return new OracleMeta();
        }

        public override bool Support(string providerName)
        {
            providerName = providerName.ToLower();
            if (providerName.Contains("oracleclient")) return true;
            if (providerName.Contains("oracle")) return true;

            return false;
        }
        #endregion

        #region 分页
        /// <summary>已重写。获取分页</summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="startRowIndex">开始行，0表示第一行</param>
        /// <param name="maximumRows">最大返回行数，0表示所有行</param>
        /// <param name="keyColumn">主键列。用于not in分页</param>
        /// <returns></returns>
        public override String PageSplit(String sql, Int32 startRowIndex, Int32 maximumRows, String keyColumn)
        {
            // 从第一行开始，不需要分页
            if (startRowIndex <= 0)
            {
                if (maximumRows < 1)
                    return sql;
                else
                    return String.Format("Select * From ({1}) XCode_Temp_a Where rownum<={0}", maximumRows + 1, sql);
            }
            if (maximumRows < 1)
                sql = String.Format("Select * From ({1}) XCode_Temp_a Where rownum>={0}", startRowIndex + 1, sql);
            else
                sql = String.Format("Select * From (Select XCode_Temp_a.*, rownum as rowNumber From ({1}) XCode_Temp_a Where rownum<={2}) XCode_Temp_b Where rowNumber>={0}", startRowIndex + 1, sql, startRowIndex + maximumRows);
            //sql = String.Format("Select * From ({1}) a Where rownum>={0} and rownum<={2}", startRowIndex, sql, startRowIndex + maximumRows - 1);
            return sql;
        }
        #endregion

        #region 数据库特性
        /// <summary>当前时间函数</summary>
        public override string DateTimeNow { get { return "sysdate"; } }

        /// <summary>获取Guid的函数</summary>
        public override String NewGuid { get { return "sys_guid()"; } }

        /// <summary>已重载。格式化时间</summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public override string FormatDateTime(DateTime dateTime)
        {
            return String.Format("To_Date('{0}', 'YYYY-MM-DD HH24:MI:SS')", dateTime.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        public override string FormatValue(IDataColumn field, object value)
        {
            TypeCode code = Type.GetTypeCode(field.DataType);
            Boolean isNullable = field.Nullable;

            if (code == TypeCode.String)
            {
                if (value == null) return isNullable ? "null" : "''";
                if (String.IsNullOrEmpty(value.ToString()) && isNullable) return "null";

                if (field.IsUnicode || IsUnicode(field.RawType))
                    return "N'" + value.ToString().Replace("'", "''") + "'";
                else
                    return "'" + value.ToString().Replace("'", "''") + "'";
            }

            return base.FormatValue(field, value);
        }

        /// <summary>格式化标识列，返回插入数据时所用的表达式，如果字段本身支持自增，则返回空</summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override string FormatIdentity(IDataColumn field, Object value)
        {
            return String.Format("SEQ_{0}.nextval", field.Table.Name);
        }

        internal protected override String ParamPrefix { get { return ":"; } }

        /// <summary>字符串相加</summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public override String StringConcat(String left, String right) { return (!String.IsNullOrEmpty(left) ? left : "\'\'") + "||" + (!String.IsNullOrEmpty(right) ? right : "\'\'"); }
        #endregion

        #region 关键字
        //protected override string ReservedWordsStr
        //{
        //    get { return "ALL,ALTER,AND,ANY,AS,ASC,BETWEEN,BY,CHAR,CHECK,CLUSTER,COMPRESS,CONNECT,CREATE,DATE,DECIMAL,DEFAULT,DELETE,DESC,DISTINCT,DROP,ELSE,EXCLUSIVE,EXISTS,FLOAT,FOR,FROM,GRANT,GROUP,HAVING,IDENTIFIED,IN,INDEX,INSERT,INTEGER,INTERSECT,INTO,IS,LIKE,LOCK,LONG,MINUS,MODE,NOCOMPRESS,NOT,NOWAIT,NULL,NUMBER,OF,ON,OPTION,OR,ORDER,PCTFREE,PRIOR,PUBLIC,RAW,RENAME,RESOURCE,REVOKE,SELECT,SET,SHARE,SIZE,SMALLINT,START,SYNONYM,TABLE,THEN,TO,TRIGGER,UNION,UNIQUE,UPDATE,VALUES,VARCHAR,VARCHAR2,VIEW,WHERE,WITH"; }
        //}

        /// <summary>格式化关键字</summary>
        /// <param name="keyWord">表名</param>
        /// <returns></returns>
        public override String FormatKeyWord(String keyWord)
        {
            //return String.Format("\"{0}\"", keyWord);

            //if (String.IsNullOrEmpty(keyWord)) throw new ArgumentNullException("keyWord");
            if (String.IsNullOrEmpty(keyWord)) return keyWord;

            Int32 pos = keyWord.LastIndexOf(".");

            if (pos < 0) return "\"" + keyWord + "\"";

            String tn = keyWord.Substring(pos + 1);
            if (tn.StartsWith("\"")) return keyWord;

            return keyWord.Substring(0, pos + 1) + "\"" + tn + "\"";
        }
        #endregion

        #region 辅助
        Dictionary<String, DateTime> cache = new Dictionary<String, DateTime>();
        public Boolean NeedAnalyzeStatistics(String tableName)
        {
            var key = String.Format("{0}.{1}", Owner, tableName);
            DateTime dt;
            if (!cache.TryGetValue(key, out dt))
            {
                dt = DateTime.MinValue;
                cache[key] = dt;
            }

            if (dt > DateTime.Now) return false;

            // 一分钟后才可以再次分析
            dt = DateTime.Now.AddSeconds(10);
            cache[key] = dt;

            return true;
        }

        void SetDllPath(String str)
        {
            if (String.IsNullOrEmpty(str)) return;

            DllPath = str;
            var dir = DllPath;

            // 设置路径
            String ocifile = Path.Combine(dir, "oci.dll");
            if (File.Exists(ocifile))
            {
                if (DAL.Debug) DAL.WriteLog("设置OCI目录：{0}", dir);

                try
                {
                    LoadLibrary(ocifile);
                    SetDllDirectory(dir);
                }
                catch { }
            }

            if (String.IsNullOrEmpty(Environment.GetEnvironmentVariable("ORACLE_HOME")))
            {
                if (DAL.Debug) DAL.WriteLog("设置环境变量：{0}={1}", "ORACLE_HOME", OracleHome);

                Environment.SetEnvironmentVariable("ORACLE_HOME", OracleHome);
            }
        }

        static void CheckRuntime()
        {
            var dp = DllPath;
            if (!String.IsNullOrEmpty(dp))
            {
                if (DAL.Debug) DAL.WriteLog("Oracle的OCI目录：{0}", dp);
                return;
            }

            var file = "oci.dll";
            if (File.Exists(file)) return;

            DAL.WriteLog(@"已搜索当前目录、上级目录、各个盘根目录，没有找到OracleClient\OCI.dll，可能是配置不当，准备从网络下载！");

            // 尝试使用C盘目录，然后才使用上级目录
            var target = @"C:\OracleClient";
            try
            {
                if (!Directory.Exists(target)) Directory.CreateDirectory(target);
            }
            catch
            {
                try
                {
                    target = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\OracleClient"));
                    if (!Directory.Exists(target)) Directory.CreateDirectory(target);
                }
                catch
                {
                    target = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "OracleClient"));
                }
            }

            DAL.WriteLog("准备下载Oracle客户端运行时到{0}，可保存压缩包供将来直接解压使用！", target);
            CheckAndDownload("OracleClient.zip", target);

            file = Path.Combine(target, file);
            if (File.Exists(file))
            {
                LoadLibrary(file);
                SetDllDirectory(target);
            }
        }

        //[DllImport("OraOps11w.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        //static extern int CheckVersionCompatibility(string version);
        #endregion
    }

    /// <summary>Oracle数据库</summary>
    internal class OracleSession : RemoteDbSession
    {
        static OracleSession()
        {
            // 旧版Oracle运行时会因为没有这个而报错
            String name = "NLS_LANG";
            if (String.IsNullOrEmpty(Environment.GetEnvironmentVariable(name))) Environment.SetEnvironmentVariable(name, "SIMPLIFIED CHINESE_CHINA.ZHS16GBK");
        }

        #region 基本方法 查询/执行
        /// <summary>快速查询单表记录数，稍有偏差</summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public override Int64 QueryCountFast(string tableName)
        {
            if (String.IsNullOrEmpty(tableName)) return 0;

            Int32 p = tableName.LastIndexOf(".");
            if (p >= 0 && p < tableName.Length - 1) tableName = tableName.Substring(p + 1);
            tableName = tableName.ToUpper();
            var owner = (Database as Oracle).Owner.ToUpper();

            String sql = String.Format("analyze table {0}.{1}  compute statistics", owner, tableName);
            if ((Database as Oracle).NeedAnalyzeStatistics(tableName)) Execute(sql);

            sql = String.Format("select NUM_ROWS from sys.all_indexes where TABLE_OWNER='{0}' and TABLE_NAME='{1}' and UNIQUENESS='UNIQUE'", owner, tableName);
            return ExecuteScalar<Int64>(sql);
        }

        static Regex reg_SEQ = new Regex(@"\b(\w+)\.nextval\b", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        /// <summary>执行插入语句并返回新增行的自动编号</summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="type">命令类型，默认SQL文本</param>
        /// <param name="ps">命令参数</param>
        /// <returns>新增行的自动编号</returns>
        public override Int64 InsertAndGetIdentity(String sql, CommandType type = CommandType.Text, params DbParameter[] ps)
        {
            Boolean b = IsAutoClose;
            // 禁用自动关闭，保证两次在同一会话
            IsAutoClose = false;

            BeginTransaction();
            try
            {
                Int64 rs = Execute(sql, type, ps);
                if (rs > 0)
                {
                    Match m = reg_SEQ.Match(sql);
                    if (m != null && m.Success && m.Groups != null && m.Groups.Count > 0)
                        rs = ExecuteScalar<Int64>(String.Format("Select {0}.currval From dual", m.Groups[1].Value));
                }
                Commit();
                return rs;
            }
            catch { Rollback(); throw; }
            finally
            {
                IsAutoClose = b;
                AutoClose();
            }
        }
        #endregion
    }

    /// <summary>Oracle元数据</summary>
    class OracleMeta : RemoteDbMetaData
    {
        /// <summary>拥有者</summary>
        public String Owner { get { return (Database as Oracle).Owner.ToUpper(); } }

        /// <summary>是否限制只能访问拥有者的信息</summary>
        Boolean IsUseOwner { get { return Config.GetConfig<Boolean>("XCode.Oracle.IsUseOwner"); } }

        /// <summary>取得所有表构架</summary>
        /// <returns></returns>
        protected override List<IDataTable> OnGetTables(ICollection<String> names)
        {
            DataTable dt = null;

            // 采用集合过滤，提高效率
            String tableName = null;
            if (names != null && names.Count > 0) tableName = names.FirstOrDefault();
            if (String.IsNullOrEmpty(tableName))
                tableName = null;
            else
                tableName = tableName.ToUpper();

            if (IsUseOwner)
            {
                dt = GetSchema(_.Tables, new String[] { Owner, tableName });

                if (_columns == null) _columns = GetSchema(_.Columns, new String[] { Owner, tableName, null });
                if (_indexes == null) _indexes = GetSchema(_.Indexes, new String[] { Owner, null, Owner, tableName });
                if (_indexColumns == null) _indexColumns = GetSchema(_.IndexColumns, new String[] { Owner, null, Owner, tableName, null });
            }
            else
            {
                if (String.IsNullOrEmpty(tableName))
                    dt = GetSchema(_.Tables, null);
                else
                    dt = GetSchema(_.Tables, new String[] { null, tableName });
            }

            // 默认列出所有字段
            DataRow[] rows = OnGetTables(names, dt.Rows);
            if (rows == null || rows.Length < 1) return null;

            return GetTables(rows);
        }

        protected override void FixTable(IDataTable table, DataRow dr)
        {
            base.FixTable(table, dr);

            // 主键
            if (MetaDataCollections.Contains(_.PrimaryKeys))
            {
                DataTable dt = null;
                if (IsUseOwner)
                    dt = GetSchema(_.PrimaryKeys, new String[] { Owner, table.Name, null });
                else
                    dt = GetSchema(_.PrimaryKeys, new String[] { null, table.Name, null });

                if (dt != null && dt.Rows.Count > 0)
                {
                    // 找到主键所在索引，这个索引的列才是主键
                    String name = null;
                    if (TryGetDataRowValue<String>(dt.Rows[0], _.IndexName, out name) && !String.IsNullOrEmpty(name))
                    {
                        IDataIndex di = table.Indexes.FirstOrDefault(i => i.Name == name);
                        if (di != null)
                        {
                            di.PrimaryKey = true;
                            foreach (IDataColumn dc in table.Columns)
                            {
                                dc.PrimaryKey = di.Columns.Contains(dc.Name);
                            }
                        }
                    }
                }
            }

            // 表注释 USER_TAB_COMMENTS
            //String sql = String.Format("Select COMMENTS From USER_TAB_COMMENTS Where TABLE_NAME='{0}'", table.Name);
            //String comment = (String)Database.CreateSession().ExecuteScalar(sql);
            String comment = GetTableComment(table.Name);
            if (!String.IsNullOrEmpty(comment)) table.Description = comment;

            if (table == null || table.Columns == null || table.Columns.Count < 1) return;

            // 自增
            Boolean exists = false;
            foreach (IDataColumn field in table.Columns)
            {
                // 不管是否主键
                if (!Helper.IsIntType(field.DataType)) continue;

                String name = String.Format("SEQ_{0}_{1}", table.Name, field.Name);
                if (CheckSeqExists(name))
                {
                    field.Identity = true;
                    exists = true;
                    break;
                }
            }
            if (!exists)
            {
                // 检查该表是否有序列，如有，让主键成为自增
                String name = String.Format("SEQ_{0}", table.Name);
                if (CheckSeqExists(name))
                {
                    foreach (IDataColumn field in table.Columns)
                    {
                        if (!field.PrimaryKey || !Helper.IsIntType(field.DataType)) continue;

                        field.Identity = true;
                        exists = true;
                        break;
                    }
                }
            }
            if (!exists)
            {
                // 处理自增，整型、主键、名为ID认为是自增
                foreach (IDataColumn field in table.Columns)
                {
                    if (Helper.IsIntType(field.DataType))
                    {
                        if (field.PrimaryKey && field.Name.ToLower().Contains("id")) field.Identity = true;
                    }
                }
            }
        }

        /// <summary>序列</summary>
        DataTable dtSequences;
        /// <summary>检查序列是否存在</summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Boolean CheckSeqExists(String name)
        {
            if (dtSequences == null)
            {
                DataSet ds = null;
                if (IsUseOwner)
                    ds = Database.CreateSession().Query("SELECT * FROM ALL_SEQUENCES Where SEQUENCE_OWNER='" + Owner + "'");
                else
                    ds = Database.CreateSession().Query("SELECT * FROM ALL_SEQUENCES");

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                    dtSequences = ds.Tables[0];
                else
                    dtSequences = new DataTable();
            }
            if (dtSequences.Rows == null || dtSequences.Rows.Count < 1) return false;

            String where = null;
            if (IsUseOwner)
                where = String.Format("SEQUENCE_NAME='{0}' And SEQUENCE_OWNER='{1}'", name, Owner);
            else
                where = String.Format("SEQUENCE_NAME='{0}'", name);

            DataRow[] drs = dtSequences.Select(where);
            return drs != null && drs.Length > 0;

            //String sql = String.Format("SELECT Count(*) FROM ALL_SEQUENCES Where SEQUENCE_NAME='{0}' And SEQUENCE_OWNER='{1}'", name, Owner);
            //return Convert.ToInt32(Database.CreateSession().ExecuteScalar(sql)) > 0;
        }

        DataTable dtTableComment;
        String GetTableComment(String name)
        {
            if (dtTableComment == null)
            {
                DataSet ds = Database.CreateSession().Query("SELECT * FROM USER_TAB_COMMENTS");
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                    dtTableComment = ds.Tables[0];
                else
                    dtTableComment = new DataTable();
            }
            if (dtTableComment.Rows == null || dtTableComment.Rows.Count < 1) return null;

            String where = String.Format("TABLE_NAME='{0}'", name);
            DataRow[] drs = dtTableComment.Select(where);
            if (drs != null && drs.Length > 0) return Convert.ToString(drs[0]["COMMENTS"]);
            return null;

            //String sql = String.Format("Select COMMENTS From USER_TAB_COMMENTS Where TABLE_NAME='{0}'", table.Name);
            //String comment = (String)Database.CreateSession().ExecuteScalar(sql);
        }

        /// <summary>取得指定表的所有列构架</summary>
        /// <param name="table"></param>
        /// <returns></returns>
        protected override List<IDataColumn> GetFields(IDataTable table)
        {
            List<IDataColumn> list = base.GetFields(table);
            if (list == null || list.Count < 1) return null;

            // 字段注释
            if (list != null && list.Count > 0)
            {
                foreach (IDataColumn field in list)
                {
                    field.Description = GetColumnComment(table.Name, field.Name);
                }
            }

            return list;
        }

        const String KEY_OWNER = "OWNER";

        protected override List<IDataColumn> GetFields(IDataTable table, DataRow[] rows)
        {
            if (rows == null || rows.Length < 1) return null;

            if (String.IsNullOrEmpty(Owner) || !rows[0].Table.Columns.Contains(KEY_OWNER)) return base.GetFields(table, rows);

            List<DataRow> list = new List<DataRow>();
            foreach (DataRow dr in rows)
            {
                String str = null;
                if (TryGetDataRowValue<String>(dr, KEY_OWNER, out str) && Owner.EqualIgnoreCase(str)) list.Add(dr);
            }

            return base.GetFields(table, list.ToArray());
        }

        DataTable dtColumnComment;
        String GetColumnComment(String tableName, String columnName)
        {
            if (dtColumnComment == null)
            {
                DataSet ds = Database.CreateSession().Query("SELECT * FROM USER_COL_COMMENTS");
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                    dtColumnComment = ds.Tables[0];
                else
                    dtColumnComment = new DataTable();
            }
            if (dtColumnComment.Rows == null || dtColumnComment.Rows.Count < 1) return null;

            String where = String.Format("{0}='{1}' AND {2}='{3}'", _.TalbeName, tableName, _.ColumnName, columnName);
            DataRow[] drs = dtColumnComment.Select(where);
            if (drs != null && drs.Length > 0) return Convert.ToString(drs[0]["COMMENTS"]);
            return null;
        }

        protected override void FixField(IDataColumn field, DataRow drColumn, DataRow drDataType)
        {
            base.FixField(field, drColumn, drDataType);

            // 处理数字类型
            if (field.RawType.StartsWith("NUMBER"))
            {
                if (field.Scale == 0)
                {
                    // 0表示长度不限制，为了方便使用，转为最常见的Int32
                    if (field.Precision == 0)
                        field.DataType = typeof(Int32);
                    else if (field.Precision == 1)
                        field.DataType = typeof(Boolean);
                    else if (field.Precision <= 5)
                        field.DataType = typeof(Int16);
                    else if (field.Precision <= 10)
                        field.DataType = typeof(Int32);
                    else
                        field.DataType = typeof(Int64);
                }
                else
                {
                    if (field.Precision == 0)
                        field.DataType = typeof(Decimal);
                    else if (field.Precision <= 5)
                        field.DataType = typeof(Single);
                    else if (field.Precision <= 10)
                        field.DataType = typeof(Double);
                }
            }

            // 长度
            Int32 len = 0;
            if (TryGetDataRowValue<Int32>(drColumn, "LENGTHINCHARS", out len) && len > 0) field.Length = len;

            // 字节数
            len = 0;
            if (TryGetDataRowValue<Int32>(drColumn, "LENGTH", out len) && len > 0) field.NumOfByte = len;
        }

        protected override string GetFieldType(IDataColumn field)
        {
            Int32 precision = field.Precision;
            Int32 scale = field.Scale;

            switch (Type.GetTypeCode(field.DataType))
            {
                case TypeCode.Boolean:
                    return "NUMBER(1, 0)";
                case TypeCode.Int16:
                case TypeCode.UInt16:
                    if (precision <= 0) precision = 5;
                    return String.Format("NUMBER({0}, 0)", precision);
                case TypeCode.Int32:
                case TypeCode.UInt32:
                    //if (precision <= 0) precision = 10;
                    if (precision <= 0) return "NUMBER";
                    return String.Format("NUMBER({0}, 0)", precision);
                case TypeCode.Int64:
                case TypeCode.UInt64:
                    if (precision <= 0) precision = 20;
                    return String.Format("NUMBER({0}, 0)", precision);
                case TypeCode.Single:
                    if (precision <= 0) precision = 5;
                    if (scale <= 0) scale = 1;
                    return String.Format("NUMBER({0}, {1})", precision, scale);
                case TypeCode.Double:
                    if (precision <= 0) precision = 10;
                    if (scale <= 0) scale = 2;
                    return String.Format("NUMBER({0}, {1})", precision, scale);
                case TypeCode.Decimal:
                    if (precision <= 0) precision = 20;
                    if (scale <= 0) scale = 4;
                    return String.Format("NUMBER({0}, {1})", precision, scale);
                default:
                    break;
            }

            return base.GetFieldType(field);
        }

        protected override DataRow[] FindDataType(IDataColumn field, string typeName, bool? isLong)
        {
            DataRow[] drs = base.FindDataType(field, typeName, isLong);
            if (drs != null && drs.Length > 1)
            {
                // 字符串
                if (typeName == typeof(String).FullName)
                {
                    foreach (DataRow dr in drs)
                    {
                        String name = GetDataRowValue<String>(dr, "TypeName");
                        if ((name == "NVARCHAR2" && field.IsUnicode || name == "VARCHAR2" && !field.IsUnicode) && field.Length <= Database.LongTextLength)
                            return new DataRow[] { dr };
                        else if ((name == "NCLOB" && field.IsUnicode || name == "LONG" && !field.IsUnicode) && field.Length > Database.LongTextLength)
                            return new DataRow[] { dr };
                    }
                }

                //// 时间日期
                //if (typeName == typeof(DateTime).FullName)
                //{
                //    // DateTime的范围是0001到9999
                //    // Timestamp的范围是1970到2038
                //    String d = CheckAndGetDefaultDateTimeNow(field.Table.DbType, field.Default);
                //    foreach (DataRow dr in drs)
                //    {
                //        String name = GetDataRowValue<String>(dr, "TypeName");
                //        if (name == "DATETIME" && String.IsNullOrEmpty(field.Default))
                //            return new DataRow[] { dr };
                //        else if (name == "TIMESTAMP" && (d == "now()" || field.Default == "CURRENT_TIMESTAMP"))
                //            return new DataRow[] { dr };
                //    }
                //}
            }
            return drs;
        }

        protected override void FixIndex(IDataIndex index, DataRow dr)
        {
            String str = null;
            if (TryGetDataRowValue<String>(dr, "UNIQUENESS", out str))
                index.Unique = str == "UNIQUE";

            base.FixIndex(index, dr);
        }

        #region 架构定义
        public override object SetSchema(DDLSchema schema, params object[] values)
        {
            IDbSession session = Database.CreateSession();

            String dbname = String.Empty;
            String databaseName = String.Empty;
            switch (schema)
            {
                case DDLSchema.DatabaseExist:
                    // Oracle不支持判断数据库是否存在
                    return true;

                default:
                    break;
            }
            return base.SetSchema(schema, values);
        }

        public override string DatabaseExistSQL(string dbname)
        {
            return String.Empty;
        }

        protected override string GetFieldConstraints(IDataColumn field, bool onlyDefine)
        {
            // 有默认值时直接返回，待会在默认值里面加约束
            // 因为Oracle的声明是先有默认值再有约束的
            if (!String.IsNullOrEmpty(field.Default)) return null;

            //return base.GetFieldConstraints(field, onlyDefine);

            if (field.Nullable)
                return " NULL";
            else
                return " NOT NULL";
        }

        protected override string GetFieldDefault(IDataColumn field, bool onlyDefine)
        {
            if (String.IsNullOrEmpty(field.Default)) return null;

            return base.GetFieldDefault(field, onlyDefine) + base.GetFieldConstraints(field, onlyDefine);
        }

        public override string CreateTableSQL(IDataTable table)
        {
            List<IDataColumn> Fields = new List<IDataColumn>(table.Columns);
            Fields.OrderBy(dc => dc.ID);

            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Create Table {0}(", FormatName(table.Name));
            for (Int32 i = 0; i < Fields.Count; i++)
            {
                sb.AppendLine();
                sb.Append("\t");
                sb.Append(FieldClause(Fields[i], true));
                if (i < Fields.Count - 1) sb.Append(",");
            }

            // 主键
            if (table.PrimaryKeys != null && table.PrimaryKeys.Length > 0)
            {
                sb.AppendLine(",");
                sb.Append("\t");
                sb.AppendFormat("constraint pk_{0} primary key (", table.Name);
                for (int i = 0; i < table.PrimaryKeys.Length; i++)
                {
                    if (i > 0) sb.Append(",");
                    sb.Append(FormatName(table.PrimaryKeys[i].Name));
                }
                sb.Append(")");
            }

            sb.AppendLine();
            sb.Append(")");

            String sql = sb.ToString();
            if (String.IsNullOrEmpty(sql)) return sql;

            // 感谢@晴天（412684802）和@老徐（gregorius 279504479），这里的最小和开始必须是0，插入的时候有++i的效果，才会得到从1开始的编号
            String sqlSeq = String.Format("Create Sequence SEQ_{0} Minvalue 0 Maxvalue 9999999999 Start With 0 Increment By 1 Cache 20", table.Name);
            //return sql + "; " + Environment.NewLine + sqlSeq;
            // 去掉分号后的空格，Oracle不支持同时执行多个语句
            return sql + ";" + Environment.NewLine + sqlSeq;
        }

        public override string DropTableSQL(String tableName)
        {
            String sql = base.DropTableSQL(tableName);
            if (String.IsNullOrEmpty(sql)) return sql;

            String sqlSeq = String.Format("Drop Sequence SEQ_{0}", tableName);
            return sql + "; " + Environment.NewLine + sqlSeq;
        }

        public override String AddColumnSQL(IDataColumn field)
        {
            if (String.IsNullOrEmpty(Owner))
                return String.Format("Alter Table {0} Add {1}", FormatName(field.Table.Name), FieldClause(field, true));
            else
                return String.Format("Alter Table {2}.{0} Add {1}", FormatName(field.Table.Name), FieldClause(field, true), Owner);
        }

        public override String AlterColumnSQL(IDataColumn field, IDataColumn oldfield)
        {
            if (String.IsNullOrEmpty(Owner))
                return String.Format("Alter Table {0} Modify {1}", FormatName(field.Table.Name), FieldClause(field, false));
            else
                return String.Format("Alter Table {2}.{0} Modify {1}", FormatName(field.Table.Name), FieldClause(field, false), Owner);
        }

        public override String DropColumnSQL(IDataColumn field)
        {
            if (String.IsNullOrEmpty(Owner))
                return String.Format("Alter Table {0} Drop Column {1}", FormatName(field.Table.Name), field.Name);
            else
                return String.Format("Alter Table {2}.{0} Drop Column {1}", FormatName(field.Table.Name), field.Name, Owner);
        }

        public override string AddTableDescriptionSQL(IDataTable table)
        {
            //return String.Format("Update USER_TAB_COMMENTS Set COMMENTS='{0}' Where TABLE_NAME='{1}'", table.Description, table.Name);

            return String.Format("Comment On Table {0} is '{1}'", FormatName(table.Name), table.Description);
        }

        public override string DropTableDescriptionSQL(IDataTable table)
        {
            //return String.Format("Update USER_TAB_COMMENTS Set COMMENTS='' Where TABLE_NAME='{0}'", table.Name);

            return String.Format("Comment On Table {0} is ''", FormatName(table.Name));
        }

        public override string AddColumnDescriptionSQL(IDataColumn field)
        {
            //return String.Format("Update USER_COL_COMMENTS Set COMMENTS='{0}' Where TABLE_NAME='{1}' AND COLUMN_NAME='{2}'", field.Description, field.Table.Name, field.Name);

            return String.Format("Comment On Column {0}.{1} is '{2}'", FormatName(field.Table.Name), FormatName(field.Name), field.Description);
        }

        public override string DropColumnDescriptionSQL(IDataColumn field)
        {
            //return String.Format("Update USER_COL_COMMENTS Set COMMENTS='' Where TABLE_NAME='{0}' AND COLUMN_NAME='{1}'", field.Table.Name, field.Name);

            return String.Format("Comment On Column {0}.{1} is ''", FormatName(field.Table.Name), FormatName(field.Name));
        }
        #endregion
    }
}