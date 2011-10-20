using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text.RegularExpressions;
using XCode.Common;
using XCode.Exceptions;
using NewLife;
using System.Linq;

namespace XCode.DataAccessLayer
{
    class Oracle : RemoteDb
    {
        #region ����
        /// <summary>
        /// �������ݿ����͡��ⲿDAL���ݿ�����ʹ��Other
        /// </summary>
        public override DatabaseType DbType
        {
            get { return DatabaseType.Oracle; }
        }

        private static DbProviderFactory _dbProviderFactory;
        /// <summary>
        /// �ṩ�߹���
        /// </summary>
        static DbProviderFactory dbProviderFactory
        {
            get
            {
                // ���ȳ���ʹ��Oracle.DataAccess
                if (_dbProviderFactory == null)
                {
                    lock (typeof(Oracle))
                    {
                        if (_dbProviderFactory == null)
                        {
                            try
                            {
                                _dbProviderFactory = GetProviderFactory("Oracle.DataAccess.dll", "Oracle.DataAccess.Client.OracleClientFactory");
                            }
                            catch (FileNotFoundException) { }
                            catch (Exception ex)
                            {
                                if (DAL.Debug) DAL.WriteLog(ex.ToString());
                            }
                        }

                        // �������ַ�ʽ�����Լ��أ�ǰ����ֻ��Ϊ�˼��ٶԳ��򼯵����ã��ڶ�����Ϊ�˱����һ����û��ע��
                        if (_dbProviderFactory == null) _dbProviderFactory = DbProviderFactories.GetFactory("System.Data.OracleClient");
                        if (_dbProviderFactory == null) _dbProviderFactory = GetProviderFactory("System.Data.OracleClient.dll", "System.Data.OracleClient.OracleClientFactory");
                        //if (_dbProviderFactory == null) _dbProviderFactory = OracleClientFactory.Instance;
                    }
                }

                return _dbProviderFactory;
            }
        }

        /// <summary>����</summary>
        public override DbProviderFactory Factory
        {
            //get { return OracleClientFactory.Instance; }
            get { return dbProviderFactory; }
        }

        private String _UserID;
        /// <summary>
        /// �û���UserID
        /// </summary>
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

        /// <summary>ӵ����</summary>
        public override String Owner
        {
            get
            {
                // ����null��Empty���������ж��Ƿ��Ѽ���
                if (base.Owner == null)
                {
                    base.Owner = UserID;
                    if (String.IsNullOrEmpty(base.Owner)) base.Owner = String.Empty;
                }
                return base.Owner;
            }
            set { base.Owner = value; }
        }
        #endregion

        #region ����
        /// <summary>
        /// �������ݿ�Ự
        /// </summary>
        /// <returns></returns>
        protected override IDbSession OnCreateSession()
        {
            return new OracleSession();
        }

        /// <summary>
        /// ����Ԫ���ݶ���
        /// </summary>
        /// <returns></returns>
        protected override IMetaData OnCreateMetaData()
        {
            return new OracleMeta();
        }
        #endregion

