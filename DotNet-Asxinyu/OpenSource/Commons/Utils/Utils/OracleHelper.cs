namespace Utils
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.OracleClient;
    using System.Data.SqlClient;
    using System.Runtime.CompilerServices;

    /// <summary><para>　</para>
    /// 类名：常用工具类——ORACLE数据库操作类
    /// <para>创建时间：2009-12-10</para><para>创建人：月亮  http://ycmoon.008.net  QQ:817647</para><para>最后修改时间：2009-12-10</para><para>-------------------------------------------------</para><para>　ExecuteNonQuery：执行数据库语句返回受影响的行数，失败或异常返回-1 [ +4 重载 ]</para><para>　ExecuteDataSet：执行数据库语句返回第一个DataSet [ +2 重载 ]</para><para>　ExecuteScalar：执行数据库语句返回第一行第一列，失败或异常返回null</para><para>　ExecuteReader：执行数据库语句返回一个自进结果集流 [ +3 重载 ]</para><para>　ExecuteSqlTran：执行多条SQL语句，实现数据库事务。</para></summary>
    public class OracleHelper
    {
        private static Hashtable x53147150e715ee9e = Hashtable.Synchronized(new Hashtable());

        private OracleHelper() {  }

        /// <summary>执行查询语句，返回DataSet</summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="SQLString">SQL语句</param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string connectionString, string SQLString)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                try
                {
                    connection.Open();
                    new OracleDataAdapter(SQLString, connection).Fill(dataSet, "ds");
                }
                catch (OracleException exception)
                {
                    throw new Exception(exception.Message);
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed) connection.Close();
                }
                return dataSet;
            }
        }

        /// <summary>执行查询语句，返回DataSet</summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="cmdParms">参数</param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string connectionString, string SQLString, params OracleParameter[] cmdParms)
        {
            DataSet set2;
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                OracleCommand command = new OracleCommand();
                xc7d3fed5b091568c(command, connection, null, SQLString, cmdParms);
                using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                {
                    DataSet dataSet = new DataSet();
                    try
                    {
                        adapter.Fill(dataSet, "ds");
                        command.Parameters.Clear();
                    }
                    catch (OracleException exception)
                    {
                        throw new Exception(exception.Message);
                    }
                    finally
                    {
                        if (connection.State != ConnectionState.Closed) connection.Close();
                    }
                    set2 = dataSet;
                }
            }
            return set2;
        }

        /// <summary>执行数据库语句返回受影响的行数，失败或异常返回-1</summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="cmdText">SQL语句</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string connectionString, string cmdText)
        {
            OracleCommand command = new OracleCommand();
            OracleConnection connection = new OracleConnection(connectionString);
            xc7d3fed5b091568c(command, connection, null, CommandType.Text, cmdText, null);
            int num = command.ExecuteNonQuery();
            command.Parameters.Clear();
            return num;
        }

        /// <summary>执行数据库语句返回受影响的行数，失败或异常返回-1</summary>
        /// <param name="connection">OracleConnection对象</param>
        /// <param name="cmdType">SQL语句类型</param>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="commandParameters">参数</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(OracleConnection connection, CommandType cmdType, string cmdText, params OracleParameter[] commandParameters)
        {
            OracleCommand command = new OracleCommand();
            xc7d3fed5b091568c(command, connection, null, cmdType, cmdText, commandParameters);
            int num = command.ExecuteNonQuery();
            command.Parameters.Clear();
            return num;
        }

        /// <summary>执行数据库事务返回受影响的行数，失败或异常返回-1</summary>
        /// <param name="trans">事务</param>
        /// <param name="cmdType">SQL语句类型</param>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="commandParameters">参数</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(OracleTransaction trans, CommandType cmdType, string cmdText, params OracleParameter[] commandParameters)
        {
            OracleCommand command = new OracleCommand();
            xc7d3fed5b091568c(command, trans.Connection, trans, cmdType, cmdText, commandParameters);
            int num = command.ExecuteNonQuery();
            command.Parameters.Clear();
            return num;
        }

        /// <summary>执行数据库语句返回受影响的行数，失败或异常返回-1</summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="cmdType">SQL语句类型</param>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="commandParameters">参数</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params OracleParameter[] commandParameters)
        {
            OracleCommand command = new OracleCommand();
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                xc7d3fed5b091568c(command, connection, null, cmdType, cmdText, commandParameters);
                int num = command.ExecuteNonQuery();
                connection.Close();
                command.Parameters.Clear();
                return num;
            }
        }

        /// <summary>执行数据库语句返回一个自进结果集流</summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="cmdType">SQL语句类型</param>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="commandParameters">参数</param>
        /// <returns></returns>
        public static OracleDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params OracleParameter[] commandParameters)
        {
            OracleDataReader reader2;
            OracleCommand command = new OracleCommand();
            OracleConnection connection = new OracleConnection(connectionString);
            try
            {
                xc7d3fed5b091568c(command, connection, null, cmdType, cmdText, commandParameters);
                OracleDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                command.Parameters.Clear();
                reader2 = reader;
            }
            catch
            {
                connection.Close();
                throw;
            }
            return reader2;
        }

        /// <summary>执行数据库语句返回第一行第一列，失败或异常返回null</summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>查询结果（object）</returns>
        public static object ExecuteScalar(string connectionString, string SQLString)
        {
            object obj3;
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                using (OracleCommand command = new OracleCommand(SQLString, connection))
                {
                    try
                    {
                        object obj2;
                        connection.Open();
                        goto Label_0042;
                    Label_0017:
                        if (0 != 0) goto Label_002C;
                        return obj2;
                    Label_001F:
                        obj3 = null;
                        if (0 != 0) return obj2;
                        return obj3;
                    Label_002C:
                        if (object.Equals(obj2, DBNull.Value)) goto Label_001F;
                        if (-2147483648 != 0) return obj2;
                        goto Label_0054;
                    Label_0042:
                        obj2 = command.ExecuteScalar();
                        if (object.Equals(obj2, null)) goto Label_001F;
                        goto Label_002C;
                    Label_0054:
                        if (-2147483648 != 0) goto Label_0017;
                        return obj3;
                    }
                    catch (OracleException exception)
                    {
                        throw new Exception(exception.Message);
                    }
                    finally
                    {
                        if (connection.State != ConnectionState.Closed) connection.Close();
                    }
                }
            }
            return obj3;
        }

        /// <summary>执行数据库语句返回一个自进结果集流</summary>
        /// <param name="connectionString">OracleConnection对象</param>
        /// <param name="cmdType">SQL语句类型</param>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="commandParameters">参数</param>
        /// <returns></returns>
        public static object ExecuteScalar(OracleConnection connectionString, CommandType cmdType, string cmdText, params OracleParameter[] commandParameters)
        {
            OracleCommand command = new OracleCommand();
            xc7d3fed5b091568c(command, connectionString, null, cmdType, cmdText, commandParameters);
            object obj2 = command.ExecuteScalar();
            command.Parameters.Clear();
            return obj2;
        }

        /// <summary>Execute a OracleCommand (that returns a 1x1 resultset) against the specified SqlTransactionusing the provided parameters.</summary>
        /// <param name="transaction">A valid SqlTransaction</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or PL/SQL command</param>
        /// <param name="commandParameters">An array of OracleParamters used to execute the command</param>
        /// <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
        public static object ExecuteScalar(OracleTransaction transaction, CommandType commandType, string commandText, params OracleParameter[] commandParameters)
        {
            OracleCommand command;
            object obj2;
            if (transaction != null)
            {
                if (transaction != null)
                {
                    if (transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
                    if (-2 == 0) goto Label_0041;
                }
                command = new OracleCommand();
                goto Label_0041;
            }
            if (0 == 0) throw new ArgumentNullException("transaction");
        Label_0006:
            obj2 = command.ExecuteScalar();
            command.Parameters.Clear();
            return obj2;
        Label_0041:
            xc7d3fed5b091568c(command, transaction.Connection, transaction, commandType, commandText, commandParameters);
            goto Label_0006;
        }

        /// <summary>执行数据库语句返回一个自进结果集流</summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="cmdType">SQL语句类型</param>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="commandParameters">参数</param>
        /// <returns></returns>
        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params OracleParameter[] commandParameters)
        {
            OracleCommand command = new OracleCommand();
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                xc7d3fed5b091568c(command, connection, null, cmdType, cmdText, commandParameters);
                object obj2 = command.ExecuteScalar();
                command.Parameters.Clear();
                return obj2;
            }
        }

        /// <summary>执行多条SQL语句，实现数据库事务。</summary>
        /// <param name="conStr"></param>
        /// <param name="SQLStringList"></param>
        public static void ExecuteSqlTran(string conStr, List<string> SQLStringList)
        {
            using (OracleConnection connection = new OracleConnection(conStr))
            {
                connection.Open();
                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                OracleTransaction transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                try
                {
                    using (List<string>.Enumerator enumerator = SQLStringList.GetEnumerator())
                    {
                    Label_0053:
                        while (enumerator.MoveNext())
                        {
                            do
                            {
                                string current = enumerator.Current;
                                if (string.IsNullOrEmpty(current)) goto Label_0053;
                                command.CommandText = current;
                                command.ExecuteNonQuery();
                            }
                            while (0 != 0);
                        }
                    }
                    transaction.Commit();
                }
                catch (OracleException exception)
                {
                    transaction.Rollback();
                    throw new Exception(exception.Message);
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed) connection.Close();
                }
            }
        }

        /// <summary>执行多条SQL语句，实现数据库事务。</summary>
        /// <param name="conStr">连接字符串</param>
        /// <param name="cmdList">多条SQL语句</param>
        /// <returns></returns>
        public static bool ExecuteSqlTran(string conStr, List<CommandInfo> cmdList)
        {
            bool flag2;
            using (OracleConnection connection = new OracleConnection(conStr))
            {
                connection.Open();
                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                OracleTransaction transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                try
                {
                    using (List<CommandInfo>.Enumerator enumerator = cmdList.GetEnumerator())
                    {
                        CommandInfo info;
                        object obj2;
                        bool flag;
                        int num;
                        goto Label_005B;
                    Label_0034:
                        if (info.EffentNextType == EffentNextType.ExcuteEffectRows) goto Label_00D3;
                        if (((uint) flag) + ((uint) flag2) < 0) goto Label_0228;
                    Label_005B:
                        if (enumerator.MoveNext()) goto Label_0309;
                        goto Label_00FD;
                    Label_0069:
                        if (info.EffentNextType == EffentNextType.WhenNoHaveContine && flag) goto Label_0138;
                        goto Label_005B;
                    Label_007B:
                        if (!string.IsNullOrEmpty(info.CommandText)) goto Label_0259;
                        if ((((uint) num) | 15) != 0) goto Label_005B;
                        goto Label_0069;
                    Label_00B0:
                        num = command.ExecuteNonQuery();
                        if (((uint) flag2) - ((uint) flag2) >= 0) goto Label_0034;
                    Label_00D3:
                        if (num != 0) goto Label_005B;
                    Label_00DA:
                        transaction.Rollback();
                        throw new Exception("Oracle:违背要求" + info.CommandText + "必须有影像行");
                    Label_00FD:
                        if (((uint) flag) - ((uint) flag2) <= uint.MaxValue) goto Label_033E;
                        if (((uint) flag2) - ((uint) flag) >= 0) goto Label_02EE;
                        goto Label_02BC;
                    Label_0138:
                        transaction.Rollback();
                        throw new Exception("Oracle:违背要求" + info.CommandText + "返回值必须等于0");
                    Label_015E:
                        if (info.EffentNextType == EffentNextType.WhenNoHaveContine) goto Label_0203;
                        goto Label_02DC;
                    Label_016F:
                        if (!flag) goto Label_018F;
                        goto Label_0069;
                    Label_0178:
                        if ((((uint) flag2) & 0) != 0) goto Label_00DA;
                    Label_018F:
                        transaction.Rollback();
                        throw new Exception("Oracle:违背要求" + info.CommandText + "返回值必须大于0");
                    Label_01B5:
                        if (8 == 0) goto Label_01EB;
                    Label_01BC:
                        flag = Convert.ToInt32(obj2) > 0;
                        if (info.EffentNextType != EffentNextType.WhenHaveContine) goto Label_0069;
                        if (((uint) flag) >= 0) goto Label_016F;
                        goto Label_0284;
                    Label_01EB:
                        if (obj2 == DBNull.Value) goto Label_01FC;
                        goto Label_01BC;
                    Label_01F6:
                        if (obj2 != null) goto Label_01BC;
                        goto Label_01EB;
                    Label_01FC:
                        flag = false;
                        goto Label_01B5;
                    Label_0203:
                        if (info.CommandText.ToLower().IndexOf("count(") == -1) goto Label_0236;
                        obj2 = command.ExecuteScalar();
                        flag = false;
                        goto Label_01F6;
                    Label_0228:
                        if (info.EffentNextType != EffentNextType.WhenHaveContine) goto Label_015E;
                        goto Label_0203;
                    Label_0236:
                        transaction.Rollback();
                        throw new Exception("Oracle:违背要求" + info.CommandText + "必须符合select count(..的格式");
                    Label_0259:
                        xc7d3fed5b091568c(command, connection, transaction, CommandType.Text, info.CommandText, (OracleParameter[]) info.Parameters);
                        goto Label_0228;
                    Label_0284:
                        if (((uint) num) + ((uint) flag) <= uint.MaxValue) goto Label_0178;
                        if (((uint) flag) + ((uint) num) >= 0) goto Label_0138;
                        goto Label_02DC;
                    Label_02BC:
                        if (((uint) flag) + ((uint) flag) > uint.MaxValue) goto Label_00B0;
                        goto Label_007B;
                    Label_02DC:
                        if (((uint) flag) <= uint.MaxValue) goto Label_00B0;
                    Label_02EE:
                        if (((uint) num) - ((uint) flag2) < 0) goto Label_018F;
                    Label_0309:
                        info = enumerator.Current;
                        if (((uint) flag) - ((uint) num) <= uint.MaxValue) goto Label_02BC;
                        goto Label_00B0;
                    }
                Label_033E:
                    transaction.Commit();
                    flag2 = true;
                }
                catch (OracleException exception)
                {
                    transaction.Rollback();
                    throw exception;
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed) connection.Close();
                }
            }
            return flag2;
        }

        private static bool x4a853b4aa56b8f25(string x916ab12f6e6518fc, string x2d0ce566bce96095)
        {
            int num;
            object objA = ExecuteScalar(x916ab12f6e6518fc, x2d0ce566bce96095);
            if (!object.Equals(objA, null))
            {
                if (object.Equals(objA, DBNull.Value)) goto Label_0039;
                num = int.Parse(objA.ToString());
            }
            else
                goto Label_0039;
        Label_000C:
            do
            {
                if (num == 0) return false;
            }
            while (-2 == 0);
            goto Label_0052;
        Label_0039:
            num = 0;
            if (0 == 0 && 0 == 0) goto Label_000C;
        Label_0052:
            return true;
        }

        private static void x70c5d01bce3177bd(string x29cf3789a06c902a, params OracleParameter[] x7c53128b28d22eeb) { x53147150e715ee9e[x29cf3789a06c902a] = x7c53128b28d22eeb; }

        private static OracleParameter[] xbc24439f8a5a5573(string x29cf3789a06c902a)
        {
            OracleParameter[] parameterArray2;
            int num;
            int length;
            OracleParameter[] parameterArray = (OracleParameter[]) x53147150e715ee9e[x29cf3789a06c902a];
            goto Label_0060;
        Label_002D:
            while (num < length)
            {
                parameterArray2[num] = (OracleParameter) ((ICloneable) parameterArray[num]).Clone();
                num++;
            }
        Label_0059:
            if (1 != 0) return parameterArray2;
        Label_0060:
            if (parameterArray != null)
            {
                parameterArray2 = new OracleParameter[parameterArray.Length];
                num = 0;
                if ((((uint) length) & 0) == 0)
                {
                    length = parameterArray.Length;
                    goto Label_002D;
                }
                goto Label_0059;
            }
            if (0 != 0) goto Label_002D;
            return null;
        }

        private static void xc7d3fed5b091568c(OracleCommand x61b060a94340c4fc, OracleConnection x79ee3f6bdf75f984, OracleTransaction xa5fb9aee66f824e6, string x31b309266b0c059b, OracleParameter[] xc2c445c96bc4af23)
        {
            OracleParameter parameter;
            OracleParameter[] parameterArray;
            int num;
            if (x79ee3f6bdf75f984.State == ConnectionState.Open) goto Label_013E;
            goto Label_0138;
        Label_0013:
            if (xc2c445c96bc4af23 != null)
            {
                parameterArray = xc2c445c96bc4af23;
                if (1 != 0)
                {
                    num = 0;
                    goto Label_005D;
                }
                goto Label_012C;
            }
            return;
        Label_0041:
            if (parameter.Value == null) parameter.Value = DBNull.Value;
        Label_0049:
            x61b060a94340c4fc.Parameters.Add(parameter);
            num++;
            if (0 != 0) goto Label_0096;
        Label_005D:
            if (num < parameterArray.Length)
            {
                parameter = parameterArray[num];
                if (((uint) num) + ((uint) num) <= uint.MaxValue)
                {
                    if (0 != 0) return;
                    if (parameter.Direction != ParameterDirection.InputOutput) goto Label_0096;
                    goto Label_0041;
                }
                if (((uint) num) + ((uint) num) >= 0) goto Label_012C;
                goto Label_00E1;
            }
            if ((((uint) num) & 0) == 0)
            {
                if (4 == 0) goto Label_0013;
                if ((((uint) num) & 0) == 0) return;
                if (-2147483648 == 0)
                {
                }
            }
            goto Label_0041;
        Label_0096:
            if (parameter.Direction != ParameterDirection.Input) goto Label_0049;
            goto Label_0041;
        Label_00E1:
            x61b060a94340c4fc.CommandType = CommandType.Text;
            goto Label_0013;
        Label_012C:
            while (xa5fb9aee66f824e6 != null)
            {
                x61b060a94340c4fc.Transaction = xa5fb9aee66f824e6;
                if (((uint) num) - ((uint) num) > uint.MaxValue) goto Label_0145;
                if (((uint) num) > uint.MaxValue) goto Label_0138;
                break;
            }
            goto Label_00E1;
        Label_0138:
            x79ee3f6bdf75f984.Open();
        Label_013E:
            x61b060a94340c4fc.Connection = x79ee3f6bdf75f984;
        Label_0145:
            x61b060a94340c4fc.CommandText = x31b309266b0c059b;
            goto Label_012C;
        }

        private static void xc7d3fed5b091568c(OracleCommand x61b060a94340c4fc, OracleConnection x79ee3f6bdf75f984, OracleTransaction xa5fb9aee66f824e6, CommandType x876516c75eb784e6, string x31b309266b0c059b, OracleParameter[] x7c53128b28d22eeb)
        {
            OracleParameter[] parameterArray;
            int num;
            if (x79ee3f6bdf75f984.State == ConnectionState.Open) goto Label_00D4;
            if ((((uint) num) & 0) == 0)
            {
                x79ee3f6bdf75f984.Open();
                if (0 != 0) goto Label_00E3;
                goto Label_00D4;
            }
            goto Label_008C;
        Label_002C:
            while (num < parameterArray.Length)
            {
                OracleParameter parameter = parameterArray[num];
                x61b060a94340c4fc.Parameters.Add(parameter);
                if (-2147483648 == 0) return;
                num++;
            }
            if (((uint) num) <= uint.MaxValue) return;
        Label_0047:
            if (x7c53128b28d22eeb == null) return;
            parameterArray = x7c53128b28d22eeb;
            num = 0;
            goto Label_002C;
        Label_008C:
            if ((((uint) num) & 0) != 0) goto Label_002C;
            while (xa5fb9aee66f824e6 != null)
            {
                x61b060a94340c4fc.Transaction = xa5fb9aee66f824e6;
                if (0 == 0)
                {
                    if (((uint) num) - ((uint) num) < 0) continue;
                    goto Label_00B4;
                }
            }
            if (0 == 0) goto Label_0047;
        Label_00B4:
            if (((uint) num) >= 0) goto Label_0047;
            return;
        Label_00D4:
            x61b060a94340c4fc.Connection = x79ee3f6bdf75f984;
            x61b060a94340c4fc.CommandText = x31b309266b0c059b;
        Label_00E3:
            x61b060a94340c4fc.CommandType = x876516c75eb784e6;
            goto Label_008C;
        }

        /// <summary></summary>
        public class CommandInfo
        {
            /// <summary></summary>
            public string CommandText;
            /// <summary></summary>
            public Utils.OracleHelper.EffentNextType EffentNextType;
            /// <summary></summary>
            public object OriginalData;
            /// <summary></summary>
            public DbParameter[] Parameters;
            /// <summary></summary>
            public object ShareObject;

            private event EventHandler _x78e5593dd2c15ce0;

            /// <summary></summary>
            public event EventHandler SolicitationEvent;

            /// <summary></summary>
            public CommandInfo() {  }

            /// <summary></summary>
            /// <param name="sqlText"></param>
            /// <param name="para"></param>
            public CommandInfo(string sqlText, SqlParameter[] para)
            {
                this.CommandText = sqlText;
                this.Parameters = para;
            }

            /// <summary></summary>
            /// <param name="sqlText"></param>
            /// <param name="para"></param>
            /// <param name="type"></param>
            public CommandInfo(string sqlText, SqlParameter[] para, Utils.OracleHelper.EffentNextType type)
            {
                this.CommandText = sqlText;
                this.Parameters = para;
                this.EffentNextType = type;
            }

            /// <summary></summary>
            public void OnSolicitationEvent()
            {
                if (this._x78e5593dd2c15ce0 != null) this._x78e5593dd2c15ce0(this, new EventArgs());
            }
        }

        /// <summary></summary>
        public enum EffentNextType
        {
            None,
            WhenHaveContine,
            WhenNoHaveContine,
            ExcuteEffectRows,
            SolicitationEvent
        }
    }
}
