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
    public partial class admin_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string uid = Request.Form["userid"].ToString();
            string pwd = Request.Form["password"].ToString();

            OleDbConnection conn = DatabaseCommon.CreateConnection(2);
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from admin where admin_uid=@admin_uid and admin_pwd=@admin_pwd and usergroup='管理员'";
            cmd.Parameters.AddWithValue("@admin_uid", uid);
            cmd.Parameters.AddWithValue("@admin_pwd", pwd);
            conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                HttpCookie c = new HttpCookie("Admin_ID");
                c.Value = dr["admin_id"].ToString();
                c.Expires = DateTime.Now.AddDays(1);
                Response.AppendCookie(c);
                //Session["Admin_ID"] = dr["admin_id"].ToString();
                FuncCommon.GoToURL("main.aspx");
            }
            else
            {
                FuncCommon.Alert("账号或密码错误");
                FuncCommon.GoBack();
            }
            dr.Close();
            conn.Close();
        }
    }
}