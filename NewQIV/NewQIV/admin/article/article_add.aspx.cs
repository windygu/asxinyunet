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

public partial class admin_article_article_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        check.checkAdmin(Request.Cookies["Admin_ID"]);

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string cate_id = Request.QueryString["cate_id"];
        try
        {
            OleDbConnection conn = DatabaseCommon.CreateConnection(3);
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "insert into article(arti_title,arti_author,arti_source,arti_content,cate_id) values(@arti_title,@arti_author,@arti_source,@arti_content,@cate_id)";
            cmd.Parameters.AddWithValue("@arti_title", arti_title.Text);
            cmd.Parameters.AddWithValue("@arti_author", arti_author.Text);
            cmd.Parameters.AddWithValue("@arti_source", arti_source.Text);
            cmd.Parameters.AddWithValue("@arti_content", Article.changeMediaPlayerToReal(arti_content.Text));
            cmd.Parameters.AddWithValue("@cate_id", cate_id);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            FuncCommon.Alert("操作成功");

            FuncCommon.GoToURL("article_list.aspx?cate_id=" + cate_id);
        }
        catch (Exception ex)
        {
            FuncCommon.Alert(ex.Message);
            FuncCommon.GoBack();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        FuncCommon.GoBack();
    }
}
