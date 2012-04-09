namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.OleDb;
    using System.Runtime.CompilerServices;

    public class OleDbHelper
    {
        private const string qCpqRb2bV = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};User ID=Admin;Jet OLEDB:Database Password=;";
        private string r4vfcKJvu = "";

        [MethodImpl(MethodImplOptions.NoInlining)]
        public OleDbHelper(string accessFilePath)
        {
            this.r4vfcKJvu = string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd4fa), accessFilePath);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public DataSet ExecuteDataSet(string sql)
        {
            DataSet dataSet = new DataSet();
            new OleDbDataAdapter(sql, this.r4vfcKJvu).Fill(dataSet);
            return dataSet;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int ExecuteNonQuery(List<string> sqlList)
        {
            int num = 0;
            using (OleDbConnection connection = new OleDbConnection(this.r4vfcKJvu))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand {
                    Connection = connection
                };
                foreach (string str in sqlList)
                {
                    command.CommandText = str;
                    command.CommandType = CommandType.Text;
                    try
                    {
                        if (command.ExecuteNonQuery() > 0)
                        {
                            num++;
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
            return num;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool ExecuteNoQuery(string sql)
        {
            bool flag = false;
            using (OleDbConnection connection = new OleDbConnection(this.r4vfcKJvu))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand {
                    Connection = connection,
                    CommandText = sql,
                    CommandType = CommandType.Text
                };
                if (command.ExecuteNonQuery() > 0)
                {
                    flag = true;
                }
            }
            return flag;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public IDataReader ExecuteReader(string sql)
        {
            using (OleDbConnection connection = new OleDbConnection(this.r4vfcKJvu))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand {
                    Connection = connection,
                    CommandText = sql,
                    CommandType = CommandType.Text
                };
                return command.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public object ExecuteScalar(string sql)
        {
            using (OleDbConnection connection = new OleDbConnection(this.r4vfcKJvu))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand {
                    Connection = connection,
                    CommandText = sql,
                    CommandType = CommandType.Text
                };
                return command.ExecuteScalar();
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public bool TestConnection()
        {
            bool flag = false;
            using (DbConnection connection = new OleDbConnection(this.r4vfcKJvu))
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    flag = true;
                }
            }
            return flag;
        }
    }
}

