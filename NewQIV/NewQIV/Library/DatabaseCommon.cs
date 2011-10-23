using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

/// <summary>
/// DatabaseCommon 的摘要说明
/// </summary>
/// 

namespace cn.buddy
{
    public class DatabaseCommon
    {
        public static string ExecuteScaler(string s_table, string s_column, string s_condition, int folderDeepth)
        {
            OleDbConnection conn = CreateConnection(folderDeepth);
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select " + s_column + " from [" + s_table + "] where " + s_condition;

            conn.Open();
            string s = Convert.ToString(cmd.ExecuteScalar());
            conn.Close();

            return s;
        }
        public static string ExecuteScaler(string s_sql, int folderDeepth)
        {
            OleDbConnection conn = CreateConnection(folderDeepth);
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = s_sql;

            conn.Open();
            string s = Convert.ToString(cmd.ExecuteScalar());
            conn.Close();

            return s;
        }

        public static void ExecuteNonQuery(string sql, int folderDeepth)
        {
            OleDbConnection conn = CreateConnection(folderDeepth);
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;

            cmd.CommandText = sql;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static bool HasRows(string s_table, string s_condition, int folderDeepth)
        {
            
            OleDbConnection conn = CreateConnection(folderDeepth);
            OleDbCommand cmd = new OleDbCommand();
           
                cmd.Connection = conn;
                cmd.CommandText = "select * from [" + s_table + "] where " + s_condition;
                conn.Open();
                OleDbDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Close();
                    conn.Close();
                    return true;
                }
                else
                { 
                    dr.Close();
                    conn.Close();
                    return false;                  
                }
                       
        }

        public static DataTable Fill(string sql, int folderDeepth)
        {
            OleDbConnection conn = CreateConnection(folderDeepth);
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static OleDbConnection CreateConnection(int folderDeepth)
        {
            return (new OleDbConnection(System.Configuration.ConfigurationManager.AppSettings["MainDNS"].ToString() + HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["DBPath" + folderDeepth + ""].ToString())));
        }
    }
}
