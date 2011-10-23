using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cn.buddy;
using System.Data.OleDb;
using SVM;
using SvmNet;

namespace WebUI
{
    public partial class _default : System.Web.UI.Page
    {
        public static Model[] modelList = ProteidSvmTest.GetAllSvmTestMode();

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void ltlAboutUs_Load(object sender, EventArgs e)
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

            this.ltlAboutUs.Text = s;
        }
    }
}
