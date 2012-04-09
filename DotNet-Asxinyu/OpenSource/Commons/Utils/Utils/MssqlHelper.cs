namespace Utils
{
    using System;
    using System.Collections;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Runtime.InteropServices;

    /// <summary><para>　</para>
    /// 类名：常用工具类——MSSQL数据库操作类
    /// <para>创建时间：2009-12-10</para><para>创建人：月亮  http://ycmoon.008.net  QQ:817647</para><para>最后修改时间：2009-12-10</para><para>-----------------------------------------------------------------------------</para><para>　GetConnectionString：读取Web.Config中的连接字符串</para><para>　CreateConnection：生成IdbConnection 对象</para><para>　ExecuteNonQuery：执行数据库语句返回受影响的行数，失败或异常返回-1 [ +2 重载 ]</para><para>　ExecuteScalar：执行数据库语句返回第一行第一列，失败或异常返回null</para><para>　ExecuteDataTable：执行数据库语句返回第一个内存表</para><para>　ExecuteDataSet：执行数据库语句返回第一个DataSet</para><para>　ExecuteReader：执行数据库语句返回一个自进结果集流</para><para>　GetDataTableName：获取数据库全部列表</para></summary>
    public sealed class MssqlHelper
    {
        private MssqlHelper() {  }

        /// 执行数据库语句返回第一个DataSet
        /// <summary><param name="Connection">数据库连接对象</param><param name="CommandText">SQL语句</param><param name="CommandType">SQL语句类型</param><param name="Parameter">数据库参数</param><returns></returns></summary>
        public static DataSet ExecuteDataSet(IDbConnection Connection, string CommandText, CommandType CommandType, params IDataParameter[] Parameter)
        {
            DataSet set = null;
            if (0 == 0)
            {
                if (Connection != null) goto Label_0036;
                goto Label_004D;
            }
            goto Label_000E;
            if (15 == 0) goto Label_0036;
        Label_000E:
            set = new DataSet();
            set.Load(ExecuteReader(Connection, CommandText, CommandType, Parameter), LoadOption.OverwriteChanges, new string[] { "TableName" });
            return set;
        Label_0036:
            if (!string.IsNullOrEmpty(Connection.ConnectionString) && 0 == 0) goto Label_000E;
        Label_004D:
            throw new ArgumentException("connection参数为null或者提供的连接字符串为空！");
        }

        /// <summary>执行数据库语句返回第一个内存表</summary>
        /// <param name="Connection">数据库连接对象</param>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="CommandType">SQL语句类型</param>
        /// <param name="Parameter">数据库参数</param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(IDbConnection Connection, string CommandText, CommandType CommandType, params IDataParameter[] Parameter)
        {
            DataTable table;
            if (Connection == null) goto Label_0032;
        Label_0007:
            if (string.IsNullOrEmpty(Connection.ConnectionString)) goto Label_0032;
        Label_0014:
            table = new DataTable();
            table.Load(ExecuteReader(Connection, CommandText, CommandType, Parameter));
            if (0x7fffffff != 0) return table;
            goto Label_0007;
        Label_0032:
            throw new ArgumentException("connection参数为null或者提供的连接字符串为空！");
            if (0 == 0) goto Label_0014;
            return table;
        }

        /// <summary>执行数据库语句返回受影响的行数，失败或异常返回-1</summary>
        /// <param name="Connection">数据库连接对象</param>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="CommandType">SQL语句类型</param>
        /// <param name="Parameter">数据库参数</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(IDbConnection Connection, string CommandText, CommandType CommandType, params IDataParameter[] Parameter)
        {
            int num;
            IDbCommand command;
            if (Connection == null || -2 == 0 || string.IsNullOrEmpty(Connection.ConnectionString)) throw new ArgumentException("connection参数为null或者提供的连接字符串为空！");
            bool flag = false;
            if (((uint) num) >= 0)
            {
                if (((uint) num) + ((uint) flag) > uint.MaxValue) goto Label_000B;
                num = 0;
                command = Connection.CreateCommand();
            }
            xc7d3fed5b091568c(command, Connection, CommandType, CommandText, Parameter, out flag);
            num = command.ExecuteNonQuery();
        Label_000B:
            command.Parameters.Clear();
            while (flag)
            {
                Connection.Close();
                return num;
            }
            return num;
        }

        /// <summary>执行数据库语句返回受影响的行数，失败或异常返回-1</summary>
        /// <param name="Tans">数据库事务对象</param>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="CommandType">SQL语句类型</param>
        /// <param name="Parameter">数据库参数</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(SqlTransaction Tans, string CommandText, CommandType CommandType, params IDataParameter[] Parameter)
        {
            int num;
            bool flag = false;
        Label_0038:
            num = 0;
            if (((uint) num) <= uint.MaxValue)
            {
                SqlCommand command = new SqlCommand();
                xc7d3fed5b091568c(command, Tans.Connection, CommandType, CommandText, Parameter, out flag);
                num = command.ExecuteNonQuery();
                if (0 == 0)
                {
                    command.Parameters.Clear();
                    command.Dispose();
                    return num;
                }
                goto Label_0038;
            }
            return num;
        }

        /// <summary>执行数据库语句返回一个自进结果集流</summary>
        /// <param name="Connection">数据库连接对象</param>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="CommandType">SQL语句类型</param>
        /// <param name="Parameter">数据库参数</param>
        /// <returns></returns>
        public static IDataReader ExecuteReader(IDbConnection Connection, string CommandText, CommandType CommandType, params IDataParameter[] Parameter)
        {
            bool flag;
            IDbCommand command;
            IDataReader reader;
            bool flag2;
            if (Connection == null) goto Label_00EF;
            if (((uint) flag2) - ((uint) flag) <= uint.MaxValue) goto Label_00FC;
        Label_0021:
            if (((uint) flag2) - ((uint) flag) < 0) goto Label_00FC;
        Label_004E:
            while (flag2)
            {
                command.Parameters.Clear();
                return reader;
            }
            return reader;
        Label_00EF:
            throw new ArgumentException("connection参数为null或者提供的连接字符串为空！");
        Label_00FC:
            do
            {
                if (string.IsNullOrEmpty(Connection.ConnectionString)) goto Label_00EF;
                flag = false;
            }
            while (((uint) flag) - ((uint) flag) > uint.MaxValue);
            command = Connection.CreateCommand();
            xc7d3fed5b091568c(command, Connection, CommandType, CommandText, Parameter, out flag);
            reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            flag2 = true;
            IEnumerator enumerator = command.Parameters.GetEnumerator();
            try
            {
                IDataParameter current;
                goto Label_0075;
            Label_0067:
                flag2 = false;
                goto Label_0075;
            Label_006B:
                if (current.Direction != ParameterDirection.Input) goto Label_0067;
            Label_0075:
                if (enumerator.MoveNext())
                {
                    current = (IDataParameter) enumerator.Current;
                    if (0 == 0) goto Label_006B;
                    goto Label_0067;
                }
                goto Label_004E;
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                while (disposable != null)
                {
                    disposable.Dispose();
                    break;
                }
            }
            goto Label_0021;
        }

        /// <summary>执行数据库语句返回第一行第一列，失败或异常返回null</summary>
        /// <param name="Connection">数据库连接对象</param>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="CommandType">SQL语句类型</param>
        /// <param name="Parameter">数据库参数</param>
        /// <returns></returns>
        public static object ExecuteScalar(IDbConnection Connection, string CommandText, CommandType CommandType, params IDataParameter[] Parameter)
        {
            bool flag;
            object obj2;
            IDbCommand command;
            if (Connection == null) goto Label_00A6;
            if (8 == 0) goto Label_0084;
            goto Label_00C9;
        Label_004C:
            Connection.Close();
            return obj2;
        Label_006C:
            if (((uint) flag) - ((uint) flag) < 0) goto Label_004C;
        Label_0084:
            command = Connection.CreateCommand();
            if ((((uint) flag) & 0) == 0)
            {
            Label_001A:
                xc7d3fed5b091568c(command, Connection, CommandType, CommandText, Parameter, out flag);
                obj2 = command.ExecuteScalar();
                command.Parameters.Clear();
                if ((((uint) flag) & 0) == 0 && !flag)
                {
                    if (1 != 0)
                    {
                        if (((uint) flag) - ((uint) flag) >= 0) return obj2;
                        goto Label_006C;
                    }
                    goto Label_001A;
                }
                goto Label_004C;
            }
            return obj2;
        Label_00A6:
            throw new ArgumentException("connection参数为null或者提供的连接字符串为空！");
            if (((uint) flag) + ((uint) flag) >= 0) goto Label_00D6;
        Label_00C9:
            if (string.IsNullOrEmpty(Connection.ConnectionString)) goto Label_00A6;
        Label_00D6:
            flag = false;
            obj2 = null;
            if (((uint) flag) - ((uint) flag) <= uint.MaxValue) goto Label_006C;
            return obj2;
        }

        /// <summary>读取Web.Config中的连接字符串</summary>
        /// <param name="Name">字符串的name值</param>
        /// <returns>字符串name值对应的连接字符串</returns>
        public static string GetConnectionString(string Name) { return ConfigurationManager.ConnectionStrings[Name].ConnectionString; }

        /// <summary>获取数据表</summary>
        /// <param name="Connection">连接Connection对象</param>
        /// <returns></returns>
        public static DataTable GetDataTableName(SqlConnection Connection)
        {
            DataTable schema = null;
            try
            {
                if (Connection.State == ConnectionState.Closed) Connection.Open();
                schema = Connection.GetSchema("Tables");
            }
            catch (Exception)
            {
            }
            finally
            {
                if (Connection.State == ConnectionState.Open) Connection.Close();
            }
            return schema;
        }

        private static void x602ea2abcfbf4ffa(IDbCommand x7a274f60ab25f2b9, IDataParameter[] xf8036c18814e1562)
        {
            IDataParameter parameter;
            IDataParameter[] parameterArray;
            int num;
            if (x7a274f60ab25f2b9 == null) throw new ArgumentNullException("创建数据库命令对象（IDbCommand对象）时失败！");
        Label_000A:
            if (xf8036c18814e1562 != null)
            {
                parameterArray = xf8036c18814e1562;
                if (15 == 0)
                {
                    if (((uint) num) - ((uint) num) < 0) return;
                    goto Label_00C7;
                }
                num = 0;
                do
                {
                    if (2 == 0) goto Label_00AF;
                }
                while (((uint) num) > uint.MaxValue);
                goto Label_007A;
            }
            if (((uint) num) - ((uint) num) >= 0 && ((uint) num) - ((uint) num) <= uint.MaxValue) return;
        Label_0028:
            if (((uint) num) - ((uint) num) < 0) goto Label_000A;
            return;
        Label_0064:
            num++;
            if (((uint) num) > uint.MaxValue) goto Label_00AF;
        Label_007A:
            if (num < parameterArray.Length) goto Label_00C7;
            goto Label_0028;
        Label_0082:
            if (parameter.Value == null) parameter.Value = DBNull.Value;
        Label_008A:
            x7a274f60ab25f2b9.Parameters.Add(parameter);
            goto Label_0064;
        Label_00AF:
            if (parameter.Direction == ParameterDirection.Input) goto Label_0082;
            goto Label_008A;
        Label_00C7:
            parameter = parameterArray[num];
            if (parameter != null)
            {
                if (parameter.Direction == ParameterDirection.InputOutput) goto Label_0082;
                goto Label_00AF;
            }
            goto Label_0064;
        }

        private static SqlConnection xac31a164577610bd(string xffd83ec5b8b97e99)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(xffd83ec5b8b97e99);
            }
            catch (Exception)
            {
            }
            return connection;
        }

        private static void xc7d3fed5b091568c(IDbCommand x7a274f60ab25f2b9, IDbConnection x737c0849537312c3, CommandType x1cbe9ccc3cd216b4, string xd88a210b3eefa9ef, IDataParameter[] xf8036c18814e1562, out bool x3d5e753029e51bcd)
        {
            if (x7a274f60ab25f2b9 != null) goto Label_0053;
            goto Label_008B;
        Label_000E:
            x7a274f60ab25f2b9.Connection = x737c0849537312c3;
            x7a274f60ab25f2b9.CommandText = xd88a210b3eefa9ef;
            x7a274f60ab25f2b9.CommandType = x1cbe9ccc3cd216b4;
            if (xf8036c18814e1562 == null) return;
            x602ea2abcfbf4ffa(x7a274f60ab25f2b9, xf8036c18814e1562);
            if (0 == 0) return;
        Label_0035:
            if (x737c0849537312c3.State != ConnectionState.Open)
            {
                x3d5e753029e51bcd = true;
                if (2 != 0) goto Label_0080;
                goto Label_006B;
            }
            x3d5e753029e51bcd = false;
            if (0 == 0)
            {
                if (0 != 0) goto Label_008B;
                goto Label_000E;
            }
            return;
        Label_0053:
            if (xd88a210b3eefa9ef == null) goto Label_006B;
        Label_0056:
            if (xd88a210b3eefa9ef.Length != 0) goto Label_0035;
        Label_006B:
            throw new ArgumentNullException("SQL语句为空");
            if (0 == 0) goto Label_0035;
            if (15 != 0) goto Label_0056;
        Label_0080:
            if (0 == 0)
            {
                x737c0849537312c3.Open();
                goto Label_000E;
            }
            goto Label_0056;
        Label_008B:
            throw new ArgumentNullException("创建数据库命令对象（IDbCommand对象）时失败！");
            if (-2147483648 == 0) goto Label_006B;
            goto Label_0053;
        }
    }
}