        #region ��ҳ
        /// <summary>
        /// ����д����ȡ��ҳ
        /// </summary>
        /// <param name="sql">SQL���</param>
        /// <param name="startRowIndex">��ʼ�У�0��ʾ��һ��</param>
        /// <param name="maximumRows">��󷵻�������0��ʾ������</param>
        /// <param name="keyColumn">�����С�����not in��ҳ</param>
        /// <returns></returns>
        public override String PageSplit(String sql, Int32 startRowIndex, Int32 maximumRows, String keyColumn)
        {
            // �ӵ�һ�п�ʼ������Ҫ��ҳ
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

        #region ���ݿ�����
        /// <summary>
        /// ��ǰʱ�亯��
        /// </summary>
        public override string DateTimeNow { get { return "sysdate"; } }

        /// <summary>
        /// �����ء���ʽ��ʱ��
        /// </summary>
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

        /// <summary>
        /// ��ʽ����ʶ�У����ز�������ʱ���õı��ʽ������ֶα���֧���������򷵻ؿ�
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override string FormatIdentity(IDataColumn field, Object value)
        {
            return String.Format("SEQ_{0}.nextval", field.Table.Name);
        }
        #endregion

        #region �ؼ���
        //protected override string ReservedWordsStr
        //{
        //    get { return "ALL,ALTER,AND,ANY,AS,ASC,BETWEEN,BY,CHAR,CHECK,CLUSTER,COMPRESS,CONNECT,CREATE,DATE,DECIMAL,DEFAULT,DELETE,DESC,DISTINCT,DROP,ELSE,EXCLUSIVE,EXISTS,FLOAT,FOR,FROM,GRANT,GROUP,HAVING,IDENTIFIED,IN,INDEX,INSERT,INTEGER,INTERSECT,INTO,IS,LIKE,LOCK,LONG,MINUS,MODE,NOCOMPRESS,NOT,NOWAIT,NULL,NUMBER,OF,ON,OPTION,OR,ORDER,PCTFREE,PRIOR,PUBLIC,RAW,RENAME,RESOURCE,REVOKE,SELECT,SET,SHARE,SIZE,SMALLINT,START,SYNONYM,TABLE,THEN,TO,TRIGGER,UNION,UNIQUE,UPDATE,VALUES,VARCHAR,VARCHAR2,VIEW,WHERE,WITH"; }
        //}

        /// <summary>
        /// ��ʽ���ؼ���
        /// </summary>
        /// <param name="keyWord">����</param>
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
    }

    /// <summary>
    /// Oracle���ݿ�
    /// </summary>
    internal class OracleSession : RemoteDbSession
    {
        #region �������� ��ѯ/ִ��
        /// <summary>
        /// ���ٲ�ѯ�����¼��������ƫ��
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public override Int64 QueryCountFast(string tableName)
        {
            String sql = String.Format("select NUM_ROWS from sys.all_indexes where TABLE_OWNER='{0}' and TABLE_NAME='{1}'", (Database as Oracle).Owner.ToUpper(), tableName);
            return ExecuteScalar<Int64>(sql);

            //QueryTimes++;
            //DbCommand cmd = CreateCommand();
            //cmd.CommandText = sql;
            //WriteSQL(cmd.CommandText);
            //try
            //{
            //    return Convert.ToInt64(cmd.ExecuteScalar());
            //}
            //catch (DbException ex)
            //{
            //    throw OnException(ex, cmd.CommandText);
            //}
            //finally { AutoClose(); }
        }

