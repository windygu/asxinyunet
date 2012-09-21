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
    public partial class admin_main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            check.checkAdmin(Request.Cookies["Admin_ID"]);
            if (!Page.IsPostBack)
            {
                loadNodes();
            }
        }

        private void loadNodes()
        {
            menuTree.Nodes.Clear();
            OleDbConnection conn = DatabaseCommon.CreateConnection(2);
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from category where parent_id=0 order by cate_order asc";
            conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TreeNode tn = new TreeNode();
                tn.Text = dr["cate_name"].ToString();
                tn.Target = "content";
                tn.Value = dr["cate_id"].ToString();
                tn.Expanded = false;
                if ((bool)dr["cate_readonly"] == true)
                {
                    tn.SelectAction = TreeNodeSelectAction.Expand;
                }
                else
                {
                    tn.SelectAction = TreeNodeSelectAction.Select;
                    switch (dr["cate_type"].ToString())
                    {
                        case "文章":
                            tn.NavigateUrl = "article/article_list.aspx?cate_id=" + dr["cate_id"].ToString();
                            break;
                        case "图片":
                            tn.NavigateUrl = "picture/picture_list.aspx?cate_id=" + dr["cate_id"].ToString();
                            break;
                        case "文档":
                            tn.NavigateUrl = "config/config.aspx?cate_id=" + dr["cate_id"].ToString();
                            break;
                        case "链接":
                            tn.NavigateUrl = "link/link_list.aspx?cate_id=" + dr["cate_id"].ToString();
                            break;
                    }
                }
                menuTree.Nodes.Add(tn);
                loadChildNodes(tn);
            }
            dr.Close();
            conn.Close();

            loadOtherNodes();
        }

        private void loadChildNodes(TreeNode root)
        {
            string pid = root.Value;
            OleDbConnection conn = DatabaseCommon.CreateConnection(2);
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from category where parent_id=@parent_id order by cate_order asc";
            cmd.Parameters.AddWithValue("@parent_id", pid);
            conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TreeNode tn = new TreeNode();
                tn.Text = dr["cate_name"].ToString();
                tn.Target = "content";
                tn.Value = dr["cate_id"].ToString();
                tn.Expanded = false;
                if ((bool)dr["cate_readonly"] == true)
                {
                    tn.SelectAction = TreeNodeSelectAction.Expand;
                }
                else
                {
                    tn.SelectAction = TreeNodeSelectAction.Select;
                    switch (dr["cate_type"].ToString())
                    {
                        case "文章":
                            tn.NavigateUrl = "article/article_list.aspx?cate_id=" + dr["cate_id"].ToString();
                            break;
                        case "图片":
                            tn.NavigateUrl = "picture/picture_list.aspx?cate_id=" + dr["cate_id"].ToString();
                            break;
                        case "文档":
                            tn.NavigateUrl = "config/config.aspx?cate_id=" + dr["cate_id"].ToString();
                            break;
                        case "链接":
                            tn.NavigateUrl = "link/link_list.aspx?cate_id=" + dr["cate_id"].ToString();
                            break;
                    }
                }
                root.ChildNodes.Add(tn);
                loadChildNodes(tn);
            }
            dr.Close();
            conn.Close();
        }

        private void loadOtherNodes()
        {
            TreeNode tn, ctn;

            //tn = new TreeNode();
            //tn.Expanded = false;
            //tn.SelectAction = TreeNodeSelectAction.Expand;
            //tn.Text = "栏目管理";
            //tn.Value = "栏目管理";
            //menuTree.Nodes.Add(tn);
            //ctn = new TreeNode();
            //ctn.Expanded = false;
            //ctn.SelectAction = TreeNodeSelectAction.Select;
            //ctn.Target = "content";
            //ctn.Text = "增加栏目";
            //ctn.Value = "增加栏目";
            //ctn.NavigateUrl = "system/category_add.aspx";
            //tn.ChildNodes.Add(ctn);
            //ctn = new TreeNode();
            //ctn.Expanded = false;
            //ctn.SelectAction = TreeNodeSelectAction.Select;
            //ctn.Target = "content";
            //ctn.Text = "栏目管理";
            //ctn.Value = "栏目管理";
            //ctn.NavigateUrl = "system/category_list.aspx";
            //tn.ChildNodes.Add(ctn);


            tn = new TreeNode();
            tn.Expanded = false;
            tn.SelectAction = TreeNodeSelectAction.Expand;
            tn.Text = "系统管理";
            tn.Value = "系统管理";
            menuTree.Nodes.Add(tn);
            ctn = new TreeNode();
            ctn.Expanded = false;
            ctn.SelectAction = TreeNodeSelectAction.Select;
            ctn.Target = "content";
            ctn.Text = "添加管理员";
            tn.Value = "添加管理员";
            ctn.NavigateUrl = "system/admin_add.aspx";
            tn.ChildNodes.Add(ctn);
            ctn = new TreeNode();
            ctn.Expanded = false;
            ctn.SelectAction = TreeNodeSelectAction.Select;
            ctn.Target = "content";
            ctn.Text = "管理管理员";
            tn.Value = "管理管理员";
            ctn.NavigateUrl = "system/admin_list.aspx";
            tn.ChildNodes.Add(ctn);

            tn = new TreeNode();
            tn.Expanded = false;
            tn.SelectAction = TreeNodeSelectAction.Select;
            tn.Target = "content";
            tn.Text = "修改信息";
            tn.Value = "修改信息";
            tn.NavigateUrl = "system/info_modify.aspx";
            menuTree.Nodes.Add(tn);

            tn = new TreeNode();
            tn.Expanded = false;
            tn.SelectAction = TreeNodeSelectAction.Select;
            tn.Target = "_top";
            tn.Text = "退出系统";
            tn.Value = "退出系统";
            tn.NavigateUrl = "logout.aspx";
            menuTree.Nodes.Add(tn);
        }
    }
}