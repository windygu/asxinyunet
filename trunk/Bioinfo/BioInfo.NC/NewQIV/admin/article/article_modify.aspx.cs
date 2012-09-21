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

public partial class admin_article_article_modify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        check.checkAdmin(Request.Cookies["Admin_ID"]);
        if (!Page.IsPostBack)
        {
            OleDbConnection conn = DatabaseCommon.CreateConnection(3);
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from article where arti_id=@arti_id";
            cmd.Parameters.AddWithValue("@arti_id", Request.QueryString["arti_id"].ToString());
            conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            try
            {
                dr.Read();
                arti_title.Text = dr["arti_title"].ToString();
                arti_author.Text = dr["arti_author"].ToString();
                arti_source.Text = dr["arti_source"].ToString();
                arti_time2.Text = dr["arti_time2"].ToString();
                arti_content.Text = dr["arti_content"].ToString();
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
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            OleDbConnection conn = DatabaseCommon.CreateConnection(3);
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "update article set arti_title=@arti_title,arti_author=@arti_author,arti_time2=@arti_time2,arti_source=@arti_source,arti_content=@arti_content where arti_id=@arti_id";
            cmd.Parameters.AddWithValue("@arti_title", arti_title.Text);
            cmd.Parameters.AddWithValue("@arti_author", arti_author.Text);
            cmd.Parameters.AddWithValue("@arti_time2", DateTime.Now.ToString());
            cmd.Parameters.AddWithValue("@arti_source", arti_source.Text);
            cmd.Parameters.AddWithValue("@arti_content", Article.changeMediaPlayerToReal(arti_content.Text));
            cmd.Parameters.AddWithValue("@arti_id", Request.QueryString["arti_id"]);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            FuncCommon.Alert("操作成功");

            FuncCommon.GoToURL("article_list.aspx?cate_id="+Article.getCateId(Request.QueryString["arti_id"],3));
            FuncCommon.Reload();
        }
        catch (Exception ex)
        {
            FuncCommon.Alert(ex.Message);
            FuncCommon.GoBack();
        }
    }
}