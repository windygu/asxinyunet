using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewLife.CommonEntity;
using XCode;
using NewLife.Web;

public partial class Model_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            IMenu root = CommonManageProvider.Provider.MenuRoot;
            root.CheckMenuName("Model", "模型中心")
                .CheckMenuName(@"Model\CustomForm", "自定义表单");

            // 表单管理不要显示
            IMenu menu = root.FindByPath(@"Model\CustomForm");
            if (menu != null)
            {
                // 仅保留自定义表单
                foreach (IMenu item in menu.Childs)
                {
                    if (item.Name == "DataModel" || item.Name == "类别管理") continue;

                    item.IsShow = false;
                    (item as IEntity).Save();
                }
                //IMenu menu2 = menu.FindByPath("ModelTable");
                //if (menu2 != null)
                //{
                //    menu2.IsShow = false;
                //    (menu2 as IEntity).Save();
                //}
                //menu2 = menu.FindByPath("ModelData");
                //if (menu2 != null)
                //{
                //    menu2.IsShow = false;
                //    (menu2 as IEntity).Save();
                //}
            }

            //Response.Redirect("CustomForm/DataModel.aspx");
            // 不能直接输出，因为页面需要执行js，然后控制左边菜单
            //WebHelper.WriteScript("location.href='CustomForm/DataModel.aspx';");
            ClientScript.RegisterStartupScript(this.GetType(), "redirect", "setTimeout(\"location='CustomForm/DataModel.aspx'\", 1);", true);
        }
    }
}