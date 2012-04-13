using System;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NewLife;
using NewLife.Log;
using XCode.Exceptions;

namespace XCode.DataAccessLayer
{
    /// <summary>���ݿ�Ự����</summary>
    abstract partial class DbSession : DisposeBase, IDbSession
    {
        #region ���캯��
        /// <summary>������Դʱ���ع�δ�ύ���񣬲��ر����ݿ�����</summary>
        /// <param name="disposing"></param>
        protected override void OnDispose(bool disposing)
        {
            base.OnDispose(disposing);

            try
            {
                // ע�⣬û��Commit�����ݣ������ｫ�ᱻ�ع�
                //if (Trans != null) Rollback();
                // ��Ƕ�������У�Rollbackֻ�ܼ���Ƕ�ײ�������_Trans.Rollback�����������ϻع�
                if (_Trans != null && Opened) _Trans.Rollback();
                if (_Conn != null) Close();
            }
            catch (ObjectDisposedException) { }
            catch (Exception ex)
            {
                WriteLog("ִ��" + DbType.ToString() + "��Disposeʱ����" + ex.ToString());
            }
        }
        #endregion

        #region ����
        private IDatabase _Database;
        /// <summary>���ݿ�</summary>
        public IDatabase Database { get { return _Database; } set { _Database = value; } }

        /// <summary>�������ݿ����͡��ⲿDAL���ݿ�����ʹ��Other</summary>
        private DatabaseType DbType { get { return Database.DbType; } }

        /// <summary>����</summary>
        private DbProviderFactory Factory { get { return Database.Factory; } }

