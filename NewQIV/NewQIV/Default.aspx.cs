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
        /// <summary>
        /// 顺序：
        /// 0:WSM-Plam
        /// 1:Ace-Pred-train
        /// 2:PMeS-R
        /// 3:PMeS-K
        /// 4:DLMLA-M
        /// 5:DLMLA-A
        /// 6:PredSulSite
        /// </summary>
        public static Model[] modelList = ProteidSvmTest.ReadAllSvmTestMode ();//读取所有模型

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
