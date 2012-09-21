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
using cn.buddy;
using System.Data.OleDb;

public partial class admin_system_admin_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        check.checkAdmin(Request.Cookies["Admin_ID"]);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            OleDbConnection conn = DatabaseCommon.CreateConnection(3);
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "insert into admin(admin_name,admin_uid,admin_pwd,usergroup) values(@admin_name,@admin_uid,@admin_pwd,@usergroup)";
            cmd.Parameters.AddWithValue("@admin_name", admin_name.Text);
            cmd.Parameters.AddWithValue("@admin_uid", admin_uid.Text);
            cmd.Parameters.AddWithValue("@admin_pwd", admin_pwd.Text);
            cmd.Parameters.AddWithValue("@usergroup", usergroup.SelectedValue);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            FuncCommon.Alert("操作成功");

            FuncCommon.GoToURL("admin_list.aspx");
        }
        catch (Exception ex)
        {
            FuncCommon.Alert(ex.Message);
            FuncCommon.GoBack();
        }
    }
}