        private String _ConnectionString;
        /// <summary>�����ַ������Ự�������棬�����޸ģ��޸Ĳ���Ӱ�����ݿ��е������ַ���</summary>
        public String ConnectionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value; }
        }

        private DbConnection _Conn;
        /// <summary>�������Ӷ���</summary>
        public DbConnection Conn
        {
            get
            {
                if (_Conn == null)
                {
                    _Conn = Factory.CreateConnection();
                    //_Conn.ConnectionString = Database.ConnectionString;
                    _Conn.ConnectionString = ConnectionString;
                }
                return _Conn;
            }
            //set { _Conn = value; }
        }

        private Int32 _QueryTimes;
        /// <summary>��ѯ����</summary>
        public Int32 QueryTimes
        {
            get { return _QueryTimes; }
            set { _QueryTimes = value; }
        }

        private Int32 _ExecuteTimes;
        /// <summary>ִ�д���</summary>
        public Int32 ExecuteTimes
        {
            get { return _ExecuteTimes; }
            set { _ExecuteTimes = value; }
        }

        private Int32 _ThreadID = Thread.CurrentThread.ManagedThreadId;
        /// <summary>�̱߳�ţ�ÿ�����ݿ�ỰӦ��ֻ����һ���̣߳����������ڼ�����Ŀ��̲߳���</summary>
        public Int32 ThreadID
        {
            get { return _ThreadID; }
            set { _ThreadID = value; }
        }
        #endregion

        #region ��/�ر�
        private Boolean _IsAutoClose = true;
        /// <summary>
        /// �Ƿ��Զ��رա�
        /// ��������󣬸�������Ч��
        /// ���ύ��ع�����ʱ�����IsAutoCloseΪtrue������Զ��ر�
        /// </summary>
        public Boolean IsAutoClose
        {
            get { return _IsAutoClose; }
            set { _IsAutoClose = value; }
        }

        /// <summary>�����Ƿ��Ѿ���</summary>
        public Boolean Opened
        {
            get { return _Conn != null && _Conn.State != ConnectionState.Closed; }
        }

        /// <summary>��</summary>
        public virtual void Open()
        {
            if (DAL.Debug && ThreadID != Thread.CurrentThread.ManagedThreadId) DAL.WriteLog("���Ự���߳�{0}��������ǰ�߳�{1}�Ƿ�ʹ�øûỰ��");

            if (Conn != null && Conn.State == ConnectionState.Closed) Conn.Open();
        }

        /// <summary>�ر�</summary>
        public virtual void Close()
        {
            if (_Conn != null && Conn.State != ConnectionState.Closed)
            {
                try { Conn.Close(); }
                catch (Exception ex)
                {
                    WriteLog("ִ��" + DbType.ToString() + "��Closeʱ����" + ex.ToString());
                }
            }
        }

        /// <summary>
        /// �Զ��رա�
        /// ��������󣬲��ر����ӡ�
        /// ���ύ��ع�����ʱ�����IsAutoCloseΪtrue������Զ��ر�
        /// </summary>
        public void AutoClose()
        {
            if (IsAutoClose && Trans == null && Opened) Close();
        }

        /// <summary>���ݿ���</summary>
        public String DatabaseName
        {
            get
            {
                return Conn == null ? null : Conn.Database;
            }
            set
            {
                if (Opened)
                {
                    //����Ѵ򿪣�������������л�
                    Conn.ChangeDatabase(value);
                }
                else
                {
                    //DAL.WriteDebugLog("{0}=>{1}", Conn.Database, value);
                    ////XTrace.DebugStack(3);

                    //���û�д򿪣���ı������ַ���
                    DbConnectionStringBuilder builder = new DbConnectionStringBuilder();
                    builder.ConnectionString = ConnectionString;
                    if (builder.ContainsKey("Database"))
                    {
                        builder["Database"] = value;
                        ConnectionString = builder.ToString();
                        Conn.ConnectionString = ConnectionString;
                    }
                    else if (builder.ContainsKey("Initial Catalog"))
                    {
                        builder["Initial Catalog"] = value;
                        ConnectionString = builder.ToString();
                        Conn.ConnectionString = ConnectionString;
                    }
                }
            }
        }

        /// <summary>���쳣����ʱ�������ر����ݿ����ӣ����߷������ӵ����ӳء�</summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        protected virtual XDbException OnException(Exception ex)
        {
            if (Trans == null && Opened) Close(); // ǿ�ƹر����ݿ�
            if (ex != null)
                return new XDbSessionException(this, ex);
            else
                return new XDbSessionException(this);
        }

        /// <summary>���쳣����ʱ�������ر����ݿ����ӣ����߷������ӵ����ӳء�</summary>
        /// <param name="ex"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        protected virtual XSqlException OnException(Exception ex, String sql)
        {
            if (Trans == null && Opened) Close(); // ǿ�ƹر����ݿ�
            if (ex != null)
                return new XSqlException(sql, this, ex);
            else
                return new XSqlException(sql, this);
        }
        #endregion

        #region ����
        private DbTransaction _Trans;
        /// <summary>���ݿ�����</summary>
        protected DbTransaction Trans
        {
            get { return _Trans; }
            set { _Trans = value; }
        }

        /// <summary>
        /// ���������
        /// ���ҽ��������������1ʱ�����ύ��ع���
        /// </summary>
        private Int32 TransactionCount = 0;

        /// <summary>��ʼ����</summary>
        /// <returns></returns>
        public Int32 BeginTransaction()
        {
            TransactionCount++;
            if (TransactionCount > 1) return TransactionCount;

            try
            {
                if (!Opened) Open();
                Trans = Conn.BeginTransaction();
                TransactionCount = 1;
                return TransactionCount;
            }
            catch (DbException ex)
            {
                throw OnException(ex);
            }
        }

        /// <summary>�ύ����</summary>
        public Int32 Commit()
        {
            TransactionCount--;
            if (TransactionCount > 0) return TransactionCount;

            if (Trans == null) throw new XDbSessionException(this, "��ǰ��δ��ʼ��������BeginTransaction������ʼ������");
            try
            {
                Trans.Commit();
                Trans = null;
                if (IsAutoClose) Close();
            }
            catch (DbException ex)
            {
                throw OnException(ex);
            }

            return TransactionCount;
        }

        /// <summary>�ع�����</summary>
        public Int32 Rollback()
        {
            // ����ҪС�ģ��ڶ�������У�����ڲ�ع�����������ύ�����ڲ�Ļع������ύ
            TransactionCount--;
            if (TransactionCount > 0) return TransactionCount;

            if (Trans == null) throw new XDbSessionException(this, "��ǰ��δ��ʼ��������BeginTransaction������ʼ������");
            try
            {
                Trans.Rollback();
                Trans = null;
                if (IsAutoClose) Close();
            }
            catch (DbException ex)
            {
                throw OnException(ex);
            }

            return TransactionCount;
        }
        #endregion

        #region �������� ��ѯ/ִ��
        /// <summary>ִ��SQL��ѯ�����ؼ�¼��</summary>
        /// <param name="sql">SQL���</param>
        /// <param name="type">�������ͣ�Ĭ��SQL�ı�</param>
        /// <param name="ps">�������</param>
        /// <returns></returns>
        public virtual DataSet Query(String sql, CommandType type = CommandType.Text, params DbParameter[] ps)
        {
            return Query(CreateCommand(sql, type, ps));

            //QueryTimes++;
            //WriteSQL(sql, ps);
            //try
            //{
            //    DbCommand cmd = CreateCommand(sql, type, ps);
            //    using (DbDataAdapter da = Factory.CreateDataAdapter())
            //    {
            //        da.SelectCommand = cmd;
            //        DataSet ds = new DataSet();
            //        da.Fill(ds);
            //        return ds;
            //    }
            //}
            //catch (DbException ex)
            //{
            //    throw OnException(ex, sql);
            //}
            //finally
            //{
            //    AutoClose();
            //}
        }

        ///// <summary>
        ///// ִ��SQL��ѯ�����ؼ�¼��
        ///// </summary>
        ///// <param name="builder">��ѯ������</param>
        ///// <param name="startRowIndex">��ʼ�У�0��ʾ��һ��</param>
        ///// <param name="maximumRows">��󷵻�������0��ʾ������</param>
        ///// <returns>��¼��</returns>
        //public virtual DataSet Query(SelectBuilder builder, Int32 startRowIndex, Int32 maximumRows)
        //{
        //    return Query(Database.PageSplit(builder, startRowIndex, maximumRows).ToString(), CommandType.Text, builder.Parameters.ToArray());
        //}

        /// <summary>ִ��DbCommand�����ؼ�¼��</summary>
        /// <param name="cmd">DbCommand</param>
        /// <returns></returns>
        public virtual DataSet Query(DbCommand cmd)
        {
            QueryTimes++;
            WriteSQL(cmd);
            using (DbDataAdapter da = Factory.CreateDataAdapter())
            {
                try
                {
                    if (!Opened) Open();
                    cmd.Connection = Conn;
                    if (Trans != null) cmd.Transaction = Trans;
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
                catch (DbException ex)
                {
                    throw OnException(ex, cmd.CommandText);
                }
                finally
                {
                    AutoClose();
                }
            }
        }

        private static Regex reg_QueryCount = new Regex(@"^\s*select\s+\*\s+from\s+([\w\W]+)\s*$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        /// <summary>ִ��SQL��ѯ�������ܼ�¼��</summary>
        /// <param name="sql">SQL���</param>
        /// <param name="type">�������ͣ�Ĭ��SQL�ı�</param>
        /// <param name="ps">�������</param>
        /// <returns></returns>
        public virtual Int64 QueryCount(String sql, CommandType type = CommandType.Text, params DbParameter[] ps)
        {
            if (sql.Contains(" "))
            {
                String orderBy = DbBase.CheckOrderClause(ref sql);
                //sql = String.Format("Select Count(*) From {0}", CheckSimpleSQL(sql));
                //Match m = reg_QueryCount.Match(sql);
                MatchCollection ms = reg_QueryCount.Matches(sql);
                if (ms != null && ms.Count > 0)
                {
                    sql = String.Format("Select Count(*) From {0}", ms[0].Groups[1].Value);
                }
                else
                {
                    sql = String.Format("Select Count(*) From {0}", DbBase.CheckSimpleSQL(sql));
                }
            }
            else
                sql = String.Format("Select Count(*) From {0}", Database.FormatName(sql));

            //return QueryCountInternal(sql);
            return ExecuteScalar<Int64>(sql, type, ps);
        }

        /// <summary>ִ��SQL��ѯ�������ܼ�¼��</summary>
        /// <param name="builder">��ѯ������</param>
        /// <returns>�ܼ�¼��</returns>
        public virtual Int64 QueryCount(SelectBuilder builder)
        {
            return ExecuteScalar<Int64>(builder.SelectCount().ToString(), CommandType.Text, builder.Parameters.ToArray());
        }

        /// <summary>���ٲ�ѯ�����¼��������ƫ��</summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public virtual Int64 QueryCountFast(String tableName) { return QueryCount(tableName); }

        /// <summary>ִ��SQL��䣬������Ӱ�������</summary>
        /// <param name="sql">SQL���</param>
        /// <param name="type">�������ͣ�Ĭ��SQL�ı�</param>
        /// <param name="ps">�������</param>
        /// <returns></returns>
        public virtual Int32 Execute(String sql, CommandType type = CommandType.Text, params DbParameter[] ps)
        {
            return Execute(CreateCommand(sql, type, ps));

            //ExecuteTimes++;
            //WriteSQL(sql, ps);
            //try
            //{
            //    DbCommand cmd = CreateCommand();
            //    cmd.CommandType = type;
            //    cmd.CommandText = sql;
            //    if (ps != null && ps.Length > 0) cmd.Parameters.AddRange(ps);
            //    return cmd.ExecuteNonQuery();
            //}
            //catch (DbException ex)
            //{
            //    throw OnException(ex, sql);
            //}
            //finally { AutoClose(); }
        }

        /// <summary>ִ��DbCommand��������Ӱ�������</summary>
        /// <param name="cmd">DbCommand</param>
        /// <returns></returns>
        public virtual Int32 Execute(DbCommand cmd)
        {
            ExecuteTimes++;
            WriteSQL(cmd);
            try
            {
                if (!Opened) Open();
                cmd.Connection = Conn;
                if (Trans != null) cmd.Transaction = Trans;
                return cmd.ExecuteNonQuery();
            }
            catch (DbException ex)
            {
                throw OnException(ex, cmd.CommandText);
            }
            finally { AutoClose(); }
        }

        /// <summary>ִ�в�����䲢���������е��Զ����</summary>
        /// <param name="sql">SQL���</param>
        /// <param name="type">�������ͣ�Ĭ��SQL�ı�</param>
        /// <param name="ps">�������</param>
        /// <returns>�����е��Զ����</returns>
        public virtual Int64 InsertAndGetIdentity(String sql, CommandType type = CommandType.Text, params DbParameter[] ps)
        {
            return Execute(sql, type, ps);
        }

        /// <summary>ִ��SQL��䣬���ؽ���еĵ�һ�е�һ��</summary>
        /// <typeparam name="T">��������</typeparam>
        /// <param name="sql">SQL���</param>
        /// <param name="type">�������ͣ�Ĭ��SQL�ı�</param>
        /// <param name="ps">�������</param>
        /// <returns></returns>
        public virtual T ExecuteScalar<T>(String sql, CommandType type = CommandType.Text, params DbParameter[] ps)
        {
            return ExecuteScalar<T>(CreateCommand(sql, type, ps));
        }

        protected virtual T ExecuteScalar<T>(DbCommand cmd)
        {
            QueryTimes++;

            WriteSQL(cmd);
            try
            {
                Object rs = cmd.ExecuteScalar();
                if (rs == null || rs == DBNull.Value) return default(T);
                if (rs is T) return (T)rs;
                return (T)Convert.ChangeType(rs, typeof(T));
            }
            catch (DbException ex)
            {
                throw OnException(ex, cmd.CommandText);
            }
            finally
            {
                AutoClose();
            }
        }

        /// <summary>
        /// ��ȡһ��DbCommand��
        /// ���������ӣ�������������
        /// �����Ѵ򿪡�
        /// ʹ����Ϻ󣬱������AutoClose��������ʹ���ڷ������������Զ��رյ�����¹ر�����
        /// </summary>
        /// <returns></returns>
        public virtual DbCommand CreateCommand()
        {
            var cmd = Factory.CreateCommand();
            if (!Opened) Open();
            cmd.Connection = Conn;
            if (Trans != null) cmd.Transaction = Trans;

            return cmd;
        }

        /// <summary>
        /// ��ȡһ��DbCommand��
        /// ���������ӣ�������������
        /// �����Ѵ򿪡�
        /// ʹ����Ϻ󣬱������AutoClose��������ʹ���ڷ������������Զ��رյ�����¹ر�����
        /// </summary>
        /// <param name="sql">SQL���</param>
        /// <param name="type">�������ͣ�Ĭ��SQL�ı�</param>
        /// <param name="ps">�������</param>
        /// <returns></returns>
        public virtual DbCommand CreateCommand(String sql, CommandType type = CommandType.Text, params DbParameter[] ps)
        {
            var cmd = CreateCommand();

            cmd.CommandType = type;
            cmd.CommandText = sql;
            if (ps != null && ps.Length > 0) cmd.Parameters.AddRange(ps);

            return cmd;
        }
        #endregion

        #region �ܹ�
        /// <summary>��������Դ�ļܹ���Ϣ</summary>
        /// <param name="collectionName">ָ��Ҫ���صļܹ������ơ�</param>
        /// <param name="restrictionValues">Ϊ����ļܹ�ָ��һ������ֵ��</param>
        /// <returns></returns>
        public virtual DataTable GetSchema(string collectionName, string[] restrictionValues)
        {
            QueryTimes++;
            if (!Opened) Open();

            DbConnection conn = Conn;
            try
            {
                // ������������񱣻�������Ҫ�¿�һ�����ӣ�����MSSQL���汨��SQLite�������������ݿ�δ����
                if (TransactionCount > 0)
                {
                    conn = Factory.CreateConnection();
                    conn.ConnectionString = ConnectionString;
                    conn.Open();
                }

                DataTable dt;

                if (restrictionValues == null || restrictionValues.Length < 1)
                {
                    if (String.IsNullOrEmpty(collectionName))
                    {
                        WriteSQL("GetSchema");
                        dt = conn.GetSchema();
                    }
                    else
                    {
                        WriteSQL("GetSchema(\"" + collectionName + "\")");
                        dt = conn.GetSchema(collectionName);
                    }
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (String item in restrictionValues)
                    {
                        sb.Append(", ");
                        if (item == null)
                            sb.Append("null");
                        else
                            sb.AppendFormat("\"{0}\"", item);
                    }
                    WriteSQL("GetSchema(\"" + collectionName + "\"" + sb + ")");
                    dt = conn.GetSchema(collectionName, restrictionValues);
                }

                return dt;
            }
            catch (DbException ex)
            {
                throw new XDbSessionException(this, "ȡ�����б��ܳ���", ex);
            }
            finally
            {
                AutoClose();
                if (conn != Conn) conn.Close();
            }
        }
        #endregion

        #region Sql��־���
        [ThreadStatic]
        private static Boolean? _ShowSQL;
        /// <summary>�Ƿ����SQL��䣬Ĭ��ΪXCode���Կ���XCode.Debug</summary>
        public static Boolean ShowSQL
        {
            get
            {
                if (_ShowSQL == null) return DAL.ShowSQL;
                return _ShowSQL.Value;
            }
            set { _ShowSQL = value; }
        }

        static TextFileLog logger;

        /// <summary>д��SQL���ı���</summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        public static void WriteSQL(String sql, params DbParameter[] ps)
        {
            if (!ShowSQL) return;

            if (ps != null && ps.Length > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(sql);
                sb.Append("[");
                for (int i = 0; i < ps.Length; i++)
                {
                    if (i > 0) sb.Append(", ");
                    var v = ps[i].Value;
                    var sv = "";
                    if (v is Byte[])
                    {
                        var bv = v as Byte[];
                        if (bv.Length > 8)
                            sv = String.Format("[{0}]0x{1}...", bv.Length, BitConverter.ToString(bv, 0, 8));
                        else
                            sv = String.Format("[{0}]0x{1}", bv.Length, BitConverter.ToString(bv));
                    }
                    else if (v is String)
                    {
                        sv = v as String;
                        if (sv.Length > 8) sv = String.Format("[{0}]{1}...", sv.Length, sv.Substring(0, 8));
                    }
                    else
                        sv = "" + v;
                    sb.AppendFormat("{1}:{0}={2}", ps[i].ParameterName, ps[i].DbType, sv);
                }
                sb.Append("]");
                sql = sb.ToString();
            }

            if (String.IsNullOrEmpty(DAL.SQLPath))
                WriteLog(sql);
            else
            {
                if (logger == null) logger = TextFileLog.Create(DAL.SQLPath);
                logger.WriteLine(sql);
            }
        }

        public static void WriteSQL(DbCommand cmd)
        {
            String sql = cmd.CommandText;
            if (cmd.CommandType != CommandType.Text) sql = String.Format("[{0}]{1}", cmd.CommandType, sql);

            DbParameter[] ps = null;
            if (cmd.Parameters != null)
            {
                var cps = cmd.Parameters;
                ps = new DbParameter[cps.Count];
                //cmd.Parameters.CopyTo(ps, 0);
                for (int i = 0; i < ps.Length; i++)
                {
                    ps[i] = cps[i];
                }
            }

            WriteSQL(sql, ps);
        }

        /// <summary>�����־</summary>
        /// <param name="msg"></param>
        public static void WriteLog(String msg) { DAL.WriteLog(msg); }

        /// <summary>�����־</summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void WriteLog(String format, params Object[] args) { DAL.WriteLog(format, args); }
        #endregion
    }
}