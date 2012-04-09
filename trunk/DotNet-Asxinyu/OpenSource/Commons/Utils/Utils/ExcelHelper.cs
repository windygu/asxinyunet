namespace Utils
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Web;

    /// <summary><para>　</para>
    /// 类名：常用工具类——Excel操作类
    /// <para>创建时间：2009-12-10</para><para>创建人：月亮  http://ycmoon.008.net  QQ:817647</para><para>最后修改时间：2009-12-10</para><para>--------------------------------------------------------------</para><para>　CreateConnection：根据Excel文件路径和EXCEL驱动版本生成OleConnection对象实例</para><para>　ExecuteDataSet：执行一条SQL语句，返回一个DataSet对象</para><para>　ExecuteDataTable：执行一条SQL语句，返回一个DataTable对象</para><para>　ExecuteDataAdapter：表示一组数据命令和一个数据库连接，它们用于填充 DataSet 和更新数据源。</para><para>　ExecuteNonQuery：执行数据库语句返回受影响的行数，失败或异常返回-1[通常为:INSERT、DELETE、UPDATE 和 SET 语句等命令]。</para><para>　ExecuteScalar：执行数据库语句返回第一行第一列，失败或异常返回null</para><para>　ExecuteDataReader：执行数据库语句返回一个自进结果集流</para><para>　GetWorkBookName：获取Excel中的所有工作簿</para></summary>
    public class ExcelHelper
    {
        private ExcelHelper() {  }

        /// <summary>根据EXCEL路径生成OleDbConnectin对象</summary>
        /// <param name="ExcelFilePath">EXCEL文件相对于站点根目录的路径</param>
        /// <param name="Verion">Excel数据驱动版本：97-2003或2007,分别需要安装数据驱动软件</param>
        /// <returns>OleDbConnection对象</returns>
        public static OleDbConnection CreateConnection(string ExcelFilePath, ExcelVerion Verion)
        {
            OleDbConnection connection = null;
            string str = string.Empty;
            try
            {
                ExcelVerion verion = Verion;
                goto Label_0052;
            Label_000C:
                str = "Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0;HDR=YES';data source=" + ExcelFilePath;
            Label_0023:
                while (!string.IsNullOrEmpty(str))
                {
                    return new OleDbConnection(str);
                }
                if (0 == 0) return connection;
            Label_002E:
                str = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + HttpContext.Current.Server.MapPath(ExcelFilePath) + ";Extended Properties=Excel 8.0";
                goto Label_0023;
            Label_0052:
                switch (verion)
                {
                    case ExcelVerion.Excel2003:
                        goto Label_002E;

                    case ExcelVerion.Excel2007:
                        goto Label_000C;
                }
                if (8 != 0)
                {
                }
            }
            catch (Exception)
            {
            }
            goto Label_0023;
        }

        /// <summary>表示一组数据命令和一个数据库连接，它们用于填充 DataSet 和更新数据源。</summary>
        /// <param name="Connection">OleDbConnection对象</param>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="OleDbParameters">OleDbParameter可选参数</param>
        /// <returns></returns>
        public static OleDbDataAdapter ExecuteDataAdapter(OleDbConnection Connection, string CommandText, params OleDbParameter[] OleDbParameters)
        {
            OleDbDataAdapter adapter = null;
            try
            {
                adapter = new OleDbDataAdapter(x43ee399fedec3396(CommandText, Connection, OleDbParameters));
                new OleDbCommandBuilder(adapter);
            }
            catch (Exception)
            {
            }
            finally
            {
                if (Connection.State == ConnectionState.Open) Connection.Close();
            }
            return adapter;
        }

        /// <summary>执行数据库语句返回一个自进结果集流</summary>
        /// <param name="Connection">OleDbConnection对象</param>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="OleDbParameters">OleDbParameter可选参数</param>
        /// <returns>DataReader对象</returns>
        public static OleDbDataReader ExecuteDataReader(OleDbConnection Connection, string CommandText, params OleDbParameter[] OleDbParameters)
        {
            OleDbDataReader reader = null;
            try
            {
                reader = x43ee399fedec3396(CommandText, Connection, OleDbParameters).ExecuteReader();
            }
            catch (Exception)
            {
            }
            finally
            {
                if (Connection.State == ConnectionState.Open) Connection.Close();
            }
            return reader;
        }

        /// <summary>执行一条SQL语句，返回一个DataSet对象</summary>
        /// <param name="Connection">OleDbConnection对象</param>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="OleDbParameters">OleDbParameter可选参数</param>
        /// <returns>DataSet对象</returns>
        public static DataSet ExecuteDataSet(OleDbConnection Connection, string CommandText, params OleDbParameter[] OleDbParameters)
        {
            DataSet dataSet = new DataSet();
            try
            {
                new OleDbDataAdapter(x43ee399fedec3396(CommandText, Connection, OleDbParameters)).Fill(dataSet);
            }
            catch (Exception)
            {
            }
            finally
            {
                if (Connection.State == ConnectionState.Open) Connection.Close();
            }
            return dataSet;
        }

        /// <summary>执行一条SQL语句,返回一个DataTable对象</summary>
        /// <param name="Connection">OleDbConnection对象</param>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="OleDbParameters">OleDbParameter可选参数</param>
        /// <returns>DataSet对象</returns>
        public static DataTable ExecuteDataTable(OleDbConnection Connection, string CommandText, params OleDbParameter[] OleDbParameters)
        {
            DataTable table = null;
            try
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(x43ee399fedec3396(CommandText, Connection, OleDbParameters));
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                table = dataSet.Tables[0];
            }
            catch (Exception)
            {
            }
            finally
            {
                if (Connection.State == ConnectionState.Open) Connection.Close();
            }
            return table;
        }

        /// <summary>执行数据库语句返回受影响的行数，失败或异常返回-1[通常为:INSERT、DELETE、UPDATE 和 SET 语句等命令]。</summary>
        /// <param name="Connection">OleDbConnection对象</param>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="OleDbParameters">OleDbParameter可选参数</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery(OleDbConnection Connection, string CommandText, params OleDbParameter[] OleDbParameters)
        {
            int num = -1;
            try
            {
                if (Connection.State == ConnectionState.Closed) Connection.Open();
                num = x43ee399fedec3396(CommandText, Connection, OleDbParameters).ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                if (Connection.State == ConnectionState.Open) Connection.Close();
            }
            return num;
        }

        /// <summary>执行数据库语句返回第一行第一列，失败或异常返回null</summary>
        /// <param name="Connection">OleDbConnection对象</param>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="OleDbParameters">OleDbParameter可选参数</param>
        /// <returns>第一行第一列的值</returns>
        public static object ExecuteScalar(OleDbConnection Connection, string CommandText, params OleDbParameter[] OleDbParameters)
        {
            object obj2 = null;
            try
            {
                obj2 = x43ee399fedec3396(CommandText, Connection, OleDbParameters).ExecuteScalar();
            }
            catch (Exception)
            {
            }
            finally
            {
                if (Connection.State == ConnectionState.Open) Connection.Close();
            }
            return obj2;
        }

        /// <summary>获取Excel中的所有工作簿</summary>
        /// <param name="Connection">OleDbConnection对象</param>
        /// <returns></returns>
        public static DataTable GetWorkBookName(OleDbConnection Connection)
        {
            DataTable oleDbSchemaTable = null;
            try
            {
                if (Connection.State == ConnectionState.Closed) Connection.Open();
                oleDbSchemaTable = Connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            }
            catch (Exception)
            {
            }
            finally
            {
                if (Connection.State == ConnectionState.Open) Connection.Close();
            }
            return oleDbSchemaTable;
        }

        private static OleDbCommand x43ee399fedec3396(string xd88a210b3eefa9ef, OleDbConnection x737c0849537312c3, params OleDbParameter[] xabcb595816e60ccb)
        {
            if (x737c0849537312c3.State == ConnectionState.Closed) x737c0849537312c3.Open();
            OleDbCommand command = new OleDbCommand(xd88a210b3eefa9ef, x737c0849537312c3);
        Label_001B:
            if (xabcb595816e60ccb != null)
            {
                OleDbParameter[] parameterArray = xabcb595816e60ccb;
                int index = 0;
                while (index < parameterArray.Length)
                {
                    OleDbParameter parameter;
                    do
                    {
                        parameter = parameterArray[index];
                    }
                    while (((uint) index) - ((uint) index) > uint.MaxValue);
                    command.Parameters.Add(parameter);
                    if (1 != 0)
                    {
                    }
                    index++;
                    if ((((uint) index) & 0) != 0) goto Label_001B;
                }
                return command;
            }
            if (0 == 0) return command;
            goto Label_001B;
        }

        /// <summary>EXCEL版本</summary>
        public enum ExcelVerion
        {
            Excel2003,
            Excel2007
        }
    }
}
