using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using cn.buddy;

namespace WebUI
{
    public partial class NewsDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ArticleDetail_Load(object sender, EventArgs e)
        {
            string s = "";
            string arti_id = Request.QueryString["aid"];
            if (arti_id != "" && arti_id != null)
            {
                OleDbConnection conn = DatabaseCommon.CreateConnection(1);
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from article where arti_id=@arit_id";
                cmd.Parameters.AddWithValue("@arti_id", arti_id);
                conn.Open();
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    s += "<div align='center' style='font-size:18px; font-weight:bolder; color:#000;'>" + dr["arti_title"].ToString() + "</div>";
                    s += "<div align='center' style='font-size:12px; color:#666;'>作者:" + dr["arti_author"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;发布时间:" + dr["arti_time"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;最后修改时间:" + dr["arti_time2"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;来源:" + dr["arti_source"].ToString() + "&nbsp;&nbsp;</div>";
                    s += "<hr style='border:1px solid #DDD;' /><br />";
                    s += dr["arti_content"].ToString();
                }
                dr.Close();
                conn.Close();

                ArticleDetail.Text = s;
            }
        }
    }

}
