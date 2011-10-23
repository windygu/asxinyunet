using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cn.buddy;
using System.Data.OleDb;

namespace WebUI
{
    public partial class ResultNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ArticalList_Load(object sender, EventArgs e)
        {
            ArticalList.Text = getArticleList(278, 0);
        }

        private string getArticleList(long cate_id, int n)
        {
            string s = "";
            OleDbConnection conn = DatabaseCommon.CreateConnection(1);
            OleDbCommand cmd = conn.CreateCommand();
            if (n == 0)
                cmd.CommandText = "select * from article where cate_id=@cate_id order by arti_id desc";
            else
                cmd.CommandText = "select top " + n.ToString() + " * from article where cate_id=@cate_id order by arti_id desc";
            cmd.Parameters.AddWithValue("@cate_id", cate_id);
            conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                s += "<li><a href='NewsDetail.aspx?aid=" + dr["arti_id"].ToString() + "'>" + dr["arti_title"].ToString() + "</a></li>";
            }
            dr.Close();
            conn.Close();
            return s;
        }
    }
}
