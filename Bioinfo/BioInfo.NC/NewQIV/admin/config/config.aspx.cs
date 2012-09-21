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

public partial class admin_others_config : System.Web.UI.Page
{
    protected string cate;
    protected void Page_Load(object sender, EventArgs e)
    {
        check.checkAdmin(Request.Cookies["Admin_ID"]);
        string cate_id = Request.QueryString["cate_id"];
        cate = DatabaseCommon.ExecuteScaler("category", "cate_name", "cate_id=" + cate_id, 3);
        if (!Page.IsPostBack)
        {
            OleDbConnection conn = DatabaseCommon.CreateConnection(3);
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from [config] where [cate_id]=@cate_id";
            cmd.Parameters.AddWithValue("@cate_id", cate_id);
            conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                try
                {
                    dr.Read();
                    cfg_content.Text = dr["cfg_content"].ToString();
                }
                catch (Exception ex)
                {
                    FuncCommon.Alert(ex.Message);
                    FuncCommon.GoBack();
                }
                finally
                {
                    dr.Close();
                    conn.Close();
                }
            }
            else
            {
                cfg_content.Text = "";
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //string sql = "";
        try
        {
            OleDbConnection conn = DatabaseCommon.CreateConnection(3);
            OleDbCommand cmd = conn.CreateCommand();
            if (DatabaseCommon.HasRows("config", "cate_id=" + Request.QueryString["cate_id"], 3))
            {
                cmd.CommandText = "update [config] set [cfg_content]=@cfg_content where [cate_id]=@cate_id";
            }
            else
            {
                cmd.CommandText = "insert into [config](cfg_content,cate_id) values(@cfg_content,@cate_id)";
            }
            cmd.Parameters.AddWithValue("@cfg_content", Article.changeMediaPlayerToReal(cfg_content.Text));
            cmd.Parameters.AddWithValue("@cate_id", Request.QueryString["cate_id"]);

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