        static Regex reg_SEQ = new Regex(@"\b(\w+)\.nextval\b", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        /// <summary>
        /// ִ�в�����䲢���������е��Զ����
        /// </summary>
        /// <param name="sql">SQL���</param>
        /// <returns>�����е��Զ����</returns>
        public override Int64 InsertAndGetIdentity(String sql)
        {
            Boolean b = IsAutoClose;
            // �����Զ��رգ���֤������ͬһ�Ự
            IsAutoClose = false;

            BeginTransaction();
            try
            {
                Int64 rs = base.InsertAndGetIdentity(sql);
                if (rs > 0)
                {
                    Match m = reg_SEQ.Match(sql);
                    if (m != null && m.Groups != null && m.Groups.Count > 0)
                        rs = ExecuteScalar<Int64>(String.Format("Select {0}.currval", m.Groups[1].Value));
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

    /// <summary>
    /// OracleԪ����
    /// </summary>
    class OracleMeta : RemoteDbMetaData
    {
        /// <summary>ӵ����</summary>
        public String Owner { get { return (Database as Oracle).Owner.ToUpper(); } }

        /// <summary>
        /// ȡ�����б���
        /// </summary>
        /// <returns></returns>
        protected override List<IDataTable> OnGetTables()
        {
            try
            {
                //- ��Ҫ�գ���������úܲң��б��������ݱ�ʵ��̫����
                //if (String.Equals(user, "system")) user = null;

                DataTable dt = GetSchema(_.Tables, new String[] { Owner });

                // Ĭ���г������ֶ�
                DataRow[] rows = new DataRow[dt.Rows.Count];
                dt.Rows.CopyTo(rows, 0);
                return GetTables(rows);

            }
            catch (DbException ex)
            {
                throw new XDbMetaDataException(this, "ȡ�����б��ܳ���", ex);
            }
        }

        protected override void FixTable(IDataTable table, DataRow dr)
        {
            base.FixTable(table, dr);

            // ��ע�� USER_TAB_COMMENTS
            //String sql = String.Format("Select COMMENTS From USER_TAB_COMMENTS Where TABLE_NAME='{0}'", table.Name);
            //String comment = (String)Database.CreateSession().ExecuteScalar(sql);
            String comment = GetTableComment(table.Name);
            if (!String.IsNullOrEmpty(comment)) table.Description = comment;

            if (table == null || table.Columns == null || table.Columns.Count < 1) return;

            // ����
            Boolean exists = false;
            foreach (IDataColumn field in table.Columns)
            {
                // �����Ƿ�����
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
                // ���ñ��Ƿ������У����У���������Ϊ����
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
                // �������������͡���������ΪID��Ϊ������
                foreach (IDataColumn field in table.Columns)
                {
                    if (Helper.IsIntType(field.DataType))
                    {
                        if (field.PrimaryKey && field.Name.ToLower().Contains("id")) field.Identity = true;
                    }
                }
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        DataTable dtSequences;
        /// <summary>
        /// ��������Ƿ����
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Boolean CheckSeqExists(String name)
        {
            if (dtSequences == null)
            {
                DataSet ds = Database.CreateSession().Query("SELECT * FROM ALL_SEQUENCES Where SEQUENCE_OWNER='" + Owner + "'");
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                    dtSequences = ds.Tables[0];
                else
                    dtSequences = new DataTable();
            }
            if (dtSequences.Rows == null || dtSequences.Rows.Count < 1) return false;

            String where = String.Format("SEQUENCE_NAME='{0}' And SEQUENCE_OWNER='{1}'", name, Owner);
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

        /// <summary>
        /// ȡ��ָ����������й���
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        protected override List<IDataColumn> GetFields(IDataTable table)
        {
            List<IDataColumn> list = base.GetFields(table);
            if (list == null || list.Count < 1) return null;

            // �ֶ�ע��
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

            // ������������
            if (field.RawType.StartsWith("NUMBER"))
            {
                if (field.Scale == 0)
                {
                    // 0��ʾ���Ȳ����ƣ�Ϊ�˷���ʹ�ã�תΪ�����Int32
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
                // �ַ���
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

                //// ʱ������
                //if (typeName == typeof(DateTime).FullName)
                //{
                //    // DateTime�ķ�Χ��0001��9999
                //    // Timestamp�ķ�Χ��1970��2038
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

        #region �ܹ�����
        protected override string GetFieldConstraints(IDataColumn field, bool onlyDefine)
        {
            // ��Ĭ��ֵʱֱ�ӷ��أ�������Ĭ��ֵ�����Լ��
            // ��ΪOracle������������Ĭ��ֵ����Լ����
            if (!String.IsNullOrEmpty(field.Default)) return null;

            return base.GetFieldConstraints(field, onlyDefine);
        }

        protected override string GetFieldDefault(IDataColumn field, bool onlyDefine)
        {
            if (String.IsNullOrEmpty(field.Default)) return null;

            return base.GetFieldDefault(field, onlyDefine) + base.GetFieldConstraints(field, onlyDefine);
        }

        public override string CreateTableSQL(IDataTable table)
        {
            String sql = base.CreateTableSQL(table);
            if (String.IsNullOrEmpty(sql)) return sql;

            String sqlSeq = String.Format("Create Sequence SEQ_{0} Minvalue 1 Maxvalue 9999999999 Start With 1 Increment By 1 Cache 20", table.Name);
            return sql + "; " + Environment.NewLine + sqlSeq;
        }

        public override string DropTableSQL(String tableName)
        {
            String sql = base.DropTableSQL(tableName);
            if (String.IsNullOrEmpty(sql)) return sql;

            String sqlSeq = String.Format("Drop Sequence SEQ_{0}", tableName);
            return sql + "; " + Environment.NewLine + sqlSeq;
        }

        public override String AlterColumnSQL(IDataColumn field, IDataColumn oldfield)
        {
            return String.Format("Alter Table {0} Modify Column {1}", FormatName(field.Table.Name), FieldClause(field, false));
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