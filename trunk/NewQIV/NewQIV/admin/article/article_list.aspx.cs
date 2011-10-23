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

public partial class admin_article_article_list : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        check.checkAdmin(Request.Cookies["Admin_ID"]);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        FuncCommon.GoToURL("article_add.aspx?cate_id=" + Request.QueryString["cate_id"]);
    }
}
