using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using cn.buddy;

namespace Admin
{
    public partial class admin_system_info_modify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            check.checkAdmin(Request.Cookies["Admin_ID"]);
            if (!Page.IsPostBack)
            {
                OleDbConnection conn = DatabaseCommon.CreateConnection(3);
                try
                {
                    OleDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "select * from admin where admin_id=@admin_id";
                    cmd.Parameters.AddWithValue("@admin_id", Request.Cookies["Admin_ID"].Value);
                    conn.Open();
                    OleDbDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    admin_name.Text = dr["admin_name"].ToString();
                    dr.Close();
                }
                catch (Exception ex)
                {
                    FuncCommon.Alert(ex.Message);
                    FuncCommon.GoBack();
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection conn = DatabaseCommon.CreateConnection(3);
                OleDbCommand cmd = conn.CreateCommand();
                if (admin_pwd.Text != "")
                {
                    cmd.CommandText = "update admin set admin_pwd=@admin_pwd where admin_id=@admin_id";
                    cmd.Parameters.AddWithValue("@admin_pwd", admin_pwd.Text);
                    cmd.Parameters.AddWithValue("@admin_id", Request.Cookies["Admin_ID"].Value);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                cmd = conn.CreateCommand();
                cmd.CommandText = "update admin set admin_name=@admin_name where admin_id=@admin_id";
                cmd.Parameters.AddWithValue("@admin_name", admin_name.Text);
                cmd.Parameters.AddWithValue("@admin_id", Request.Cookies["Admin_ID"].Value);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                FuncCommon.Alert("操作成功");

                FuncCommon.Reload();
            }
            catch (Exception ex)
            {
                FuncCommon.Alert(ex.Message);
                FuncCommon.GoBack();
            }
        }
    }
}