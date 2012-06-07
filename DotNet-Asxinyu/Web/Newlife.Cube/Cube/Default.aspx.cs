using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewLife.CommonEntity;
using XCode;

public partial class Cube_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            IMenu root = CommonManageProvider.Provider.MenuRoot;
            root.CheckMenuName("Cube", "魔方平台")
                .CheckMenuName(@"Cube\ModelManage", "模型管理")
                .CheckMenuName(@"Cube\ModelDesigner", "模型设计");

            ClientScript.RegisterStartupScript(this.GetType(), "redirect", "setTimeout(\"location='ModelManage/DataModel.aspx'\", 1);", true);
        }
    }
}