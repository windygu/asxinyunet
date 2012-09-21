using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using cn.buddy;

namespace WebUI
{
    public partial class AboutUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ltlAbout_Load(object sender, EventArgs e)
        {
            string cate_id = "283";
            OleDbConnection conn = DatabaseCommon.CreateConnection(1);
            OleDbCommand cmd = conn.CreateCommand();
            string s = "";
            cmd.CommandText = "select * from config where cate_id=@cate_id";
            cmd.Parameters.AddWithValue("@cate_id", cate_id);
            conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                s += dr["cfg_content"].ToString();
            }
            dr.Close();
            conn.Close();

            this.ltlAbout.Text = s;
        }
       

        protected void ltlContact_Load(object sender, EventArgs e)
        {
            string cate_id = "284";
            OleDbConnection conn = DatabaseCommon.CreateConnection(1);
            OleDbCommand cmd = conn.CreateCommand();
            string s = "";
            cmd.CommandText = "select * from config where cate_id=@cate_id";
            cmd.Parameters.AddWithValue("@cate_id", cate_id);
            conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                s += dr["cfg_content"].ToString();
            }
            dr.Close();
            conn.Close();

            this.ltlContact.Text = s;
        }
    }
}
