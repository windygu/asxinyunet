namespace Utils
{
    using System;
    using System.Collections;
    using System.Configuration;
    using System.Data;
    using System.Data.Common;

    /// <summary><para>　</para>
    /// 类名：常用工具类——数据工厂DbFactory类
    /// <para>创建时间：2010-01-11</para><para>创建人：月亮  http://ycmoon.008.net  QQ:817647</para><para>最后修改时间：2010-01-12</para><para>-----------------------------------------------------------------------------</para><para>使用方法：</para><para>1、实例化类:Utils.DbFactory DB = new Utils.DbFactory("数据库连接字符串名称");【或名称为空则为ConnectionString】</para><para>2、调用方法。</para><para>【说明：向DbParameter中添加参数方法：DB.CreateParameter("@Key","Value")】</para><para>-----------------------------------------------------------------------------</para><para>　ExecuteNonQuery：执行查询语句,并返回受影响的记录行数[+4重载]</para><para>　ExecuteScalar：执行查询语句,并返回首行首列的值[+4重载]</para><para>　ExecuteReader：执行查询，并以DataReader返回结果集[+4重载]</para><para>　ExecuteDataSet：执行查询，并以DataSet返回结果集[+5重载]</para><para>　ExecuteDataView：执行查询，并以DataView返回结果集[+5重载]</para><para>　ExecuteDataTable：执行查询，并以DataTable返回结果集[+6重载]</para><para>　CreateParameter：创建参数【在传参时使用DB.CreateParameter("@Key","Value")】</para><para>　GetConnectionString：获取数据库连接字符串示例信息</para></summary>
    public class DbFactory
    {
        private string _xcc3d2e7156117305;

        /// <summary>构造方法</summary>
        public DbFactory() { this._xcc3d2e7156117305 = "ConnectionString"; }

        /// <summary>构造方法</summary>
        /// <param name="configString"></param>
        public DbFactory(string configString)
        {
            this._xcc3d2e7156117305 = "ConnectionString";
            this.ConnectionName = configString;
        }

        /// <summary>创建数据适配器</summary>
        /// <param name="sql">SQL,语句</param>
        /// <returns>数据适配器实例</returns>
        public DbDataAdapter CreateAdapter(string sql)
        {
            DbParameter[] parameters = new DbParameter[0];
            return this.CreateAdapter(sql, CommandType.Text, parameters);
        }

        /// <summary>创建数据适配器</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="CommandType">命令类型</param>
        /// <returns>数据适配器实例</returns>
        public DbDataAdapter CreateAdapter(string CommandText, CommandType CommandType)
        {
            DbParameter[] parameters = new DbParameter[0];
            return this.CreateAdapter(CommandText, CommandType, parameters);
        }

        /// <summary>创建数据适配器</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="CommandType">命令类型</param>
        /// <param name="Parameters">参数</param>
        /// <returns>数据适配器实例</returns>
        public DbDataAdapter CreateAdapter(string CommandText, CommandType CommandType, DbParameter[] Parameters)
        {
            DbCommand command;
            DbDataAdapter adapter;
            DbParameter[] parameterArray;
            int num;
            DbConnection connection = this.CreateConnection();
            goto Label_0099;
        Label_000E:
            if (Parameters.Length > 0) goto Label_008F;
        Label_0017:
            adapter = this.GetDbProviderFactory().CreateDataAdapter();
            adapter.SelectCommand = command;
            return adapter;
        Label_005E:
            num = 0;
        Label_0050:
            if (num < parameterArray.Length)
            {
                DbParameter parameter = parameterArray[num];
                if ((((uint) num) | 3) == 0) return adapter;
                command.Parameters.Add(parameter);
                if (0 == 0)
                {
                    num++;
                    if (-2 == 0) goto Label_005E;
                    goto Label_0050;
                }
                goto Label_000E;
            }
            goto Label_0017;
        Label_008F:
            parameterArray = Parameters;
            if (-1 != 0) goto Label_005E;
        Label_0099:
            command = this.GetDbProviderFactory().CreateCommand();
            command.Connection = connection;
            command.CommandText = CommandText;
            if (((uint) num) < 0) goto Label_008F;
            command.CommandType = CommandType;
            if (Parameters == null) goto Label_0017;
            goto Label_000E;
        }

        /// <summary>创建执行命令对象</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <returns>执行命令对象实例</returns>
        public DbCommand CreateCommand(string CommandText)
        {
            DbParameter[] parameters = new DbParameter[0];
            return this.CreateCommand(CommandText, CommandType.Text, parameters);
        }

        /// <summary>创建执行命令对象</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="CommandType">SQL语句类型</param>
        /// <returns>执行命令对象实例</returns>
        public DbCommand CreateCommand(string CommandText, CommandType CommandType)
        {
            DbParameter[] parameters = new DbParameter[0];
            return this.CreateCommand(CommandText, CommandType, parameters);
        }

        /// <summary>创建执行命令对象</summary>
        /// <param name="CommandText">ＳＱＬ语句</param>
        /// <param name="Parameters">参数</param>
        /// <returns>执行命令对象实例</returns>
        public DbCommand CreateCommand(string CommandText, DbParameter[] Parameters) { return this.CreateCommand(CommandText, CommandType.Text, Parameters); }

        /// <summary>创建执行命令对象</summary>
        /// <param name="sql"></param>
        /// <param name="cmdType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DbCommand CreateCommand(string sql, CommandType cmdType, DbParameter[] parameters)
        {
            int num;
            DbCommand command = this.GetDbProviderFactory().CreateCommand();
            goto Label_00D7;
        Label_0013:
            if (parameters != null) goto Label_00BF;
            return command;
        Label_0068:
            do
            {
                if (2 == 0 || 15 == 0) goto Label_0013;
                if (((uint) num) - ((uint) num) < 0) goto Label_00EA;
                if (((uint) num) - ((uint) num) <= uint.MaxValue) return command;
                if (0 == 0) goto Label_00D7;
            }
            while (1 == 0);
        Label_00BF:
            if (parameters.Length <= 0) return command;
            DbParameter[] parameterArray = parameters;
            num = 0;
        Label_0074:
            if (num < parameterArray.Length)
            {
                DbParameter parameter = parameterArray[num];
                command.Parameters.Add(parameter);
                num++;
                if (((uint) num) + ((uint) num) <= uint.MaxValue)
                {
                    if (-2 != 0) goto Label_0074;
                    goto Label_0068;
                }
            }
            else if (((uint) num) <= uint.MaxValue) goto Label_0068;
            goto Label_00BF;
        Label_00D7:
            command.Connection = this.CreateConnection();
            command.CommandText = sql;
        Label_00EA:
            command.CommandType = cmdType;
            goto Label_0013;
        }

        /// <summary>创建数据库连接</summary>
        /// <returns></returns>
        public DbConnection CreateConnection()
        {
            DbConnection connection = this.GetDbProviderFactory().CreateConnection();
            connection.ConnectionString = this.GetConnectionString();
            return connection;
        }

        /// <summary>创建数据库连接</summary>
        /// <param name="ProviderName"></param>
        /// <returns></returns>
        public DbConnection CreateConnection(string ProviderName)
        {
            DbConnection connection = this.GetDbProviderFactory(ProviderName).CreateConnection();
            connection.ConnectionString = this.GetConnectionString();
            return connection;
        }

        /// <summary>创建参数</summary>
        /// <param name="Key">参数字段</param>
        /// <param name="Value">参数值</param>
        /// <returns></returns>
        public DbParameter CreateParameter(string Key, string Value)
        {
            DbParameter parameter = this.GetDbProviderFactory().CreateParameter();
            parameter.ParameterName = Key;
            parameter.Value = Value;
            return parameter;
        }

        /// <summary>执行查询，并以DataSet返回结果集</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <returns>DataSet</returns>
        public DataSet ExecuteDataSet(string CommandText)
        {
            DbParameter[] parameters = new DbParameter[0];
            return this.ExecuteDataSet(CommandText, CommandType.Text, parameters);
        }

        /// <summary>执行查询，并以DataSet返回结果集</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="Parameters">参数</param>
        /// <returns>DataSet</returns>
        public virtual DataSet ExecuteDataSet(string CommandText, DbParameter[] Parameters) { return this.ExecuteDataSet(CommandText, CommandType.Text, Parameters); }

        /// <summary>执行查询，并以DataSet返回结果集</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="CommandType">命令类型</param>
        /// <returns>DataSet</returns>
        public virtual DataSet ExecuteDataSet(string CommandText, CommandType CommandType)
        {
            DbParameter[] parameters = new DbParameter[0];
            return this.ExecuteDataSet(CommandText, CommandType, parameters);
        }

        /// <summary>执行查询，并以DataSet返回结果集</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="CommandType">命令类型</param>
        /// <param name="Parameters">参数</param>
        /// <returns>DataSet</returns>
        public virtual DataSet ExecuteDataSet(string CommandText, CommandType CommandType, DbParameter[] Parameters)
        {
            DataSet dataSet = new DataSet();
            IDataAdapter adapter = this.CreateAdapter(CommandText, CommandType, Parameters);
            try
            {
                adapter.Fill(dataSet);
            }
            catch
            {
                throw;
            }
            return dataSet;
        }

        /// <summary>执行查询,并以DataSet返回指定记录的结果集</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="StartIndex">开始索引</param>
        /// <param name="RecordCount">显示记录</param>
        /// <returns>DataSet</returns>
        public virtual DataSet ExecuteDataSet(string CommandText, int StartIndex, int RecordCount) { return this.ExecuteDataSet(CommandText, StartIndex, RecordCount); }

        /// <summary>执行查询，并以DataTable返回结果集</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteDataTable(string CommandText)
        {
            DbParameter[] parameters = new DbParameter[0];
            return this.ExecuteDataSet(CommandText, 1, parameters).Tables[0];
        }

        /// <summary>执行查询,返回以空行填充的指定条数记录集</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="SizeCount">显示记录条数</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteDataTable(string CommandText, int SizeCount)
        {
            int num;
            int num2;
            DataTable table = this.ExecuteDataSet(CommandText).Tables[0];
            if ((((uint) num) | 2) != 0)
            {
                num = SizeCount - table.Rows.Count;
                if (0 == 0 || 0 != 0) goto Label_0036;
                goto Label_006E;
            }
        Label_002B:
            while (num2 < num)
            {
                DataRow row = table.NewRow();
                table.Rows.Add(row);
                num2++;
            }
            if (8 != 0) return table;
        Label_0036:
            if (table.Rows.Count >= SizeCount) return table;
        Label_006E:
            num2 = 0;
            goto Label_002B;
        }

        /// <summary>执行查询，并以DataTable返回结果集</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="Parameters">参数</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteDataTable(string CommandText, DbParameter[] Parameters) { return this.ExecuteDataSet(CommandText, 1, Parameters).Tables[0]; }

        /// <summary>执行查询，并以DataTable返回结果集</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="CommandType">命令类型</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteDataTable(string CommandText, CommandType CommandType)
        {
            DbParameter[] parameters = new DbParameter[0];
            return this.ExecuteDataSet(CommandText, CommandType, parameters).Tables[0];
        }

        /// <summary>执行查询，并以DataTable返回结果集</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="CommandType">命令类型</param>
        /// <param name="Parameters">参数</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteDataTable(string CommandText, CommandType CommandType, DbParameter[] Parameters) { return this.ExecuteDataSet(CommandText, CommandType, Parameters).Tables[0]; }

        /// <summary>执行查询,并以DataTable返回指定记录的结果集</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="StartIndex">开始索引</param>
        /// <param name="RecordCount">显示记录</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteDataTable(string CommandText, int StartIndex, int RecordCount) { return this.ExecuteDataSet(CommandText, StartIndex, RecordCount).Tables[0]; }

        /// <summary>执行查询，并以DataView返回结果集</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <returns>DataView</returns>
        public DataView ExecuteDataView(string CommandText)
        {
            DbParameter[] parameters = new DbParameter[0];
            return this.ExecuteDataSet(CommandText, 1, parameters).Tables[0].DefaultView;
        }

        /// <summary>执行查询，并以DataView返回结果集</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="CommandType">命令类型</param>
        /// <returns>DataView</returns>
        public DataView ExecuteDataView(string CommandText, CommandType CommandType)
        {
            DbParameter[] parameters = new DbParameter[0];
            return this.ExecuteDataSet(CommandText, CommandType, parameters).Tables[0].DefaultView;
        }

        /// <summary>执行查询，并以DataView返回结果集</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="Parameters">参数</param>
        /// <returns>DataView</returns>
        public DataView ExecuteDataView(string CommandText, DbParameter[] Parameters) { return this.ExecuteDataSet(CommandText, 1, Parameters).Tables[0].DefaultView; }

        /// <summary>执行查询，并以DataView返回结果集</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="CommandType">命令类型</param>
        /// <param name="Parameters">参数</param>
        /// <returns>DataView</returns>
        public DataView ExecuteDataView(string CommandText, CommandType CommandType, DbParameter[] Parameters) { return this.ExecuteDataSet(CommandText, CommandType, Parameters).Tables[0].DefaultView; }

        /// <summary>执行查询,并以DataView返回指定记录的结果集</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="StartIndex">开始索引</param>
        /// <param name="RecordCount">显示记录</param>
        /// <returns>DataView</returns>
        public DataView ExecuteDataView(string CommandText, int StartIndex, int RecordCount) { return this.ExecuteDataSet(CommandText, StartIndex, RecordCount).Tables[0].DefaultView; }

        /// <summary>批量执行SQL语句</summary>
        /// <param name="SqlList">SQL列表</param>
        /// <returns></returns>
        public bool ExecuteNonQuery(ArrayList SqlList)
        {
            DbConnection connection = this.CreateConnection();
            connection.Open();
            bool flag = false;
            string message = "";
            DbTransaction transaction = connection.BeginTransaction();
            try
            {
                DbCommand command;
                int num = 0;
                goto Label_0047;
            Label_002D:
                command.ExecuteNonQuery();
                num++;
            Label_003B:
                if (num < SqlList.Count) goto Label_004C;
                goto Label_000B;
            Label_0047:
                if (0 != 0) goto Label_002D;
                goto Label_003B;
            Label_004C:
                command = this.GetDbProviderFactory().CreateCommand();
                command.Connection = connection;
                command.CommandText = SqlList[num].ToString();
                command.Transaction = transaction;
                goto Label_002D;
            }
            catch (Exception exception)
            {
                flag = true;
                message = exception.Message;
            }
            finally
            {
                if (flag)
                {
                    transaction.Rollback();
                    throw new Exception(message);
                }
                transaction.Commit();
                connection.Close();
            }
        Label_000B:
            if (flag) return false;
            return true;
        }

        /// <summary>执行查询语句,并返回受影响的记录行数</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <returns>受影响记录行数</returns>
        public int ExecuteNonQuery(string CommandText)
        {
            DbParameter[] parameters = new DbParameter[0];
            return this.ExecuteNonQuery(CommandText, CommandType.Text, parameters);
        }

        /// <summary>执行查询语句,并返回受影响的记录行数</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="CommandType">命令类型</param>
        /// <returns>受影响记录行数</returns>
        public int ExecuteNonQuery(string CommandText, CommandType CommandType)
        {
            DbParameter[] parameters = new DbParameter[0];
            return this.ExecuteNonQuery(CommandText, CommandType, parameters);
        }

        /// <summary>执行查询语句,并返回受影响的记录行数</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="Parameters">参数</param>
        /// <returns>受影响记录行数</returns>
        public int ExecuteNonQuery(string CommandText, DbParameter[] Parameters) { return this.ExecuteNonQuery(CommandText, CommandType.Text, Parameters); }

        /// <summary>执行查询语句,并返回受影响的记录行数</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="CommandType">命令类型</param>
        /// <param name="Parameters">参数</param>
        /// <returns>受影响记录行数</returns>
        public int ExecuteNonQuery(string CommandText, CommandType CommandType, DbParameter[] Parameters)
        {
            int num = 0;
            DbCommand command = this.CreateCommand(CommandText, CommandType, Parameters);
            try
            {
                command.Connection.Open();
                num = command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                command.Connection.Close();
            }
            return num;
        }

        /// <summary>执行查询，并以DataReader返回结果集</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <returns>IDataReader</returns>
        public DbDataReader ExecuteReader(string CommandText)
        {
            DbParameter[] parameters = new DbParameter[0];
            return this.ExecuteReader(CommandText, CommandType.Text, parameters);
        }

        /// <summary>执行查询，并以DataReader返回结果集</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="CommandType">命令类型</param>
        /// <returns>IDataReader</returns>
        public DbDataReader ExecuteReader(string CommandText, CommandType CommandType)
        {
            DbParameter[] parameters = new DbParameter[0];
            return this.ExecuteReader(CommandText, CommandType, parameters);
        }

        /// <summary>执行查询，并以DataReader返回结果集</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="Parameters">参数</param>
        /// <returns>IDataReader</returns>
        public DbDataReader ExecuteReader(string CommandText, DbParameter[] Parameters) { return this.ExecuteReader(CommandText, CommandType.Text, Parameters); }

        /// <summary>执行查询，并以DataReader返回结果集</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="CommandType">命令类型</param>
        /// <param name="Parameters">参数</param>
        /// <returns>IDataReader</returns>
        public DbDataReader ExecuteReader(string CommandText, CommandType CommandType, DbParameter[] Parameters)
        {
            DbDataReader reader;
            DbCommand command = this.CreateCommand(CommandText, CommandType, Parameters);
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {
                throw;
            }
            return reader;
        }

        /// <summary>执行查询语句,并返回首行首列的值</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <returns>Object</returns>
        public object ExecuteScalar(string CommandText)
        {
            DbParameter[] parameters = new DbParameter[0];
            return this.ExecuteScalar(CommandText, CommandType.Text, parameters);
        }

        /// <summary>执行查询语句,并返回首行首列的值</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="Parameters">参数</param>
        /// <returns>Object</returns>
        public object ExecuteScalar(string CommandText, DbParameter[] Parameters) { return this.ExecuteScalar(CommandText, CommandType.Text, Parameters); }

        /// <summary>执行查询语句,并返回首行首列的值</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="CommandType">命令类型</param>
        /// <returns>Object</returns>
        public object ExecuteScalar(string CommandText, CommandType CommandType)
        {
            DbParameter[] parameters = new DbParameter[0];
            return this.ExecuteScalar(CommandText, CommandType, parameters);
        }

        /// <summary>执行查询语句,并返回首行首列的值</summary>
        /// <param name="CommandText">SQL语句</param>
        /// <param name="CommandType">命令类型</param>
        /// <param name="Parameters">参数</param>
        /// <returns>Object</returns>
        public object ExecuteScalar(string CommandText, CommandType CommandType, DbParameter[] Parameters)
        {
            object obj2 = null;
            DbCommand command = this.CreateCommand(CommandText, CommandType, Parameters);
            try
            {
                command.Connection.Open();
                obj2 = command.ExecuteScalar();
            }
            catch
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
            }
            return obj2;
        }

        /// <summary>获得连接字符串</summary>
        /// <returns></returns>
        public string GetConnectionString() { return this.GetConnectionString(this.ConnectionName); }

        /// <summary>获得连接字符串<param name="ConnectionName">连接字符串名称</param></summary>
        /// <returns></returns>
        public string GetConnectionString(string ConnectionName)
        {
            ConnectionStringSettings settings;
            ConnectionStringSettingsCollection connectionStrings = ConfigurationManager.ConnectionStrings;
            if (4 != 0) goto Label_007B;
        Label_0010:
            if (1 == 0)
            {
                if (0 != 0) goto Label_0032;
                if (-2147483648 == 0) goto Label_0093;
                if (0xff != 0)
                {
                    if (0 == 0) goto Label_0085;
                    goto Label_007B;
                }
                goto Label_0052;
            }
        Label_0017:
            settings = ConfigurationManager.ConnectionStrings[ConnectionName];
            goto Label_00A4;
        Label_0032:
            if (ConnectionName == string.Empty) goto Label_0066;
            goto Label_0010;
        Label_0052:
            throw new Exception("app.config 中无连接字符串!");
        Label_0066:
            settings = ConfigurationManager.ConnectionStrings["ConnectionString"];
            goto Label_00A4;
        Label_007B:
            if (connectionStrings != null) goto Label_0093;
            if (0 == 0) goto Label_0052;
        Label_0085:
            if (-2147483648 != 0)
            {
                if (0 != 0) goto Label_0052;
                goto Label_0017;
            }
            goto Label_0010;
        Label_0093:
            if (connectionStrings.Count > 0)
            {
                settings = null;
                if (0xff != 0) goto Label_0032;
                goto Label_0066;
            }
            if (0 == 0) goto Label_0052;
            goto Label_0010;
        Label_00A4:
            return settings.ConnectionString;
        }

        /// <summary>获取数据库连接字符串示例信息</summary>
        /// <param name="DataType">数据库类型</param>
        /// <returns></returns>
        public string GetConnectionString(DataType DataType)
        {
            try
            {
                DbFactory.DataType type = DataType;
                if (0 == 0)
                {
                    switch (type)
                    {
                        case DbFactory.DataType.SqlClient:
                            return "<add name=\"ConnectionString\" connectionString=\"server=.;database=Northwind;uid=sa;pwd=sa\" providerName=\"System.Data.SqlClient\" />";

                        case DbFactory.DataType.ACCESS:
                            return "<add name=\"ConnectionString\" connectionString=\"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\\database\\NorthWind.mdb; Persist Security Info=False\" providerName=\"System.Data.OleDb\" />";

                        case DbFactory.DataType.EXCEL:
                            return "<add name=\"ConnectionString\" connectionString=\"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\\database\\NorthWind.xls;Extended Properties='Excel 8.0;'\" providerName=\"System.Data.OleDb\" />";

                        case DbFactory.DataType.OracleClient:
                            return "";
                    }
                }
            }
            catch (Exception)
            {
            }
            return "";
        }

        /// <summary>返回数据工厂</summary>
        /// <returns></returns>
        public DbProviderFactory GetDbProviderFactory()
        {
            DbProviderFactory factory = null;
            string str;
            string str2;
            goto Label_00C9;
        Label_0007:
            factory = this.GetDbProviderFactory("System.Data.SqlClient");
            if (0 == 0)
            {
                if (3 != 0) return factory;
                goto Label_00C9;
            }
        Label_0030:
            return this.GetDbProviderFactory("System.Data.OleDb");
        Label_009B:
            factory = this.GetDbProviderFactory("System.Data.SqlClient");
            if (-1 != 0)
            {
                if (8 != 0) return factory;
                return factory;
            }
        Label_00C9:
            str = this.GetProviderName();
            if (-2 != 0 && (str2 = str) == null)
            {
                if (4 == 0) goto Label_00C9;
                if (0 != 0) goto Label_009B;
                goto Label_0007;
            }
            switch (str2)
            {
                case "System.Data.SqlClient":
                    goto Label_009B;

                case "System.Data.OracleClient":
                    return this.GetDbProviderFactory("System.Data.OracleClient");
            }
            if (0 != 0) return factory;
            if (!(str2 == "System.Data.OleDb")) goto Label_0007;
            goto Label_0030;
        }

        /// <summary>返回数据工厂</summary>
        /// <param name="ProviderName"></param>
        /// <returns></returns>
        public DbProviderFactory GetDbProviderFactory(string ProviderName) { return DbProviderFactories.GetFactory(ProviderName); }

        /// <summary>返回数据提供者</summary>
        /// <returns></returns>
        public string GetProviderName() { return this.GetProviderName(this.ConnectionName); }

        /// <summary>返回数据提供者<param name="ConnectionName">连接字符串名称</param></summary>
        /// <returns>返回数据提供者</returns>
        public string GetProviderName(string ConnectionName)
        {
            ConnectionStringSettings settings;
            ConnectionStringSettingsCollection connectionStrings = ConfigurationManager.ConnectionStrings;
            if (connectionStrings != null)
            {
                if (connectionStrings.Count <= 0) goto Label_0049;
                settings = null;
            }
            else
                goto Label_0049;
            if (ConnectionName == string.Empty)
                settings = ConfigurationManager.ConnectionStrings["ConnectionString"];
            else
                settings = ConfigurationManager.ConnectionStrings[ConnectionName];
            return settings.ProviderName;
        Label_0049:
            throw new Exception("app.config 中无连接字符串!");
        }

        /// <summary>数据库连接字符串名称</summary>
        public string ConnectionName { get { return this._xcc3d2e7156117305; } set { this._xcc3d2e7156117305 = value; } }

        /// <summary>数据类型</summary>
        public enum DataType
        {
            SqlClient,
            ACCESS,
            EXCEL,
            OracleClient
        }
    }
}
